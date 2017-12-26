using UnityEngine;
using System.Collections;
using ItsHarshdeep.LoadingScene.Constants;

using UnityEngine.SceneManagement;


namespace ItsHarshdeep.LoadingScene.Controller
{
	public class SceneController
	{

		public static string scene = "";
		public static string previousScene = ""; 


		public static void LoadLevel (string sceneName, float loadingSceneWaitTime = 0)
		{
			Constants.Constants.LOADING_SCENE_WAIT_TIME = loadingSceneWaitTime;
			previousScene = SceneManager.GetActiveScene ().name;

			scene = sceneName;

			SceneManager.LoadSceneAsync (Constants.Constants.LOADING_SCENE_NAME);
		}

		public static void LoadPreviousScene (float loadSceneDelayTime = 0)
		{
			if (previousScene == null || previousScene.TrimEnd ().ToString () == "")
				Debug.LogError ("There is currently no any previous scene yet");
			else 
				LoadLevel (previousScene, loadSceneDelayTime);
		}
	}
}