using UnityEngine;
using System.Collections;

public class BotonesSmartphone : MonoBehaviour {
	public GameObject SmartphoneButtons;
    public GameObject ScrollView;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Application.platform == RuntimePlatform.Android) {
                if (Application.loadedLevel == 1)
                {
                    ScrollView.SetActive(false);
                }
                    SmartphoneButtons.SetActive(true);
			}
		}
	}
	public void Yes () {
		Application.Quit ();
	}
	public void No () {
        ScrollView.SetActive(true);
		SmartphoneButtons.SetActive (false);
	}
	}
