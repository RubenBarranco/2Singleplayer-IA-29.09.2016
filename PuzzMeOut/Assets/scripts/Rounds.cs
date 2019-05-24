using UnityEngine;
using System.Collections;

public class Rounds : MonoBehaviour {
	public int round;
	public int turn;
	public string[] Pnames = {"Player 1", "Player 2"};
	public int firstplayer;
	public int totalplayers;
	public string currentplayer;
	public Nextpiece npiece;

	// Use this for initialization
	void Start () {
		Debug.Log ("The match has started");
		firstplayer = (int)(Random.Range (0, totalplayers));
		currentplayer = Pnames [firstplayer];
		turn = turn + 1;
		Debug.Log ("Its your turn " + currentplayer);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)){
			Endturn ();
		}
	}

	void Endturn () {
		Debug.Log (currentplayer + "'s turn has finished.");
		if (firstplayer + 1 != totalplayers) {
			firstplayer = firstplayer + 1;
			} else {
			firstplayer = 0;
			}
		currentplayer = Pnames [firstplayer];
		turn = turn + 1;
		round = (turn -1) / 2;
		Debug.Log ("Its your turn " + currentplayer);

	}
}
