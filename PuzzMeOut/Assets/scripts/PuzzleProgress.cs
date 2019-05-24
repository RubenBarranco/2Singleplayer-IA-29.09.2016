using UnityEngine;
using System.Collections;

public class PuzzleProgress : MonoBehaviour {
	public int puzzleID;
	public bool[] pieces;
	public float[,] drawer = new float[4,2];
	public float[] cpiece;
	public float[] npiece;
    public int[] deck;
    public int maxDeckValue;
	public int myprogress;
	public int myoppprogress;
	public int r;
	public int t;
	public int a;
	public int i;

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
}
