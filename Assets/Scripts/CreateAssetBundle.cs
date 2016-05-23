using UnityEditor;
using System.IO;
using UnityEngine;

public class CreateAssetBundle {

	static string path = "./buildAssetbundles";

	[MenuItem("MJT/BuildAssetBundles")]
	static void BuildAllAssetBundles(){
		if (!Directory.Exists (path)) {
			Directory.CreateDirectory (path);
			BuildPipeline.BuildAssetBundles (path, BuildAssetBundleOptions.None, BuildTarget.Android);
		} else {
			BuildPipeline.BuildAssetBundles (path, BuildAssetBundleOptions.None, BuildTarget.Android);
		}
	}

	[MenuItem("MJT/GetAssetBundlesName")]
	static void GetNames(){
		var names = AssetDatabase.GetAllAssetBundleNames ();
		foreach (var name in names) {
			Debug.Log ("AssetBundel : " + name);
		}
	}
}
