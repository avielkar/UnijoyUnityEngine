using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using SimpleTCP;

public class MainCameraScript : MonoBehaviour
{
    private float y = 0;
    private float z = 0;
    private float x = 0;
    bool sendConnectionRequest = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(sendConnectionRequest)
        {
            sendConnectionRequest = false;
            Debug.Log("Client sends a connection request...");
            var client = new SimpleTcpClient().Connect("127.0.0.1", 8910);
        }

        x += 0.1f;
        //transform.LookAt(new Vector3(-x, 0, 0));
        transform.position = new Vector3(0, 0, -x);
    }
}
