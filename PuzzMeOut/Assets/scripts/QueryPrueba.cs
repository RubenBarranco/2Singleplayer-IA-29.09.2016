using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using SimpleJSON;
using AssemblyCSharp;

public class QueryPrueba : MonoBehaviour {
	ServiceAPI sp = null;
	public static string fgs = null;
	StorageService storageService = null;
	string dbName = "Test";  
	string collectionName = "NewCollection";  
	string objectId = "540f4961e4b055863ddf02b9";
	StorageResponse callBack = new StorageResponse ();

	// Use this for initialization
	void Start () {
        sp = new ServiceAPI("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
	}
	void Update (){
		//fgs = StorageResponse.fg;
	}
	
	void OnMouseUpAsButton () {
		storageService = sp.BuildStorageService (); // Initializing Storage Service.
		storageService.FindDocumentById (dbName, collectionName, fgs, callBack);
		Debug.Log ("Archivo encontrado.");
	}
}
