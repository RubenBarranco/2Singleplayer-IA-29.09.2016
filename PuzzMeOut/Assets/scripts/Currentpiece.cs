using UnityEngine;
using System.Collections;

public class Currentpiece : MonoBehaviour {
	public int id;
	public Texture idimage;
	public Nextpiece np;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnMouseUpAsButton(){

		transform.Rotate (0f,90f,0f);

	}
}