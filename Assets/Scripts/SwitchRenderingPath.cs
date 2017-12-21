using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class SwitchRenderingPath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchToDeferred()
    {
        Camera.main.renderingPath = RenderingPath.DeferredShading;
    }

    public void SwitchToForward()
    {
        Camera.main.renderingPath = RenderingPath.Forward;
    }
}
