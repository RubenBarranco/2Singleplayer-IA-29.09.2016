using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SocialPlatforms;
using System;
using System.IO;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using com.shephertz.app42.paas.sdk.csharp.user;
using com.shephertz.app42.paas.sdk.csharp.message;
using KiiCorp.Cloud.Unity;
using KiiCorp.Cloud.Storage;
using SimpleJSON;
using AssemblyCSharp;
using StartApp;

public class matchList : MonoBehaviour
{
    public UILabel AppVersion;
    public UIButton search;
    public UILabel searching;
    public AnimatedAlpha screenAlpha;
    bool check = false;
    bool check2 = false;
    bool check3 = false;
    bool check4 = false;
    bool check5 = false;
    bool check6 = false;
    public bool matchFound = false;
    public bool upLoadScene = false;
    float contador1;
    float contador2;
    float contador3;
    float contador4;
    float contador5;
    float nomatch;
    float contJoin;
    string full = "true";
    public string objectUri;
    bool begin = false;
    public UILabel[] partidas;
    public GameObject scroll;
    public GameObject match;
    public GameObject UserMatches;
    public GameObject WorldMatches;
    public GameObject banner;
    public GameObject[] listaOld;
    public GameObject[] tulista;
    public GameObject[] world;
    public GameObject[] UserWorld;
    jsonPrueba getinfo = new jsonPrueba();
    public string jsonObj;
    public GameObject stats;
    infoPlayer mystats;
    public GameObject PuzzleP;
    PuzzleProgress ProgressPuzzle;
    public GameObject notfound;
    AdMobPlugin advertisement;
    float calculaHuecos;
    public bool alreadyBegun;
    public UILabel idLabel;
    public UILabel userID;
    public string idString;
    public bool joinBool;
    public string topicUri;

    //Cosas de KiiCloud
    ServiceAPI sp = null;
    StorageService storageService = null;
    MessageResponse callMessage = new MessageResponse();
    MessageResponsePO piecesMessage = new MessageResponsePO();
    QueueService queueService = null;
    public StorageResponse callBack = new StorageResponse();
    public StorageResponse callBack1 = new StorageResponse();
    public StorageResponse myDataBase = new StorageResponse();
    public StorageResponse enemyDataBase = new StorageResponse();
    public StorageResponse savedGames = new StorageResponse();
    public string idjson;
    string dbName = "Cloud";
    string collectionName = "Global";
    //Cosas del KiiCloud - Contenido del JSON en la nube
    public KiiObject [] lista = new KiiObject[100];
    string GlobalKey1 = "idjson", GlobalKey2 = "player", GlobalKey3 = "NumeroJugadores", GlobalKey4 = "PowerUps", GlobalKey5 = "TamañoDelPuzzle", GlobalKey6 = "Round", GlobalKey7 = "Turno", GlobalKey8 = "TurnoPlayer";
    string GlobalValue1 = "0", GlobalValue2 = "0", GlobalValue3 = "0", GlobalValue4 = "0", GlobalValue5 = "0", GlobalValues6 = "0", GlobalValue7 = "0", GlobalValue8 = "0";
    string gamekey1 = "jsonID", gamekey2 = "yourjsonID", gamekey3 = "casilla1", gamekey4 = "casilla2", gamekey5 = "casilla3", gamekey6 = "casilla4", gamekey7 = "casilla5", gamekey8 = "casilla6", gamekey9 = "casilla7", gamekey10 = "casilla8", gamekey11 = "casilla9", gamekey12 = "casilla10", gamekey13 = "casilla11", gamekey14 = "casilla12", gamekey15 = "casilla13", gamekey16 = "casilla14", gamekey17 = "casilla15", gamekey18 = "casilla16", gamekey19 = "cajon1", gamekey20 = "cajon2", gamekey21 = "cajon3", gamekey22 = "cajon4", gamekey23 = "actualID", gamekey24 = "nextID", gamekey25 = "deck1", gamekey26 = "deck2", gamekey27 = "deck3", gamekey28 = "deck4", gamekey29 = "deck5", gamekey30 = "deck6", gamekey31 = "deck7", gamekey32 = "deck8", gamekey33 = "deck9", gamekey34 = "deck10", gamekey35 = "deck11", gamekey36 = "deck12", gamekey37 = "deck13", gamekey38 = "deck14", gamekey39 = "deck15", gamekey40 = "deck16", gamekey41 = "rotcajon1", gamekey42 = "rotcajon2", gamekey43 = "rotcajon3", gamekey44 = "rotcajon4", gamekey45 = "rotactual", gamekey46 = "rotnext", gamekey47 = "whichplayer", gamekey48 = "turn", gamekey49 = "round", gamekey50 = "maxdeckvalue", gamekey51 = "puzzleID", gamekey52 = "myprogress", gamekey53 = "myoppprogress", gamekey54 = "Opponent", gamekey55 = "Host", gamekey56 = "AQuienLeToca";
    string key1 = "Round", key2 = "Turn", key3 = "PlayerTurn", key4 = "Full", key5 = "IDjugador2", key6 = "1", key7 = "2", key8 = "NumeroJugadores", key9 = "IDjugador1", key10 = "TamañoPuzzle", key11 = "PowerUps", key12 = "GameID";
    string value1 = "0", value2 = "0", value3 = "1", value4 = "false", value5 = "player2", value6 = "0", value7 = "0", value8 = "2", value9 = "player1", value10 = "16", value11 = "no", value12 = "0";
    string keypieces = "Pieces", keyplayersturn = "WhosTurn";
    string valuepieces = "", valueplayersturn = "";
    string validador = "false";
    public string jugador;
    public string oponente;
    public int round;
    public int turn;
    JSONClass json = new JSONClass();

