using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using System.Threading;

public class TouchManager : MonoBehaviour
{

	public Camera cam;
	public GameObject back;
	public GameObject shop;
	public GameObject chart;
	public GameObject cart;
	//public GameObject m1;
	private bool isClickCube = false;
	private RaycastHit hit;
	private RaycastHit hit2;
	private bool isHit = false;
	private GameObject selectComponent = null;
	private GameObject currentComponent = null;
	private Vector3 loc,rot;
	private GameObject par;
	private AudioSource _audioSource = null;
	//private string[] inf = new string[3];


	public void search(string s)
	{
		//Debug.Log(s);
		/*int a = s.IndexOf("food");
		if (a != -1)
		{
			int b = 10 * (s[a + 5] - '0') + s[a + 6] - '0';
			Debug.Log(b);
			data(b, s);
		}*/
		data(Shopping.getPrice(s), s);
	}


	private void data(float num, string s)
	{
		/*
		switch (num)
		{
			case 1: inf[0] = "";

		}
		*/
		GameObject m1 = GameObject.Find("Text2");
		Debug.Log(m1.name);
		Debug.Log(s);
		m1.GetComponent<Text>().text = Shopping.GetGoodName(s);
		GameObject m2 = GameObject.Find("Text");
		m2.GetComponent<Text>().text = num + "元";
	}




