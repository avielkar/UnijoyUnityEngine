using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    private float y = 0;
    private float z = 0;
    private float x = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        x += 0.1f;
        //transform.LookAt(new Vector3(-x, 0, 0));
        transform.position = new Vector3(0, 0, -x);
    }
}
