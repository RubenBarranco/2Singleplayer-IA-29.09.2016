using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using com.shephertz.app42.paas.sdk.csharp.user;
using SimpleJSON;
using AssemblyCSharp;

public class infoPlayer : MonoBehaviour
{
    public string jugador;
    public string oponente;
    public string idplayer;
    public string idplayer2;
    public string idjson;
    public string yourIdJson;
    public string groupURL;
    public string topicURL;
    public string host;
    public string aQuienLeTOCA;
    public PuzzleProgress puzzles;
    public int partidasactivas;
    public int puzzle;
    public bool alreadyBegun;
}