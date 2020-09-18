using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Talking : MonoBehaviour
{
	public GameObject chart;
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.E))
		{
			gameObject.GetComponent<SoundListener>().StartRecord();
			/**优化交互界面*/
			gameObject.GetComponent<AudioSource>().Play();
			//加载 Audio Clip 对象
			//AudioClip audioClip = Resources.Load<AudioClip>("wav/skype");
			//播放声音
			//_audioSource.clip = audioClip;
			//_audioSource.Play(0);
			GameObject.Find("MICImage").GetComponent<Image>().sprite = Resources.Load("icon/microphone2", typeof(Sprite)) as Sprite;
		}
		if (Input.GetKeyUp(KeyCode.E))
		{
			gameObject.GetComponent<SoundListener>().StopRecord();
			//_audioSource = gameObject.GetComponent<AudioSource>();
			//加载 Audio Clip 对象
			//AudioClip audioClip = Resources.Load<AudioClip>("wav/skype");
			//_audioSource.clip = audioClip;
			gameObject.GetComponent<AudioSource>().Play();
			//gameObject.GetComponent<SoundListener>().PlayRecord();
			//调用讯飞SDK进行语音文字转换
			Audio_iat.start_iat(gameObject.GetComponent<SoundListener>().GetClipData());
			Debug.Log(Audio_iat.getResult().ToString());
			/**优化交互界面*/
			GameObject.Find("Chart/Background/Image/Chartword").GetComponent<Text>().text = Audio_iat.getResult().ToString();
			chart.GetComponent<ChartControl>().open();
			GameObject.Find("MICImage").GetComponent<Image>().sprite = Resources.Load("icon/microphone", typeof(Sprite)) as Sprite;
			Invoke("closechart", 7.0f);
			///此处可添加UGUI交互界面
			///UGUI交互界面代码(){
			///
			///}
			//根据得到的文字导航
			if (!AudioNav.instance.StartNavgate(Audio_iat.getResult().ToString()))
				Debug.Log("本店没有此类商品 爬！！");
		}
	}
	private void closechart()
	{
		chart.GetComponent<ChartControl>().close();
	}
}
