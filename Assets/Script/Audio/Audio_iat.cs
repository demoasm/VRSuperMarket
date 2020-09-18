﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;
public class Audio_iat : MonoBehaviour
{
    private const string my_appid = "appid = 5f2566ec, work_dir = .";//appid根据自身情况修改
    public const string session_begin_params = "sub = iat, domain = iat, language = zh_cn, accent = mandarin, sample_rate = 16000, result_type = plain, result_encoding = utf-8";
    public static StringBuilder result = new StringBuilder();
    /*
   * sub:				请求业务类型
   * domain:			领域
   * language:			语言  zh_cn：简体中文  en_us：英文
   * accent:			方言
   * sample_rate:		音频采样率
   * result_type:		识别结果格式
   * result_encoding:	结果编码格式
   */
    //登录讯飞语音识别服务
    private static bool init_audio()
    {
        mscDLL.MSPLogout();
        int res = mscDLL.MSPLogin(null, null, my_appid);//用户名，密码，登陆信息，前两个均为空
        if (res != (int)Errors.MSP_SUCCESS)
        {//说明登陆失败
            //string ErrorInfo = "登陆失败！Errors:" + (int)Errors;
            Debug.Log("登陆失败！Errors:"+res);
            return false;
        }
        Debug.Log("登陆成功！");
        return true;
    }
    //
    private static bool audio_iat(byte[] audio_content, string session_begin_params)
    {
        result.Remove(0,result.Length);
        if (audio_content == null) return false;
        IntPtr session_id;
        //StringBuilder result = new StringBuilder();//存储最终识别的结果
        var aud_stat = AudioStatus.MSP_AUDIO_SAMPLE_CONTINUE;//音频状态
        var ep_stat = EpStatus.MSP_EP_LOOKING_FOR_SPEECH;//端点状态
        var rec_stat = RecogStatus.MSP_REC_STATUS_SUCCESS;//识别状态
        int errcode = (int)Errors.MSP_SUCCESS;
        int totalLength = 0;//用来记录总的识别后的结果的长度，判断是否超过缓存最大值
        if (audio_content == null)
        {
            Debug.Log("没有读取到任何内容");
            return false;
        }
        Debug.Log("开始进行语音听写.......");
        /*
        * QISRSessionBegin（）；
        * 功能：开始一次语音识别
        * 参数一：定义关键词识别||语法识别||连续语音识别（null）
        * 参数2：设置识别的参数：语言、领域、语言区域。。。。
        * 参数3：带回语音识别的结果，成功||错误代码
        * 返回值intPtr类型,后面会用到这个返回值
        */
        session_id = mscDLL.QISRSessionBegin(null, session_begin_params, ref errcode);
        if (errcode != (int)Errors.MSP_SUCCESS)
        {
            Debug.Log("开始一次语音识别失败！");
            return false;
        }
        /*
          QISRAudioWrite（）；
          功能：写入本次识别的音频
          参数1：之前已经得到的sessionID
          参数2：音频数据缓冲区起始地址
          参数3：音频数据长度,单位字节。
           参数4：用来告知MSC音频发送是否完成     MSP_AUDIO_SAMPLE_FIRST = 1	第一块音频
                                                   MSP_AUDIO_SAMPLE_CONTINUE = 2	还有后继音频
                                                    MSP_AUDIO_SAMPLE_LAST = 4	最后一块音频
          参数5：端点检测（End-point detected）器所处的状态
                                                 MSP_EP_LOOKING_FOR_SPEECH = 0	还没有检测到音频的前端点。
                                                  MSP_EP_IN_SPEECH = 1	已经检测到了音频前端点，正在进行正常的音频处理。
                                                  MSP_EP_AFTER_SPEECH = 3	检测到音频的后端点，后继的音频会被MSC忽略。
                                                   MSP_EP_TIMEOUT = 4	超时。
                                                  MSP_EP_ERROR = 5	出现错误。
                                                  MSP_EP_MAX_SPEECH = 6	音频过大。
          参数6：识别器返回的状态，提醒用户及时开始\停止获取识别结果
                                        MSP_REC_STATUS_SUCCESS = 0	识别成功，此时用户可以调用QISRGetResult来获取（部分）结果。
                                         MSP_REC_STATUS_NO_MATCH = 1	识别结束，没有识别结果。
                                       MSP_REC_STATUS_INCOMPLETE = 2	正在识别中。
                                       MSP_REC_STATUS_COMPLETE = 5	识别结束。
          返回值：函数调用成功则其值为MSP_SUCCESS，否则返回错误代码。
            本接口需不断调用，直到音频全部写入为止。上传音频时，需更新audioStatus的值。具体来说:
            当写入首块音频时,将audioStatus置为MSP_AUDIO_SAMPLE_FIRST
            当写入最后一块音频时,将audioStatus置为MSP_AUDIO_SAMPLE_LAST
            其余情况下,将audioStatus置为MSP_AUDIO_SAMPLE_CONTINUE
            同时，需定时检查两个变量：epStatus和rsltStatus。具体来说:
            当epStatus显示已检测到后端点时，MSC已不再接收音频，应及时停止音频写入
            当rsltStatus显示有识别结果返回时，即可从MSC缓存中获取结果*/
        int res = mscDLL.QISRAudioWrite(session_id, audio_content, (uint)audio_content.Length, aud_stat, ref ep_stat, ref rec_stat);
        if (res != (int)Errors.MSP_SUCCESS)
        {
            Debug.Log("写入识别的音频失败！" + res);
            return false;
        }
        res = mscDLL.QISRAudioWrite(session_id, null, 0, AudioStatus.MSP_AUDIO_SAMPLE_LAST, ref ep_stat, ref rec_stat);
        if (res != (int)Errors.MSP_SUCCESS)
        {
            Debug.Log("写入音频失败！" + res);
            return false;
        }
        while (RecogStatus.MSP_REC_STATUS_COMPLETE != rec_stat)
        {//如果没有完成就一直继续获取结果
            /*
             QISRGetResult（）；
             功能：获取识别结果
             参数1：session，之前已获得
             参数2：识别结果的状态
             参数3：waitTime[in]	此参数做保留用
             参数4：错误编码||成功
             返回值：函数执行成功且有识别结果时，返回结果字符串指针；其他情况(失败或无结果)返回NULL。
             */
            IntPtr now_result = mscDLL.QISRGetResult(session_id, ref rec_stat, 0, ref errcode);
            if (errcode != (int)Errors.MSP_SUCCESS)
            {
                Debug.Log("获取结果失败：" + errcode);
                return false;
            }
            if (now_result != null)
            {
                int length = now_result.ToString().Length;
                totalLength += length;
                if (totalLength > 4096)
                {
                    Debug.Log("缓存空间不够" + totalLength);
                    return false;
                }
                result.Append(Marshal.PtrToStringAnsi(now_result));
            }
            Thread.Sleep(150);//防止频繁占用cpu
        }
        Debug.Log("语音听写结束");
        Debug.Log("结果：\n");
        Debug.Log(result);
        mscDLL.MSPLogout();
        return true;

    }
    public static StringBuilder getResult() {
        return result;
    }
    public static void start_iat(byte[] audio_content) {
        if (init_audio()) {
            audio_iat(audio_content, session_begin_params);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
