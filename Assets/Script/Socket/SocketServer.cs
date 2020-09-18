using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Globalization;

public class SocketServer : MonoBehaviour
{
    private string _ip = string.Empty;
    static private string T = "...";
    static private string H = "...";
    private int _port = 0;
    private Socket _socket = null;
    private byte[] buffer = new byte[1024 * 1024 * 2];
    public GameObject leftdoor1;
    public GameObject rightdoor1;
    static private Boolean IsEntry = false,EntryNow = false;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="ip">监听的IP</param>
    /// <param name="port">监听的端口</param>
    public SocketServer(string ip, int port)
    {
        this._ip = ip;
        this._port = port;
    }
    public SocketServer(int port)
    {
        this._ip = "10.5.24.96";
        this._port = port;
    }

    public void StartListen()
    {
        try
        {
            //1.0 实例化套接字(IP4寻找协议,流式协议,TCP协议)
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2.0 创建IP对象
            IPAddress address = IPAddress.Parse(_ip);
            //3.0 创建网络端口,包括ip和端口
            IPEndPoint endPoint = new IPEndPoint(address, _port);
            //4.0 绑定套接字
            _socket.Bind(endPoint);
            //5.0 设置最大连接数
            _socket.Listen(int.MaxValue);
            Debug.Log("监听" + _socket.LocalEndPoint.ToString() + "消息成功");
            //6.0 开始监听
            Thread thread = new Thread(ListenClientConnect);
            thread.Start();

        }
        catch (Exception ex)
        {
        }
    }
    /// <summary>
    /// 监听客户端连接
    /// </summary>
    private void ListenClientConnect()
    {
        try
        {
            while (true)
            {
                //Socket创建的新连接
                Socket clientSocket = _socket.Accept();
                clientSocket.Send(Encoding.UTF8.GetBytes("服务端发送消息:"));
                Thread thread = new Thread(ReceiveMessage);
                thread.Start(clientSocket);
                thread.Join();
            }
        }
        catch (Exception)
        {
        }
    }

    /// <summary>
    /// 接收客户端消息
    /// </summary>
    /// <param name="socket">来自客户端的socket</param>
    private void ReceiveMessage(object socket)
    {
        Socket clientSocket = (Socket)socket;
        try
        {
            //获取从客户端发来的数据
            int length = clientSocket.Receive(buffer);
            Debug.Log("接收客户端" + clientSocket.RemoteEndPoint.ToString() + ",消息" + Encoding.UTF8.GetString(buffer, 0, length) + "");
            string res = Encoding.UTF8.GetString(buffer, 0, length);
            string[] ress = res.Split('#');
            if (ress[0].CompareTo("1") == 0)
            {
                T = ress[1];
                H = ress[2];
            }
            else if (ress[0].CompareTo("2") == 0) {
                //进门动画,多线程并发执行
                //Thread t_entry = new Thread(Entry);
                //t_entry.Start();
                //t_entry.Join();
                //Move1.instance.ControllDoor("entry");
                //Entry();
                if (!IsEntry)
                    EntryNow = true;
            }
            //GameObject.Find("TemperatureText").GetCompoent<Text>().text = ress[0];
            //GameObject.Find("HumidityText").GetCompoent<Text>().text = ress[1];
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
    void OnGUI()
    {
        //Debug.Log(T);
        GUI.Label(new Rect(10, 25, 100, 120), "温度：" + T);
        GUI.Label(new Rect(10, 40, 100, 120), "湿度: " + H);
        GUI.Label(new Rect(10, 370, 100, 120), DateTime.Now.ToLongTimeString().ToString());
        //GUI.Label(Rect(10, 40, textureToDisplay.width, textureToDisplay.height), textureToDisplay);
    }
    void Update() {
        //T = "123";
        //Debug.Log("进门");
        Debug.Log("IsEntry:"+IsEntry);
        Debug.Log("EntryNow:" + EntryNow);
        if (/*Input.GetKeyDown(KeyCode.P)*/!IsEntry&&EntryNow)
        {
            // Open();
            Entry();

        }
        //OnGUI();
    }

    void Start()
    {
        leftdoor1 = GameObject.FindWithTag("leftdoor");
        rightdoor1 = GameObject.FindWithTag("rightdoor");
    }

    void Close()
    {
        leftdoor1.GetComponent<leftControll>().close();
        rightdoor1.GetComponent<rightControll>().close();
    }
    void Entry() {
        Debug.Log("进门");
        leftdoor1.GetComponent<leftControll>().open();
        rightdoor1.GetComponent<rightControll>().open();
        Move1.instance.ControllDoor("entry");
        Invoke("Close", 10f);
        IsEntry = true;
    }
}