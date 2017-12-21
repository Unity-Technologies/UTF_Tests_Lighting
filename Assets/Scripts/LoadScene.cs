using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadScene : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}


    public void LoadNextScene(string name)
    {
        SceneManager.LoadScene(name);
    }




}
