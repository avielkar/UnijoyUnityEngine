using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using SimpleTCP;
using Assets.Scenes.Shared;
using Assets.SceneBuilders;

public class MainCameraScript : MonoBehaviour
{
    bool _newData = false;
    private bool _renderNewData = false;
    private int _numOfFrames = 0;

    //todo:: make this list as concurrent list.
    List<float> _zTrajectory = new List<float>();

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
        if (_renderNewData && _zTrajectory.Count > 0)
        {
            if(_numOfFrames == 0)
            {
                Debug.Log("Rendering new trial data");
            }

            transform.position = new Vector3(0, 0, _zTrajectory[0]);
            _zTrajectory.RemoveAt(0);

            _numOfFrames++;
        }
        else if (_renderNewData && _zTrajectory.Count == 0)
        {
            _renderNewData = false;
            _numOfFrames = 0;
        }
    }

    private void HandleStartRenderCommand(object sender, EventArgs e)
    {
        _renderNewData = true;
    }

    void HandelNewData(object sender, ISceneData e)
    {
        try
        {
            Debug.Log("Start Handling new trial data");
            for (int i = 0; i < e.Z.Count; i+=17)
            {
                _zTrajectory.Add(e.X[i]);
            }

            Debug.Log("Finish Handling new trial data");

            _newData = true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception with {ex.ToString()}");
        }
    }
}
