using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{   
    public Camera[] cameras;
    // Start is called before the first frame update
    void Start()
    {
        SwitchOffCameras();
        cameras[0].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            SwitchOffCameras();
            cameras[0].enabled = true;
        }

        if(Input.GetKey(KeyCode.Alpha2))
        {
            SwitchOffCameras();
            cameras[1].enabled = true;
        }

        if(Input.GetKey(KeyCode.Alpha3))
        {
            SwitchOffCameras();
            cameras[2].enabled = true;
        }
    }

    void SwitchOffCameras()
    {
        foreach(Camera cam in cameras)
        {
            cam.enabled = false;
        }
    }
}
