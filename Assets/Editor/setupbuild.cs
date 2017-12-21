using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
/*
Have a look at this https://gist.github.com/meng-hui/9203445

	*/
public class setupbuild {
	public static string bundleID = "com.LigthingFTP.version560f1";
	public static string buildPath = "/Users/mykolas/FTP_Projects/_Builds/[Lighting] Mobile FTP.apk";
	public static string productName = "[Lighting] Mobile FTP";
	static string[] GetBuildScenes()
	{
		List<string> names = new List<string>();

		foreach(EditorBuildSettingsScene e in EditorBuildSettings.scenes)
		{
			if(e==null)
				continue;

			if(e.enabled)
				names.Add(e.path);
		}
		return names.ToArray();
	}

	[MenuItem("Build/Build Android")]
	static void BuildAndroid()
	{

		Debug.Log("========================================START BUILD================================================");

		//NOTE: Will not work with lower than 5.6 versions.


		//PlayerSettings.
		Debug.Log(string.Format("Switching Build Target to Android"));
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android,BuildTarget.Android);
		PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, bundleID);
		PlayerSettings.productName = productName;

		string[] scenes = GetBuildScenes();
		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		buildPlayerOptions.scenes = scenes;
		buildPlayerOptions.locationPathName = buildPath;
		buildPlayerOptions.target = BuildTarget.Android;
		buildPlayerOptions.options = BuildOptions.None;
		BuildPipeline.BuildPlayer (buildPlayerOptions);
		Debug.Log("===========================================END BUILD===============================================");

	}


}