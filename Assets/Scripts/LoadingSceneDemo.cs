using UnityEngine;
using System.Collections;

//Add following header files
using ItsHarshdeep.LoadingScene.Constants;
using ItsHarshdeep.LoadingScene.Controller;

public class LoadingSceneDemo : MonoBehaviour
{
	public bool requiredCustomDelay = true;


	public void LoadScene (string sceneName)
	{
		if (requiredCustomDelay)
			SceneController.LoadLevel (sceneName, 1.5f);
		else
			SceneController.LoadLevel (sceneName);
			
		print ("Previous Scene name was : " + SceneController.previousScene);
	} 

	public void LoadPreviousScene ()
	{

        SceneController.LoadPreviousScene();

	}

}
