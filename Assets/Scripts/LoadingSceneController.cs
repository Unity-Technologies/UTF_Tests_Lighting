using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

namespace ItsHarshdeep.LoadingScene.Controller
{

	public class LoadingSceneController : SceneController
	{


		public LoadingSceneController ()
		{
            LoadScene();
         
        }

		private void LoadScene ()
		{
			SceneManager.LoadSceneAsync (scene);
		}
	}

}