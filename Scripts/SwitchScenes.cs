using UnityEngine;
using System.Collections;

public class SwitchScenes : MonoBehaviour 
{

	void Start()
	{
		GameObject.DontDestroyOnLoad(this);
	}
	void OnGUI()
	{
		if (GUILayout.Button("Next scene"))
			Application.LoadLevel((Application.loadedLevel + 1) % Application.levelCount);
	}
}
