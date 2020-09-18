using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class StartListen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SocketServer Server = new SocketServer(100);
        Server.StartListen();
        //SocketClient Client = new SocketClient(8888);
        //Client.StartClient();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
