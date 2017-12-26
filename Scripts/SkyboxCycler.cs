using UnityEngine;
using System.Collections;

public class SkyboxCycler : MonoBehaviour {

	public Material[] skyboxes;
	public int currentSkybox = 0;

	void OnGUI()
	{
		if(GUI.Button(new Rect(0,30,100,50),"Change skybox"))
		{
			currentSkybox=(currentSkybox+1)%skyboxes.Length;
			RenderSettings.skybox = skyboxes[currentSkybox];
			DynamicGI.UpdateEnvironment();
		}
	}



}
