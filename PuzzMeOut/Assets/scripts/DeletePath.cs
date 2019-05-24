using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
public class DeletePath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void deletePath(){
		File.Delete (Application.persistentDataPath + "/playerInfo.dat");
		Application.LoadLevel ("Main");

	}
}
