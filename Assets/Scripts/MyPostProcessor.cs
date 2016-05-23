using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyPostProcessor : AssetPostprocessor {

	void OnPostprocessAssetbundleNameChanged(string path,string previous,string next){
		Debug.Log("AB: " + path + " old: " + previous + " new: " + next);
	}
}
