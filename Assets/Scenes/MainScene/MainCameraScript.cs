using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using SimpleTCP;
using Assets.Scenes.Shared;
using Assets.SceneBuilders;

public class MainCameraScript : MonoBehaviour
{
    private float y = 0;
    private float z = 0;
    private float x = 0;

    bool newData = false;
    private bool renderNewData = false;
    private int numOfFrames = 0;

    //todo:: make this list as concurrent list.
    List<float> zTrajectory = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(0, 0, 0));

        ScenesEventRegister.NewSceneReceivedRegistration(HandelNewData);
        ScenesEventRegister.StartRenderCommandReceivedRegistraion(HandleStartRenderCommand);
    }

    // Update is called once per frame
    void Update()
    {
 
        x += 0.1f;

        if (renderNewData && zTrajectory.Count > 0)
        {
            if(numOfFrames == 0)
            {
                Debug.Log("Rendering new trial data");
            }

            transform.position = new Vector3(0, 0, zTrajectory[0]);
            zTrajectory.RemoveAt(0);

            numOfFrames++;
        }
        else if (renderNewData && zTrajectory.Count == 0)
        {
            renderNewData = false;
            numOfFrames = 0;
        }
    }

    private void HandleStartRenderCommand(object sender, EventArgs e)
    {
        renderNewData = true;
    }

    void HandelNewData(object sender, ISceneData e)
    {
        try
        {
            Debug.Log("Start Handling new trial data");
            for (int i = 0; i < e.Z.Count; i+=17)
            {
                zTrajectory.Add(e.X[i]);
            }

            Debug.Log("Finish Handling new trial data");

            newData = true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception with {ex.ToString()}");
        }
    }
}
