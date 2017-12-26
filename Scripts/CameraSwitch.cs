using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public Camera camera1;
    public Camera camera2;
    public Camera camera3;

    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = 0;
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        startTime++;

        if(startTime>=0 && startTime < 250)
        {
            Camera1();
            
        }else if(startTime >= 250 && startTime <= 500)
        {
            Camera2();
        }
        else if(startTime>= 500 && startTime <= 750)
        {
            Camera3();
        }
        else
        {
            startTime = 0;
        }
	}


    void Camera1()
    {
        camera1.enabled = true;
        camera2.enabled = false;
        camera3.enabled = false;
    }

    void Camera2()
    {
        camera1.enabled = false;
        camera2.enabled = true;
        camera3.enabled = false;
    }

    void Camera3()
    {
        camera1.enabled = false;
        camera2.enabled = false;
        camera3.enabled = true;
    }
}
