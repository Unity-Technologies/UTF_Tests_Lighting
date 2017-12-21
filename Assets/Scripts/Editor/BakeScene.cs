using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public class BakeScene: MonoBehaviour
{
	public static bool debug = false;
	
	[MenuItem("QA/Lightmaps/Bake Build Settings Scenes", false, 1200)]
	private static void BakeBuild()
	{
		
		if (EditorUtility.DisplayDialog("Bake Build Settings Scenes?", "Bake Build Settings Scenes?", "Yes", "No"))
		{
			Debug.Log("Starting Batch Bake...");
			AssetDatabase.SaveAssets();
			
			EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
			
			foreach (EditorBuildSettingsScene scn in scenes)
			{
				Debug.Log("Baking: " + scn.path);
				EditorSceneManager.OpenScene(scn.path);
				
				//CLEAR THE LIGHTMAPS AND THE CACHE
				//THIS IS AN ATTEMPT TO PREVENT SYSTEM HANGS SEE
				//http://forum.unity3d.com/threads/bake-runtime-job-failed-with-error-code-11-failed-reading-albedo-texture-file.326474/
				Lightmapping.Clear();
				Lightmapping.ClearDiskCache();
				
				watch.Reset();
				watch.Start();
				
				Lightmapping.Bake();
				
				//Stop the timer
				watch.Stop();
				
				EditorApplication.SaveScene();
				
				Debug.Log("Finished Bake Time: " + watch.Elapsed.TotalMinutes.ToString() + " Scene: " + scn.path);
			}
			
			Debug.Log("Finished Batch Bake.");
		}
	}
	
	
}