using UnityEngine;
using System.Collections;

public class Pieces : MonoBehaviour {
	
	public int id;
	public Texture idimage;
	public Puzzles puzzle;
	public Currentpiece cpiece;
	public Nextpiece cajon;
	// Use this for initialization
	void Start () {
	
	}
	/*void OnMouseUpAsButton (){
		if (id == cpiece.id && (cpiece.transform.rotation.y==0 || cpiece.transform.rotation.y==9.659346e-06)) {
						puzzle.pieces [id].renderer.material.mainTexture = cpiece.idimage;
			Debug.Log("Yes!");
		} else {
			if(cajon.container<cajon.rpieces.Length-1){
			cajon.container++;	
			}
			cajon.rpieces[cpiece.id] = cpiece.id;
			Debug.Log("Nah");
		}
	}*/

	// Update is called once per frame
	void Update () {
	
	}
}
