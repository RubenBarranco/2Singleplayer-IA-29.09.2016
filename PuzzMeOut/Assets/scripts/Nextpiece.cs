using UnityEngine;
using System.Collections;

public class Nextpiece : MonoBehaviour {
	public int id;
	public int [] rpieces;
	public Material[] texpieces;
	public int container;
	int randomNumber;
	float crot;
	bool firstround=true;
	public Currentpiece cpiece;
	int aux;
	// Use this for initialization
	void Start () {
		container = rpieces.Length - 1;
		npiece ();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.S)){
			npiece ();
		}


	}
	public void npiece () {
		if (!firstround) {
			sendcpiece ();

		}
		int rot=Random.Range (0, 4);
		transform.eulerAngles = new Vector3 (0,0,0);

		switch (rot) {
		case 0:
			transform.Rotate (0f,0f,0f);
			crot=0f;
		break;	

		case 1:
			transform.Rotate (0f,90f,0f);
			crot=90f;
		break;
		
		case 2:
			transform.Rotate (0f,180f,0f);
			crot=180f;
			break;
		case 3:
			transform.Rotate (0f,270f,0f);
			crot=270f;
			break;
		}



		
		randomNumber = (int) Random.Range (0.0f , (float) container);
		aux = rpieces[randomNumber];
		renderer.material=texpieces[aux];
		rpieces [randomNumber] = rpieces [container];
		container = container - 1;
		id = aux;

		firstround=false;
		Debug.Log ("nexpiece number " + id);
		Debug.Log ("currentpiece number " + cpiece.id);
	}

	void sendcpiece(){
		cpiece.id = id;
		cpiece.renderer.material = texpieces [aux];
		cpiece.transform.eulerAngles = new Vector3 (0, 0, 0);
		cpiece.transform.Rotate (0f, crot, 0f);
	}

}