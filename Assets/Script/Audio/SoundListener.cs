using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundListener : MonoBehaviour
{
    AudioSource _audio;
    AudioSource audio
    {
        get
        {
            if (_audio == null)
            {
                _audio = gameObject.AddComponent<AudioSource>();
            }
            return _audio;
        }
    }
    private Boolean ifStart = false;
    void Start()
    {
        string[] ms = Microphone.devices;
        deviceCount = ms.Length;
        if (deviceCount == 0)
        {
            Log("no microphone found");
        }
        else 
        {
            Log("microphone found");
            //OnGUI();
        }
    }
    void Update() {
        if (ifStart) {
            GetMaxVolume();
        }
        else {
            GameObject.Find("MICByte").transform.localScale = new Vector3(1, 0, 1);
        }
    }
    string sLog = "";
    void Log(string log)
    {
        sLog += log;
        sLog += "\r\n";
    }
    int deviceCount;
    string sFrequency = "16000";
    /*void OnGUI()
    {
        if (deviceCount > 0)
        {
            GUILayout.BeginHorizontal();
            if (!Microphone.IsRecording(null) && GUILayout.Button("Start", GUILayout.Height(Screen.height / 20), GUILayout.Width(Screen.width / 5)))
            {
                StartRecord();
            }
            if (Microphone.IsRecording(null) && GUILayout.Button("Stop", GUILayout.Height(Screen.height / 20), GUILayout.Width(Screen.width / 5)))
            {
                StopRecord();
            }
            if (!Microphone.IsRecording(null) && GUILayout.Button("Play", GUILayout.Height(Screen.height / 20), GUILayout.Width(Screen.width / 5)))
            {
                PlayRecord();
            }
            if (!Microphone.IsRecording(null) && GUILayout.Button("Print", GUILayout.Height(Screen.height / 20), GUILayout.Width(Screen.width / 5)))
            {
                PrintRecord();
            }
            sFrequency = GUILayout.TextField(sFrequency, GUILayout.Width(Screen.width / 5), GUILayout.Height(Screen.height / 20));
            GUILayout.EndHorizontal();
        }
        GUILayout.Label(sLog);
    }*/
    public void StartRecord()
    {
        ifStart = true;
        audio.Stop();
        audio.loop = false;
        audio.mute = true;
        audio.clip = Microphone.Start(null, false, 10, int.Parse(sFrequency));
        while (!(Microphone.GetPosition(null) > 0))
        {
        }
        audio.Play();
        Log("StartRecord");
    }
    public void StopRecord()
    {
        ifStart = false;
        if (!Microphone.IsRecording(null))
        {
            return;
        }
        Microphone.End(null);
        audio.Stop();
    }
    void PrintRecord()
    {
        if (Microphone.IsRecording(null))
        {
            return;
        }
        byte[] data = GetClipData();
        string slog = "total length:" + data.Length + " time:" + audio.time;
        Log(slog);
    }
    public void PlayRecord()
    {
        if (Microphone.IsRecording(null))
        {
            return;
        }
        if (audio.clip == null)
        {
            return;
        }
        audio.mute = false;
        audio.loop = false;
        audio.Play();
    }
    public byte[] GetClipData()
    {
        if (audio.clip == null)
        {
            Debug.Log("GetClipData audio.clip is null");
            return null;
        }

        float[] samples = new float[audio.clip.samples];

        audio.clip.GetData(samples, 0);


        byte[] outData = new byte[samples.Length * 2];

        int rescaleFactor = 32767;

        for (int i = 0; i < samples.Length; i++)
        {
            short temshort = (short)(samples[i] * rescaleFactor);

            byte[] temdata = System.BitConverter.GetBytes(temshort);

            outData[i * 2] = temdata[0];
            outData[i * 2 + 1] = temdata[1];


        }
        if (outData == null || outData.Length <= 0)
        {
            Debug.Log("GetClipData intData is null");
            return null;
        }
        return outData;
    }
    float GetMaxVolume()
    {
        float maxVolume = 0f;
        float[] volumeData = new float[120];
        int offset = Microphone.GetPosition(Microphone.devices[0]) - 120 + 1;
        if (offset < 0)
        {
            return 0;
        }
        audio.clip.GetData(volumeData, offset);

        for (int i = 0; i < 120; i++)
        {
            //float tempMax = volumeData[i] * volumeData[i];//修改麦克风对声音的敏感度可以自行调整，，，想不敏感就乘volumeData[i]就行了，反之就去掉

            //这个if是用来取记录的音频的一部分   和你所加的物体有关  下面有效果图展示
            if (i % 4 == 0)
            {
                //f = i / 4;
                GameObject.Find("MICByte").transform.localScale = new Vector3(1, (volumeData[i])+0.2f, 1);//将可视化的物体和音波相关联
            }
        }
        return maxVolume;
    }

}
