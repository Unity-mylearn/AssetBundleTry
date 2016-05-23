using UnityEngine;
using System.Collections;
using System.IO;

public class PManager : MonoBehaviour {

	[SerializeField]
	private Material plane;
	[SerializeField]
	private Material plane2;

	private Texture2D currentTexture;

	[SerializeField]
	private int totalCount;
	private int currentNum = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator LoadTexture(){
		if (currentNum > totalCount) {
			currentNum = 1;
		}
		var bundleLoadRequest = AssetBundle.LoadFromFileAsync ("./buildAssetbundles/pets.pet");
		yield return bundleLoadRequest;

		var loadassetbundle = bundleLoadRequest.assetBundle;
		if (loadassetbundle == null) {
			Debug.Log ("Failed to load AssetBundle!");
			yield break;
		}
		var assetLoadRequest = loadassetbundle.LoadAssetAsync<Texture> ("p"+currentNum);
		yield return assetLoadRequest;
		currentTexture = assetLoadRequest.asset as Texture2D;
		if (currentTexture != null) {
			currentNum++;
			plane.SetTexture ("_MainTex", currentTexture);
			plane2.SetTexture ("_MainTex", currentTexture);
		}
		loadassetbundle.Unload (false);
	}
		
	public void OnNextClick(){
		StartCoroutine (LoadTexture ());
	}

	void OnDestroy() {
		plane.SetTexture ("_MainTex", new Texture2D(100,100));
		plane2.SetTexture ("_MainTex", new Texture2D (100, 100));
	}
}