	private void Update()
	{

		//currentComponent = null;高光显示
		if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit2, 100f))
		{
			currentComponent = hit2.collider.gameObject;
			if (currentComponent != selectComponent)
			{
				if (selectComponent != null)
					if (selectComponent.GetComponent<HighlightableObject>() != null)
						Destroy(selectComponent.GetComponent<HighlightableObject>());

				selectComponent = currentComponent;

				if (selectComponent.GetComponent<HighlightableObject>() == null)
					selectComponent.AddComponent<HighlightableObject>();

				if (selectComponent.GetComponent<HighlightableObject>() != null)
					selectComponent.GetComponent<HighlightableObject>().ConstantOn(Color.yellow);




			}
		}




		//左键点击拾取物品
		if (!Input.GetKey(KeyCode.Q)&&Input.GetMouseButton(0))
		{
			if (isClickCube == false)
			{
				isHit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100f);
				if (hit.collider.gameObject.name.IndexOf("food") > 0)
				{

					isClickCube = true;
					loc = hit.collider.gameObject.transform.position;
					rot = hit.collider.gameObject.transform.eulerAngles;
					par = hit.collider.gameObject.transform.parent.gameObject;

					Debug.Log(hit.collider.gameObject.transform.name);
					string majorname = hit.collider.gameObject.transform.name.Replace("（", "(").Replace("）", ")");
					majorname = Regex.Replace(majorname.Replace("（", "(").Replace("）", ")"), @"\([^\(]*\)", "");
					majorname = majorname.Trim();
					search(majorname);   //强制类型转换有问题
					back.GetComponent<AnimationControl>().open();
					//Debug.Log(this.transform.parent.transform.parent.transform.parent.name);
					//拾取物体 固定相机视角 允许物体转动
					MoveTo.IsMove = false;
					hit.collider.gameObject.AddComponent<ScanItem>();
				}
				else 
				{
					isHit = false;
				}
			}
		}

		if (isClickCube)
		{
			if (isHit)
			{
				//hit.collider.gameObject.SendMessage("OnTouched", this.gameObject ,SendMessageOptions.DontRequireReceiver);  
				if (!Input.GetKey(KeyCode.Q))
				{
					hit.collider.gameObject.transform.parent = this.transform;
					hit.collider.gameObject.transform.localPosition = new Vector3(0.2F, 0F, 0.7F);
				}
				//hit.collider.gameObject.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position, new Vector3(0.2F, 0F, 0.7F), Time.time);
				//按Q将商品加入购物车
				if (Input.GetKeyDown(KeyCode.Q))
				{
					//将商品信息存入购物清单
					string majorname = hit.collider.gameObject.transform.name.Replace("（", "(").Replace("）", ")");
					majorname = Regex.Replace(majorname.Replace("（", "(").Replace("）", ")"), @"\([^\(]*\)", "");
					//Debug.Log(majorname);
					majorname = majorname.Trim();
					Shopping.UpdateShopping(majorname);
					Shopping.tostring();
					GameObject.Destroy(hit.collider.gameObject, 0.5f);
					//hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0F, -0.1F, 0F));
					hit.collider.gameObject.GetComponent<Rigidbody>().MovePosition(cart.transform.position);
					isClickCube = false;
					back.GetComponent<AnimationControl>().close();
				}
			}

		}
		//左键抬起放下物品
		if (!Input.GetKey(KeyCode.Q)&&Input.GetMouseButtonUp(0))
		{
			if (isClickCube)
			{
				isClickCube = false;
				hit.collider.gameObject.transform.parent = par.transform;
				hit.collider.gameObject.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position,loc, 1.0f);
				hit.collider.gameObject.transform.eulerAngles = rot;
				hit.collider.gameObject.GetComponent<Rigidbody>().GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
				back.GetComponent<AnimationControl>().close();
				//放下物体，允许相机移动 并移除物体移动组件
				MoveTo.IsMove = true;
				Destroy(hit.collider.gameObject.GetComponent<ScanItem>());
			}

		}
		//按下B查看购物清单
		if (Input.GetKeyDown(KeyCode.B)) {
			shop.GetComponent<ShoppingUIControl>().open();
		}
		if (Input.GetKeyUp(KeyCode.B)) {
			shop.GetComponent<ShoppingUIControl>().close();
		}
		//按E录音，最长10s
		//if (Input.GetKeyDown(KeyCode.E)) {
		//	gameObject.GetComponent<SoundListener>().StartRecord();
		//	/**优化交互界面*/
		//    _audioSource = gameObject.AddComponent<AudioSource>();
		//	//加载 Audio Clip 对象
		//	AudioClip audioClip = Resources.Load<AudioClip>("wav/skype");
		//	//播放声音
		//	_audioSource.clip = audioClip;
		//	_audioSource.Play(0);
		//	GameObject.Find("MICImage").GetComponent<Image>().sprite = Resources.Load("icon/microphone2", typeof(Sprite)) as Sprite;
		//}
		//if (Input.GetKeyUp(KeyCode.E)) {
		//	gameObject.GetComponent<SoundListener>().StopRecord();
		//	_audioSource = gameObject.GetComponent<AudioSource>();
		//	//加载 Audio Clip 对象
		//	AudioClip audioClip = Resources.Load<AudioClip>("wav/skype");
		//	_audioSource.clip = audioClip;
		//	_audioSource.Play(0);
		//	//gameObject.GetComponent<SoundListener>().PlayRecord();
		//	//调用讯飞SDK进行语音文字转换
		//	Audio_iat.start_iat(gameObject.GetComponent<SoundListener>().GetClipData());
		//	Debug.Log(Audio_iat.getResult().ToString());
		//	/**优化交互界面*/
		//	GameObject.Find("Chart/Background/Image/Chartword").GetComponent<Text>().text = Audio_iat.getResult().ToString();
		//	chart.GetComponent<ChartControl>().open();
		//	GameObject.Find("MICImage").GetComponent<Image>().sprite = Resources.Load("icon/microphone", typeof(Sprite)) as Sprite;
		//	Destroy(gameObject.GetComponent<AudioSource>());
		//	Invoke("closechart", 7.0f);
		//	///此处可添加UGUI交互界面
		//	///UGUI交互界面代码(){
		//	///
		//	///}
		//	//根据得到的文字导航
		//	if(!AudioNav.instance.StartNavgate(Audio_iat.getResult().ToString()))
		//		Debug.Log("本店没有此类商品 爬！！");
		//}
	}

	private void closechart() {
		chart.GetComponent<ChartControl>().close();
	}
}