    void Start()
    {
        //Se ejecuta al iniciar la aplicacion
        sp = new ServiceAPI("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
        App42API.Initialize("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
        mystats = stats.GetComponent<infoPlayer>();
        ProgressPuzzle = PuzzleP.GetComponent<PuzzleProgress>();
        mystats.puzzles = ProgressPuzzle;
        mystats.alreadyBegun = false;
        searching.text = "Searching for matches...";
        userID.text = mystats.idplayer;
        /*
        Query q2 = QueryBuilder.Build("IDjugador1", mystats.idplayer, Operator.EQUALS);
        Query q13 = QueryBuilder.Build("IDjugador2", mystats.idplayer, Operator.EQUALS);
        Query q3 = QueryBuilder.Build("1", "16", Operator.NOT_EQUALS);
        Query q4 = QueryBuilder.Build("2", "16", Operator.NOT_EQUALS);
        Query q5 = QueryBuilder.CompoundOperator(q3, Operator.OR, q4);
        Query q14 = QueryBuilder.CompoundOperator(q2, Operator.OR, q13);
        Query q6 = QueryBuilder.CompoundOperator(q5, Operator.AND, q14);
        storageService = sp.BuildStorageService();
        storageService.FindDocumentsByQuery(dbName, collectionName, q6, callBack);
        Query q1 = QueryBuilder.Build("Full", "false", Operator.EQUALS);
        Query q7 = QueryBuilder.Build("IDplayer1", mystats.idplayer, Operator.NOT_EQUALS);
        Query q10 = QueryBuilder.CompoundOperator(q1, Operator.AND, q7);
        storageService = sp.BuildStorageService();
        storageService.FindDocumentsByQuery(dbName, collectionName, q10, callBack);
        */
        StartCoroutine(waitResponseTuyas ());
        StartCoroutine(waitResponse());
        #if UNITY_ANDROID
        StartAppWrapper.init();
        StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.BOTTOM);
        #endif
        #if UNITY_IPHONE
        StartAppWrapperiOS.unityOrientation(StartAppWrapperiOS.STAUnityOrientation.STALandscape);
        StartAppWrapperiOS.addBanner(StartAppWrapperiOS.BannerPosition.BOTTOM);
        #endif
        /*
        advertisement = banner.GetComponent<AdMobPlugin>();
        advertisement.Reconfigure();
         */
    }

    void Update()
    {
        //Vincula las distintas funciones para unirse o crear partida
        contador1 = contador1 + Time.deltaTime;
        contador2 = contador2 + Time.deltaTime;
        contador3 = contador3 + Time.deltaTime;
        contador4 = contador4 + Time.deltaTime;
        contador5 = contador5 + Time.deltaTime;
        contJoin = contJoin + Time.deltaTime;
        if (begin == true)
        {
            nomatch = nomatch + Time.deltaTime;
        }
        if (check == true)
        {
            contador1 = 0;
            check2 = true;
            check = false;
        }
        if (check2 == true && contador1 >= 3)
        {
            newGame();
            contador2 = 0;
            check2 = false;
        }
        if (check3 == true && contador2 >= 3)
        {
            findPlayer1();
            contador3 = 0;
            check3 = false;
        }
        if (check4 == true && contador2 >= 10)
        {
            findPlayer2();
            contador3 = 0;
            check4 = false;
        }
        if (check5 == true && contador3 >= 5)
        {
            muchosIFs();
            contador3 = 0;
            check5 = false;
        }
        if (check6 == true && contador4 >= 3)
        {
            enterOtherGame();
            check6 = false;
        }
        if (nomatch >= 30)
        {
            check = false;
            check2 = false;
            check3 = false;
            check4 = false;
            check5 = false;
            searching.text = "No match found";
        }
        if (matchFound == true)
        {
            upLoadScene = true;
            contador5 = 0.0f;
            matchFound = false;
        }
        if (upLoadScene == true && contador5 >= 5)
        {
            Application.LoadLevel("PuzzleGameTest1");
            upLoadScene = false;
        }
        if (joinBool == true && contJoin >= 4)
        {
            joinmatch();
            joinBool = false;
        }
    }
    IEnumerator waitResponseTuyas(){
        yield return new WaitForSeconds (1);
        /*
        Query q2 = QueryBuilder.Build("IDjugador1", mystats.idplayer, Operator.EQUALS);
        Query q13 = QueryBuilder.Build("IDjugador2", mystats.idplayer, Operator.EQUALS);
        Query q3 = QueryBuilder.Build ("1", "16", Operator.NOT_EQUALS);
        Query q4 = QueryBuilder.Build ("2", "16", Operator.NOT_EQUALS);
        Query q5 = QueryBuilder.CompoundOperator (q3, Operator.OR, q4);
        Query q14 = QueryBuilder.CompoundOperator (q2, Operator.OR, q13);
        Query q6 = QueryBuilder.CompoundOperator (q5, Operator.AND, q14);
        storageService = sp.BuildStorageService ();
        storageService.FindDocumentsByQuery (dbName, collectionName, q6, callBack1);
        storageService = sp.BuildStorageService();
        storageService.FindAllDocuments(dbName, mystats.idplayer+"myDataBase", savedGames);
        yield return new WaitForSeconds (3);
        */
        llenarPartidasTuyas ();
    }
    IEnumerator waitResponse()
    {
        //Muestra las partidas disponibles de la nube
        //yield return new WaitForSeconds(1);
        /*
        Query q7 = QueryBuilder.Build("IDjudador1", mystats.idplayer, Operator.NOT_EQUALS);
        Query q1 = QueryBuilder.Build("Full", "false", Operator.EQUALS);
        Query q10 = QueryBuilder.CompoundOperator(q1, Operator.AND, q7);
        storageService = sp.BuildStorageService();
        storageService.FindDocumentsByQuery(dbName, collectionName, q10, callBack);
        */
        yield return new WaitForSeconds(3);
        llenarPartidas();
    }
    public void refresh()
    {
        searching.text = "Refreshing list...";
        Destroy(world[0]);
        Destroy(UserWorld[0]);
        for (int x = 0; x < listaOld.Length; x++)
        {
            Destroy(listaOld[x]);
        }
        for (int y = 0; y < tulista.Length; y++)
        {
            Destroy(tulista[y]);
        }
        calculaHuecos = 0;
        //Hace una llamada a la nube para actualizar las partidas disponibles de la nube
        notfound.SetActive(false);
        StartCoroutine (waitResponseTuyas ());
        StartCoroutine(waitResponse());
    }
    void llenarPartidasTuyas() //Genera las filas de la lista de partidas disponibles TUYAS. Las columnas estan ya diseñadas.
    {
        string[] creatorstring = new string[20];
        string[] numberofplayersstring = new string[20];
        string[] puzzlesizestring = new string[20];
        string[] powerupsstring = new string[20];
        string[] goTopicURLstring = new string[20];
        int x = 0;
        //Busca en Kii las partidas TUYAS
        KiiQuery allQuery = new KiiQuery();
        KiiUser.CurrentUser.Bucket(mystats.idplayer + "sGames").Query(allQuery, (KiiQueryResult<KiiObject> result, Exception e) =>
        {
            float exis = -(200f * 0.0016f);
            float eye = -(200f * 0.0016f) + calculaHuecos;
            GameObject userObject = Instantiate(UserMatches, new Vector3(exis, eye, 0f), Quaternion.identity) as GameObject;
            UserWorld[0] = userObject;
            userObject.transform.parent = scroll.transform;
            userObject.SetActive(true);
            if (e != null)
            {
                // handle error
                return;
            }
            foreach (KiiObject obj in result)
            {
                numberofplayersstring[x] = (string)obj[key8];
                creatorstring[x] = (string)obj[key9];
                puzzlesizestring[x] = (string)obj[key10];
                powerupsstring[x] = (string)obj[key11];
                goTopicURLstring[x] = (string)obj[key12];
                lista[x] = obj;
                int p = x + 1;
                Debug.Log("Este es el Uri de la partida " + p + ": " + obj.Uri.ToString());
                x++;
            }
            Debug.Log("Partidas disponibles encontradas TUYAS: " + x);
            tulista = new GameObject[x];
            calculaHuecos = x;
            for (int y = 0; y < x; y++)
            {

                eye = eye - (100f * 0.0016f);
                GameObject childObject = Instantiate(match, new Vector3(exis, eye, 0f), Quaternion.identity) as GameObject;
                childObject.transform.parent = scroll.transform;
                tulista[y] = childObject;
                if (y == x - 1)
                {
                    calculaHuecos = eye;
                }

            }
            for (int i = 0; i < x; i++)
            {
                GameObject creator = tulista[i].transform.FindChild("Creator").gameObject;
                GameObject numberofplayers = tulista[i].transform.FindChild("NumberOfPlayers").gameObject;
                GameObject puzzlesize = tulista[i].transform.FindChild("PuzzleSize").gameObject;
                GameObject powerups = tulista[i].transform.FindChild("PowerUps").gameObject;
                GameObject unirse = tulista[i].transform.FindChild("SafeCheck").gameObject;
                GameObject nocheck = tulista[i].transform.FindChild("Check").gameObject;
                nocheck.SetActive(false);
                GameObject idJsonPArtidas = tulista[i].transform.FindChild("jsonID").gameObject;
                GameObject goTopicURL = tulista[i].transform.FindChild("topicURL").gameObject;
                UILabel creatorlabel = creator.GetComponent<UILabel>();
                UILabel numberofplayerslabel = numberofplayers.GetComponent<UILabel>();
                UILabel puzzlesizelabel = puzzlesize.GetComponent<UILabel>();
                UILabel powerupslabel = powerups.GetComponent<UILabel>();
                UILabel idjonLabel = idJsonPArtidas.GetComponent<UILabel>();
                UILabel topicURLlabel = goTopicURL.GetComponent<UILabel>();
                creatorlabel.text = "" + creatorstring[i] + "";
                numberofplayerslabel.text = "" + numberofplayersstring[i] + "";
                puzzlesizelabel.text = "" + puzzlesizestring[i] + "";
                powerupslabel.text = "" + powerupsstring[i] + "";
                idjonLabel.text = "" + lista[i].Uri.ToString() + "";
                topicURLlabel.text = "" + lista[i][key12] + "";
            }
            /*
            Debug.Log ("Partidas disponibles TUYAS encontradas: " + savedGames.take1.Count);
            float exis = -(200f*0.0016f);
            float eye = -(100f*0.0016f);
            tulista = new GameObject[savedGames.take1.Count];
            calculaHuecos = savedGames.take1.Count;
            for (int x = 0; x < savedGames.take1.Count+1; x++) {
                eye = eye -(100f*0.0016f);
                if (x == 0) {
                    GameObject userObject = Instantiate(UserMatches, new Vector3(exis, eye, 0f), Quaternion.identity) as GameObject;
                    UserWorld[0] = userObject;
                    userObject.transform.parent = scroll.transform;
                    userObject.SetActive (true);
                } else {
                    GameObject childObject = Instantiate(match, new Vector3(exis, eye, 0f), Quaternion.identity) as GameObject;
                    childObject.transform.parent = scroll.transform;
                    tulista[x-1] = childObject;
                    if(x == savedGames.take1.Count){
                        calculaHuecos = eye;
                    }
                }
            }
            for (int i = 0; i < savedGames.take1.Count; i++) {
                GameObject creator = tulista[i].transform.FindChild ("Creator").gameObject;
                GameObject numberofplayers = tulista[i].transform.FindChild ("NumberOfPlayers").gameObject;
                GameObject puzzlesize = tulista[i].transform.FindChild ("PuzzleSize").gameObject;
                GameObject powerups = tulista[i].transform.FindChild ("PowerUps").gameObject;
                GameObject unirse = tulista[i].transform.FindChild ("SafeCheck").gameObject;
                GameObject nocheck = tulista[i].transform.FindChild("Check").gameObject;
                GameObject idJsonPArtidas = tulista[i].transform.FindChild ("jsonID").gameObject;
                nocheck.SetActive(false);
                UILabel creatorlabel = creator.GetComponent<UILabel>();
                UILabel numberofplayerslabel = numberofplayers.GetComponent<UILabel>();
                UILabel puzzlesizelabel = puzzlesize.GetComponent<UILabel>();
                UILabel powerupslabel = powerups.GetComponent<UILabel>();
                UILabel idjonLabel = idJsonPArtidas.GetComponent<UILabel>();
                jsonObj = savedGames.take1 [i].GetJsonDoc();
                string creatorstring = getinfo.sacarinfo ("Host", jsonObj);
                string numberofplayersstring = "2";
                string puzzlesizestring = "16";
                string powerupsstring = "no";
                string jsonId = savedGames.take1[i].GetDocId();
                creatorlabel.text = "" + creatorstring + "";
                Debug.Log (creatorstring);
                numberofplayerslabel.text = "" + numberofplayersstring + "";
                puzzlesizelabel.text = "" + puzzlesizestring + "";
                powerupslabel.text = "" + powerupsstring + "";
                idjonLabel.text = "" +jsonId+"";
            }
            */
        });
    }

    void llenarPartidas()
    {
        string[] creatorstring = new string[20];
        string[] numberofplayersstring = new string[20];
        string[] puzzlesizestring = new string[20];
        string[] powerupsstring = new string[20];
        string[] goTopicURLstring = new string[20];
        int x = 0;
        //Genera las filas de la lista de partidas disponibles
        // Las columnas estan ya diseñadas.
        KiiQuery query = new KiiQuery(
                  KiiClause.And(
                        KiiClause.Equals(key4, "false"),
                        KiiClause.NotEquals(key9, mystats.idplayer)
                      )
                  );

        // Alternatively, you can also do:
        // Kii.Bucket("myBuckets").Query(null, (...));
        Kii.Bucket("Global").Query(query, (KiiQueryResult<KiiObject> result, Exception e) =>
        {
            float exis = -(200f * 0.0016f);
            float eye = -(200f * 0.0016f) + calculaHuecos;
            GameObject worldObject = Instantiate(WorldMatches, new Vector3(exis, eye, 0f), Quaternion.identity) as GameObject;
            world[0] = worldObject;
            worldObject.transform.parent = scroll.transform;
            worldObject.SetActive(true);
            if (e != null)
            {
                // handle error
                return;
            }
            foreach (KiiObject obj in result)
            {
                numberofplayersstring[x] = (string)obj[key8];
                creatorstring[x] = (string)obj[key9];
                puzzlesizestring[x] = (string)obj[key10];
                powerupsstring[x] = (string)obj[key11];
                goTopicURLstring[x] = (string)obj[key12];
                lista[x] = obj;
                int p = x + 1;
                Debug.Log("Este es el Uri de la partida "+ p +": " + obj.Uri.ToString());
                x++;
            }
            Debug.Log("Partidas disponibles encontradas: " + x);
            listaOld = new GameObject[x];
            for (int y = 0; y < x; y++)
            {

                eye = eye - (100f * 0.0016f);
                GameObject childObject = Instantiate(match, new Vector3(exis, eye, 0f), Quaternion.identity) as GameObject;
                childObject.transform.parent = scroll.transform;
                listaOld[y] = childObject;
                if (y == x - 1)
                {
                    calculaHuecos = eye;
                }

            }
            for (int i = 0; i < x; i++)
            {
                GameObject creator = listaOld[i].transform.FindChild("Creator").gameObject;
                GameObject numberofplayers = listaOld[i].transform.FindChild("NumberOfPlayers").gameObject;
                GameObject puzzlesize = listaOld[i].transform.FindChild("PuzzleSize").gameObject;
                GameObject powerups = listaOld[i].transform.FindChild("PowerUps").gameObject;
                GameObject unirse = listaOld[i].transform.FindChild("Check").gameObject;
                GameObject nocheck = listaOld[i].transform.FindChild("SafeCheck").gameObject;
                nocheck.SetActive(false);
                GameObject idJsonPArtidas = listaOld[i].transform.FindChild("jsonID").gameObject;
                GameObject goTopicURL = listaOld[i].transform.FindChild("topicURL").gameObject;
                UILabel creatorlabel = creator.GetComponent<UILabel>();
                UILabel numberofplayerslabel = numberofplayers.GetComponent<UILabel>();
                UILabel puzzlesizelabel = puzzlesize.GetComponent<UILabel>();
                UILabel powerupslabel = powerups.GetComponent<UILabel>();
                UILabel idjonLabel = idJsonPArtidas.GetComponent<UILabel>();
                UILabel topicURLlabel = goTopicURL.GetComponent<UILabel>();
                creatorlabel.text = "" + creatorstring[i] + "";
                numberofplayerslabel.text = "" + numberofplayersstring[i] + "";
                puzzlesizelabel.text = "" + puzzlesizestring[i] + "";
                powerupslabel.text = "" + powerupsstring[i] + "";
                idjonLabel.text = "" + lista[i].Uri.ToString() + "";
                topicURLlabel.text = "" + lista[i][key12] + "";
            }
        });
        /*if (callBack.take1.Count < 2)
        {
            notfound.SetActive(true);
        }
        else
        {
            float exis = -(200f * 0.0016f);
            float eye = -(200f * 0.0016f) + calculaHuecos;
            lista = new GameObject[callBack.take1.Count];
            for (int x = 0; x < callBack.take1.Count + 1; x++)
            {
                if (x == 0)
                {
                    GameObject worldObject = Instantiate(WorldMatches, new Vector3(exis, eye, 0f), Quaternion.identity) as GameObject;
                    world[0] = worldObject;
                    worldObject.transform.parent = scroll.transform;
                    worldObject.SetActive(true);
                }
                else
                {
                    eye = eye - (100f * 0.0016f);
                    GameObject childObject = Instantiate(match, new Vector3(exis, eye, 0f), Quaternion.identity) as GameObject;
                    childObject.transform.parent = scroll.transform;
                    lista[x - 1] = childObject;
                    if (x == callBack.take1.Count - 1)
                    {
                        calculaHuecos = eye;
                    }
                }
            }
            for (int i = 0; i < callBack.take1.Count; i++)
            {
                GameObject creator = lista[i].transform.FindChild("Creator").gameObject;
                GameObject numberofplayers = lista[i].transform.FindChild("NumberOfPlayers").gameObject;
                GameObject puzzlesize = lista[i].transform.FindChild("PuzzleSize").gameObject;
                GameObject powerups = lista[i].transform.FindChild("PowerUps").gameObject;
                GameObject unirse = lista[i].transform.FindChild("Check").gameObject;
                GameObject idJsonPArtidas = lista[i].transform.FindChild("jsonID").gameObject;
                UILabel creatorlabel = creator.GetComponent<UILabel>();
                UILabel numberofplayerslabel = numberofplayers.GetComponent<UILabel>();
                UILabel puzzlesizelabel = puzzlesize.GetComponent<UILabel>();
                UILabel powerupslabel = powerups.GetComponent<UILabel>();
                UILabel idjonLabel = idJsonPArtidas.GetComponent<UILabel>();
                jsonObj = callBack.take1[i].GetJsonDoc();
                string creatorstring = getinfo.sacarinfo(key9, jsonObj);
                string numberofplayersstring = getinfo.sacarinfo(key8, jsonObj);
                string puzzlesizestring = getinfo.sacarinfo(key10, jsonObj);
                string powerupsstring = getinfo.sacarinfo(key11, jsonObj);
                string jsonId = callBack.take1[i].GetDocId();
                creatorlabel.text = "" + creatorstring + "";
                Debug.Log(creatorstring);
                numberofplayerslabel.text = "" + numberofplayersstring + "";
                puzzlesizelabel.text = "" + puzzlesizestring + "";
                powerupslabel.text = "" + powerupsstring + "";
                idjonLabel.text = "" + jsonId + "";
            }
        }
        searching.text = "";
    }*/
        searching.text = "";
    }
    void muchosIFs()
    {
        //Comprueba en ultima instancia al meterse en una partida, si se ha metido alguien antes
        //if (jugador != "1") {
        /*if (StorageResponse.resul == "exception")
        {
            buscar();
        }
        else
        {
        */
            matchFound = true;
            //mystats.yourIdJson = myDataBase.id1;
            mystats.jugador = jugador;
            mystats.oponente = oponente;
            mystats.idjson = idjson;
            Debug.Log("Partida encontrada. Entrando en la partida...");
        //}
    }

    void findPlayer1()
    {
        //Si no encuentra partida, crea una partida nueva
        /*
        storageService = sp.BuildStorageService();
        storageService.FindDocumentByKeyValue(dbName, collectionName, key4, "true", callBack);
        */
        check5 = true;
    }
    void findPlayer2()
    {
        //Si ha encontrado partida como Jugador 2, actualiza IDJugador2 en la nube
        /*
        storageService = sp.BuildStorageService();
        storageService.FindDocumentByKeyValue(dbName, collectionName, key5, value5, callBack);
        */
        check5 = true;
    }
    public void findPlayers()
    {
        //Buscar partida aleatoria, sino crea una nueva
        searching.text = "Searching for match";
        if (StorageResponse.resul == "exception")
        {
            buscar();
        }
        else
        {
            jugador = "2";
            oponente = "1";
            idjson = mystats.idjson;
            //mystats.idplayer2 = getinfo.sacarinfo(key9, jsonObj);
            /*
            Dictionary<string, object> jsonDoc = new Dictionary<string, object>();
            jsonObj = StorageResponse.take[0].GetJsonDoc();
            string turno = getinfo.sacarinfo(key2, jsonObj);
            string turnoplayer = getinfo.sacarinfo(key3, jsonObj);
            string idjugador1 = getinfo.sacarinfo(key9, jsonObj);
            value1 = round.ToString();
            value2 = turno;
            value3 = turnoplayer;
            value4 = full;
            value5 = mystats.idplayer;
            value9 = idjugador1;
            jsonDoc.Add(key1, value1);
            jsonDoc.Add(key2, value2);
            jsonDoc.Add(key3, value3);
            jsonDoc.Add(key4, value4);
            jsonDoc.Add(key5, value5);
            jsonDoc.Add(key6, value6);
            jsonDoc.Add(key7, value7);
            jsonDoc.Add(key8, value8);
            jsonDoc.Add(key9, value9);
            jsonDoc.Add(key10, value10);
            jsonDoc.Add(key11, value11);
            storageService = sp.BuildStorageService();
            storageService.UpdateDocumentByDocId(dbName, collectionName, idjson, jsonDoc, callBack);
            jsonObj = StorageResponse.fg;
            
            queueService = sp.BuildQueueService();
            queueService.CreatePullQueue(mystats.idjson + mystats.idplayer + "Queue", "Queue Player2", callMessage);
            queueService.CreatePullQueue(mystats.idjson + mystats.idplayer + "Pieces", "Pieces Player2", piecesMessage);
            */
            check4 = true;
        }
    }

    public void buscar()
    {
        //Busca una partida vacia
        // Prepare the target bucket to be queried
        KiiBucket bucket = Kii.Bucket("Global");

        // Define query conditions
        KiiQuery query = new KiiQuery(
            KiiClause.Equals("Full","True")
        );

        // Fine-tune your query results
        query.Limit = 1;

        // Query the bucket
        bucket.Query(query, (KiiQueryResult<KiiObject> result, Exception e) =>
        {
            if (e != null)
            {
                Debug.LogError("Query Object failed: " + e.ToString());
                // handle error
                return;
            }
            foreach (KiiObject obj in result)
            {
                obj.GetUri(objectUri);
                Debug.Log("Uri del objeto: " + objectUri);
                string turno = (string)obj[key2];
                string turnoplayer = (string)obj[key3];
                string idjugador1 = (string)obj[key9];

                //Updating match information.
                KiiObject obj2 = KiiObject.CreateByUri(new Uri(objectUri));
                obj2.Refresh((KiiObject obj3, Exception e2) =>
                {
                    if (e2 != null)
                    {
                        Debug.LogError("Retreving Object failed: " + e2.ToString());
                        // handle error
                        return;
                    }
                    //Update following information
                    value1 = round.ToString();
                    value2 = turno;
                    value3 = turnoplayer;
                    value4 = full;
                    value5 = mystats.idplayer;
                    value9 = idjugador1;

                    obj3[key1] = value1;
                    obj3[key2] = value2;
                    obj3[key3] = value3;
                    obj3[key4] = value4;
                    obj3[key5] = value5;
                    obj3[key6] = value6;
                    obj3[key7] = value7;
                    obj3[key8] = value8;
                    obj3[key9] = value9;
                    obj3[key10] = value10;
                    obj3[key11] = value11;
                    obj3.SaveAllFields(false, (KiiObject updatedObj, Exception e3) =>
                    {
                        if (e3 != null)
                        {
                            Debug.LogError("Update Object failed: " + e3.ToString());
                            // handle error
                        }
                        else
                        {
                            //TENEMOS QUE SEGUIR AQUI: IMPLEMENTAR KII TOPICS
                            mystats.idplayer2 = key9;
                            Debug.Log("Match information upadted successfully.");
                        }
                    });
                });
            }
        });
        /*
        storageService = sp.BuildStorageService();
        storageService.FindDocumentByKeyValue(dbName, collectionName, key4, validador, callBack);
        nomatch = 0;
        check = true;
        */
    }
    public void newGame()
    {
        //Crea una partida nueva
        searching.text = "Creating match...";
        /*
        value1 = round.ToString();
        value2 = turn.ToString();
        value9 = mystats.idplayer;
        json.Add(key1, value1);
        json.Add(key2, value2);
        json.Add(key3, value3);
        json.Add(key4, value4);
        json.Add(key5, value5);
        json.Add(key6, value6);
        json.Add(key7, value7);
        json.Add(key8, value8);
        json.Add(key9, value9);
        json.Add(key10, value10);
        json.Add(key11, value11);
        storageService = sp.BuildStorageService();
        storageService.InsertJSONDocument(dbName, mystats.idplayer + "'s Games", json, myDataBase);
        storageService.InsertJSONDocument(dbName, collectionName, json, callBack);
        */
        // Create an object in an user-scope bucket.
        KiiObject obj5 = Kii.Bucket("MatchInfo").NewKiiObject();
        value1 = round.ToString();
        value2 = turn.ToString();
        value9 = mystats.idplayer;
        obj5[keypieces] = valuepieces;
        obj5[keyplayersturn] = valueplayersturn;

        obj5.Save((KiiObject savedObj, Exception e) =>
        {
            if (e != null)
            {
                // Handle error
            }
            else
            {
                value12 = obj5.Uri.ToString();
                mystats.groupURL = value12;
                KiiObject obj = KiiUser.CurrentUser.Bucket(mystats.idplayer + "sGames").NewKiiObject();
                obj[key1] = value1;
                obj[key2] = value2;
                obj[key3] = value3;
                obj[key4] = value4;
                obj[key5] = value5;
                obj[key6] = value6;
                obj[key7] = value7;
                obj[key8] = value8;
                obj[key9] = value9;
                obj[key10] = value10;
                obj[key11] = value11;
                obj[key12] = value12;
                // Save the object
                obj.Save((KiiObject savedObj2, Exception e2) =>
                {
                    if (e2 != null)
                    {
                        // Handle error
                    }
                    else
                    {
                        mystats.yourIdJson = obj.Uri.ToString();
                    }
                });
                KiiObject obj2 = Kii.Bucket(collectionName).NewKiiObject();
                // Set key-value pairs
                obj2[key1] = value1;
                obj2[key2] = value2;
                obj2[key3] = value3;
                obj2[key4] = value4;
                obj2[key5] = value5;
                obj2[key6] = value6;
                obj2[key7] = value7;
                obj2[key8] = value8;
                obj2[key9] = value9;
                obj2[key10] = value10;
                obj2[key11] = value11;
                obj2[key12] = value12;
                obj2.Save((KiiObject savedObjj, Exception e3) =>
                {
                    if (e3 != null)
                    {
                        // Handle error
                    }
                    else
                    {
                        mystats.idjson = obj2.Uri.ToString();
                        upLoadScene = true;
                        contador5 = 0.0f;
                        jugador = "1";
                        oponente = "2";
                        mystats.jugador = jugador;
                        mystats.oponente = oponente;
                        Debug.Log("Creando nueva partida...");
                    }
                });
            }
        });
    }
    IEnumerator join()
    {
        /*
        storageService = sp.BuildStorageService();
        storageService.FindDocumentById(dbName, collectionName, mystats.idjson, callBack);
        */
        Debug.Log("CARGANDO PARTIDA...");
        yield return new WaitForSeconds(1);
        Application.LoadLevel("PuzzleGameTest1");
    }
    public void queryJoin() 
    {
            searching.text = "Joining match...";
            UIButton linea = UIButton.current;
            GameObject lin = linea.gameObject;
            GameObject padre = lin.transform.parent.gameObject;
            GameObject enemyhijo = padre.transform.FindChild("Creator").gameObject;
            GameObject idhijo = padre.transform.FindChild("jsonID").gameObject;
            UILabel enemyLabel = enemyhijo.GetComponent<UILabel>();
            UILabel idLabel = idhijo.GetComponent<UILabel>();
            string enemyString = enemyLabel.text;
            string idString = idLabel.text;
            mystats.idplayer2 = enemyString;
            mystats.idjson = idString;
            /*
            Debug.Log("idString: " + idString + "  |  idjson: " + mystats.idjson);
            Query buscarPartidas = QueryBuilder.Build(idString, mystats.idjson, Operator.EQUALS);
            storageService = sp.BuildStorageService();
            storageService.FindDocumentById(dbName, mystats.idplayer + "myDataBase", idString, savedGames);
            storageService.FindDocumentsByQuery(dbName, mystats.idplayer + "myDataBase", buscarPartidas, savedGames);
            */
            joinBool = true;
            contJoin = 0.0f;
    }
    public void joinmatch()
    {
        searching.text = "Joining match...";
        /*
        UIButton linea = UIButton.current;
        GameObject lin = linea.gameObject;
        GameObject padre = lin.transform.parent.gameObject;
        GameObject enemyhijo = padre.transform.FindChild("Creator").gameObject;
        GameObject idhijo = padre.transform.FindChild("jsonID").gameObject;
        UILabel enemyLabel = enemyhijo.GetComponent<UILabel>();
        UILabel idLabel = idhijo.GetComponent<UILabel>();
        string enemyString = enemyLabel.text;
        string idString = idLabel.text;
        mystats.idplayer2 = enemyString;
        mystats.idjson = idString;
        */
        // Prepare the target bucket to be queried
        KiiBucket bucket = KiiUser.CurrentUser.Bucket(mystats.idplayer + "SaveGames");

        // Define query conditions
        KiiQuery query = new KiiQuery(
          KiiClause.Equals(gamekey2, mystats.yourIdJson)
        );

        // Query the bucket
        bucket.Query(query, (KiiQueryResult<KiiObject> result, Exception e) =>
        {
            if (e != null)
            {
                Debug.LogError("Error: " + e.ToString());
                // handle error
                return;
            }
            foreach (KiiObject obj in result)
            {
                Debug.Log("ARCHIVO SAVEGAME ENCONTRADO.");
                /*
                Dictionary<string, object> jsonDoc = new Dictionary<string, object>();
                jsonObj = savedGames.take1[0].GetJsonDoc();
                */
                mystats.idjson = (string) obj[gamekey1];
                mystats.yourIdJson = (string) obj[gamekey2];
                mystats.oponente = (string) obj[gamekey54];
                for (int x = 1; x < 17; x++)
                {
                    string temp = "casilla" + x;
                    mystats.puzzles.pieces[x - 1] = bool.Parse((string) obj["casilla"+x]);
                }
                for (int y = 1; y < 5; y++)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        if (z == 0)
                        {
                            mystats.puzzles.drawer[y - 1, z] = float.Parse((string) obj["cajon" + y]);
                        }
                        if (z == 1)
                        {
                            mystats.puzzles.drawer[y - 1, z] = float.Parse((string) obj["rotcajon"+y]);
                        }
                    }
                }
                mystats.puzzles.cpiece[0] = float.Parse((string) obj[gamekey23]);
                mystats.puzzles.npiece[0] = float.Parse((string) obj[gamekey24]);
                mystats.puzzles.cpiece[1] = float.Parse((string) obj[gamekey45]);
                mystats.puzzles.npiece[1] = float.Parse((string) obj[gamekey46]);
                for (int t = 1; t < 17; t++)
                {
                    mystats.puzzles.deck[t - 1] = int.Parse((string) obj["deck"+t]);
                }
                mystats.jugador = (string) obj[gamekey47];
                mystats.puzzles.t = int.Parse((string) obj[gamekey48]);
                mystats.puzzles.r = int.Parse((string) obj[gamekey49]);
                mystats.puzzles.maxDeckValue = int.Parse((string) obj[gamekey50]);
                mystats.puzzles.puzzleID = int.Parse((string) obj[gamekey51]);
                mystats.puzzles.myprogress = int.Parse((string) obj[gamekey52]);
                mystats.puzzles.myoppprogress = int.Parse((string) obj[gamekey53]);
                mystats.aQuienLeTOCA = (string)obj[gamekey56];
                mystats.alreadyBegun = true;
                StartCoroutine(join());
            }
        });
    }
    public void joinMatchFailed()
    {
        searching.text = "Joining match...";
        UIButton linea = UIButton.current;
        GameObject lin = linea.gameObject;
        GameObject padre = lin.transform.parent.gameObject;
        GameObject enemyhijo = padre.transform.FindChild("Creator").gameObject;
        GameObject idhijo = padre.transform.FindChild("jsonID").gameObject;
        GameObject idtopic = padre.transform.FindChild("topicURL").gameObject;
        UILabel enemyLabel = enemyhijo.GetComponent<UILabel>();
        UILabel idLabel = idhijo.GetComponent<UILabel>();
        UILabel topicLabel = idtopic.GetComponent<UILabel>();
        string enemyString = enemyLabel.text;
        string idString = idLabel.text;
        string topicString = topicLabel.text;
        mystats.idplayer2 = enemyString;
        mystats.idjson = idString;
        
        //Updating match information.
        KiiObject obj2 = KiiObject.CreateByUri(new Uri(idString));
        obj2.Refresh((KiiObject obj3, Exception e2) =>
        {
            if (e2 != null)
            {
                Debug.LogError("Retreving Object failed: " + e2.ToString());
                // handle error
                return;
            }
            //Retrieve from cloud
            value1 = (string)obj3[key1];
            value2 = (string)obj3[key2];
            value3 = (string)obj3[key3];
            value4 = "true";
            value5 = mystats.idplayer;
            value6 = (string)obj3[key6];
            value7 = (string)obj3[key7];
            value8 = (string)obj3[key8];
            value9 = (string)obj3[key9];
            value10 = (string)obj3[key10];
            value11 = (string)obj3[key11];
            value12 = (string)obj3[key12];
            mystats.groupURL = value12;
            //Update following information
            obj3[key4] = value4;
            obj3[key5] = value5;
            obj3.SaveAllFields(false, (KiiObject updatedObj, Exception e3) =>
            {
                if (e3 != null)
                {
                    Debug.LogError("Update Object failed: " + e3.ToString());
                    // handle error
                }
                else
                {
                    Debug.Log("Match information updated successfully.");
                }
            });
        });
        Debug.Log("idString: " + idString + "  |  idjson: " + mystats.idjson);
        Debug.Log("NO SE HA ENCONTRADO ARCHIVO SAVEGAME.");
        /*
        storageService = sp.BuildStorageService();
        storageService.FindDocumentById(dbName, collectionName, mystats.idjson, callBack);
        */
        contador4 = 0;
        check6 = true;
    }
    public void enterOtherGame()
    {
        // Create an object in an user-scope bucket.
        KiiObject obj = KiiUser.CurrentUser.Bucket(mystats.idplayer + "sGames").NewKiiObject();

        // Set key-value pairs
        obj[key1] = value1;
        obj[key2] = value2;
        obj[key3] = value3;
        obj[key4] = value4;
        obj[key5] = value5;
        obj[key6] = value6;
        obj[key7] = value7;
        obj[key8] = value8;
        obj[key9] = value9;
        obj[key10] = value10;
        obj[key11] = value11;
        obj[key12] = value12;

        // Save the object
        obj.Save((KiiObject savedObj, Exception e) =>
        {
            if (e != null)
            {
                Debug.LogError("Object creation failed: " + e.ToString());
            }
            else
            {
                mystats.yourIdJson = obj.Uri.ToString();
            }
        });
        jugador = "2";
        oponente = "1";
        idjson = mystats.idjson;
        /*
        Dictionary<string, object> jsonDoc = new Dictionary<string, object>();
        jsonObj = StorageResponse.take[0].GetJsonDoc();
        string turno = getinfo.sacarinfo(key2, jsonObj);
        string turnoplayer = getinfo.sacarinfo(key3, jsonObj);
        string idjugador1 = getinfo.sacarinfo(key9, jsonObj);
        value1 = round.ToString();
        value2 = turno;
        value3 = turnoplayer;
        value4 = full;
        value5 = mystats.idplayer;
        value9 = idjugador1;
        jsonDoc.Add(key1, value1);
        jsonDoc.Add(key2, value2);
        jsonDoc.Add(key3, value3);
        jsonDoc.Add(key4, value4);
        jsonDoc.Add(key5, value5);
        jsonDoc.Add(key6, value6);
        jsonDoc.Add(key7, value7);
        jsonDoc.Add(key8, value8);
        jsonDoc.Add(key9, value9);
        jsonDoc.Add(key10, value10);
        jsonDoc.Add(key11, value11);
        storageService = sp.BuildStorageService();
        storageService.UpdateDocumentByDocId(dbName, collectionName, idjson, jsonDoc, callBack);
        storageService.InsertJSONDocument(dbName, mystats.idplayer + "'s Games", jsonDoc, myDataBase);
        jsonObj = StorageResponse.fg;
        mystats.idplayer2 = getinfo.sacarinfo(key9, jsonObj);
        queueService = sp.BuildQueueService();
        queueService.CreatePullQueue(mystats.idjson + mystats.idplayer + "Queue", "Queue Player2", callMessage);
        queueService.CreatePullQueue(mystats.idjson + mystats.idplayer + "Pieces", "Pieces Player2", piecesMessage);
        */
        check4 = true;
    }
}
