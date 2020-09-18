using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 灯光报警的控制
public class LightAlarm : MonoSingleton<LightAlarm>
{
    #region 定义字段
    public Color LightColor;
    // 警报灯光组件
    private Light m_alarmLight;
    // 灯光的最强亮度
    public float m_highIntensity = 10.0f;
    private float m_weakIntensity = 1.0f;
    // 灯光的最低强度
    private float m_lowIntensity = 0f;
    // 目标灯光强度
    private float m_targetIntensity = 0f;
    // 灯光切换的速度
    private float m_turnSpeed = 5.0f;
    // 计时器
    private float timer = 3f;
    // 关闭报警器标识符
    private bool isOpen;
    #endregion

    #region Unity回调
    protected override void Awake()
    {
        base.Awake();
        // 初始化灯光组件
        m_alarmLight = transform.GetComponent<Light>();
        // 先让目标灯光和最低灯光强度相等
        m_targetIntensity = m_lowIntensity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            // 灯光的灯光强度 = 灯光警报的强度
            m_alarmLight.intensity =
             Mathf.Lerp(m_alarmLight.intensity,
              m_targetIntensity, Time.deltaTime * m_turnSpeed);

            if (Mathf.Abs
                (m_alarmLight.intensity - m_targetIntensity) < 0.01f)
            {
                // 如果当前灯光是最大强度光，让它等于最低强度光
                if (m_targetIntensity == m_highIntensity)
                {
                    m_targetIntensity = m_weakIntensity;

                }
                else
                {
                    // 如果当前是最低灯光，那么让它等于最高
                    m_targetIntensity = m_highIntensity;
                }
            }
            m_alarmLight.color = LightColor;
        }
        else if (isOpen == false)
        {
            m_alarmLight.intensity = 0f;
        }
    }
    #endregion
    #region 灯光变化的方法
    // 开启警报灯光
    public void OpenAlarmLight()
    {
        isOpen = true;
    }
    // 关闭灯光报警器
    public void CloseAlarmLight()
    {
        isOpen = false;
    }
    #endregion
}
