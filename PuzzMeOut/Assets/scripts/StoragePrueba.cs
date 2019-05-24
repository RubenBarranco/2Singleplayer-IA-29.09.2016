using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using SimpleJSON;
using AssemblyCSharp;

public class StoragePrueba : MonoBehaviour {
	ServiceAPI sp = null;
	StorageService storageService = null;
	string dbName = "Test";
	string collectionName = "NewCollection";
	StorageResponse callBack = new StorageResponse ();
	JSONClass json = new JSONClass();
	string msg = "empty";
	
	Dictionary <string, object> jsonDoc = new Dictionary <string,object>();  

	// Use this for initialization
	void Start () {
        sp = new ServiceAPI("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
	}
	void OnMouseUpAsButton () {
		storageService = sp.BuildStorageService (); // Initializing Storage Service
		//storageService.UpdateDocumentByKeyValue (dbName, collectionName, key, value, jsonDoc, callBack);
		storageService.InsertJSONDocument (dbName, collectionName, json, callBack);
		Debug.Log ("La partida ha sido guardada.");
	}
}
