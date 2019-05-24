using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using KiiCorp.Cloud.Unity;
using KiiCorp.Cloud.Storage;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using com.shephertz.app42.paas.sdk.csharp.pushNotification;
using com.shephertz.app42.paas.sdk.csharp.message;
using com.shephertz.app42.paas.sdk.csharp.social;
using SimpleJSON;
using AssemblyCSharp;
using StartApp;

public class fichasingle : MonoBehaviour
{
	public int opportunitiesIA;
	public int id;
	public int[] randomvalidator;
	public int[] idscajon;
	public int round;
	public int turn;
	public int puzzleprogress;
	public int puzzleoppprogress;
	public Texture[] texpieces;
	public int[] positioner;
	public int[,] drawerposition = new int[4, 4];
	public int[] currentpieceposition;
	public int[] nextpieceposition;
	int randomNumber;
	public int randomlength;
	public int randompuzzle;
	int aux;
	public int texpiecesnumber;
	public Queue<int> cola = new Queue<int>();
	public UITexture followingPiece, actualPiece;
	public UITexture[] piezas;
	public UITexture[] cajon;
	public Texture empty;
	UISprite cambio;
	bool firstTimeGame = false;
	public bool firsttime = false;
	public bool correct = true;
	public bool[] fullorempty;
	public bool llena;
	public bool activarllena;
	public bool firstsavegame;
	public bool finalPartida;
	public bool[] llenoornot;
	public bool igualacero = true;
	public bool change;
	public bool interstitialloaded;
	public bool savebool;
	public bool mensajeRecibido;
	bool recibido;
	bool clicked;
	int contador = 0;
	public GameObject rotnextpiece;
	public GameObject rotcurrentpiece;
	public GameObject popUp;
	public GameObject banner;
	public GameObject results;
	public GameObject victory;
	public GameObject defeat;
	public GameObject surrendervictory;
	public GameObject helpbutton;
	public GameObject helpbuttonexit;
	public GameObject helpToggle;
	public UILabel opnumber;
	public UILabel ppnumber;
	public UILabel changeturnpopup;
	float crot;
	public float actualRot;
	public float[] rotcajon;
	public float contador2;
	public float contadorsave;
	float tiempo;
	float tiempo2;
	public UIButton[] casilla;
	public UIButton endturn;
	public GameObject[] puzzles;
	public GameObject stats;
	infoPlayer mystats;
	public GameObject PuzzleP;
	PuzzleProgress ProgressPuzzle;
	AdMobPlugin advertisement;
	public Animator currentanimation, nextanimation;
	public Animator[] casillaanimation, draweranimation;
	public bool rendirse;
	public GameObject SurrenderPopUp;
	string metocarecibido;
	
	//Cosas del APP42
	ServiceAPI sp = null;
	StorageService storageService = null;
	QueueService queueService = null;
	StorageResponse callBack = new matchList().callBack;
	StorageResponse savedGames = new StorageResponse();
	MessageResponse callMessage = new MessageResponse();
	MessageResponsePO piecesMessage = new MessageResponsePO();
	PushNotificationService pushNotificationService = null; // Para ANDROID
	PushNotificationResponse pushBack = new PushNotificationResponse(); // Para ANDROID
	PushNotificationService pushService = null; // Para iOS
	public string idjson;
	public string jugador;
	public string oponente;
	public string userName;
	public string message;
	//Cosas del APP42 - Contenido del JSON en la nube
	string key1 = "Round", key2 = "Turn", key3 = "PlayerTurn", key4 = "Full", key5 = "IDjugador2", key6 = "1", key7 = "2", key8 = "NumeroJugadores", key9 = "IDjugador1", key10 = "TamañoPuzzle", key11 = "PowerUps", key12 = "GameID";
	string value1 = "0", value2 = "0", value3 = "1", value4 = "false", value5 = "player2", value6 = "0", value7 = "0", value8 = "2", value9 = "player1", value10 = "16", value11 = "no", value12 = "0";
	string gamekey1 = "jsonID", gamekey2 = "yourjsonID", gamekey3 = "casilla1", gamekey4 = "casilla2", gamekey5 = "casilla3", gamekey6 = "casilla4", gamekey7 = "casilla5", gamekey8 = "casilla6", gamekey9 = "casilla7", gamekey10 = "casilla8", gamekey11 = "casilla9", gamekey12 = "casilla10", gamekey13 = "casilla11", gamekey14 = "casilla12", gamekey15 = "casilla13", gamekey16 = "casilla14", gamekey17 = "casilla15", gamekey18 = "casilla16", gamekey19 = "cajon1", gamekey20 = "cajon2", gamekey21 = "cajon3", gamekey22 = "cajon4", gamekey23 = "actualID", gamekey24 = "nextID", gamekey25 = "deck1", gamekey26 = "deck2", gamekey27 = "deck3", gamekey28 = "deck4", gamekey29 = "deck5", gamekey30 = "deck6", gamekey31 = "deck7", gamekey32 = "deck8", gamekey33 = "deck9", gamekey34 = "deck10", gamekey35 = "deck11", gamekey36 = "deck12", gamekey37 = "deck13", gamekey38 = "deck14", gamekey39 = "deck15", gamekey40 = "deck16", gamekey41 = "rotcajon1", gamekey42 = "rotcajon2", gamekey43 = "rotcajon3", gamekey44 = "rotcajon4", gamekey45 = "rotactual", gamekey46 = "rotnext", gamekey47 = "whichplayer", gamekey48 = "turn", gamekey49 = "round", gamekey50 = "maxdeckvalue", gamekey51 = "puzzleID", gamekey52 = "myprogress", gamekey53 = "myoppprogress", gamekey54 = "Opponent", gamekey55 = "Host", gamekey56 = "AQuienLeToca";
	string gamevalue1 = "", gamevalue2 = "", gamevalue3 = "", gamevalue4 = "0", gamevalue5 = "0", gamevalue6 = "0", gamevalue7 = "0", gamevalue8 = "0", gamevalue9 = "0", gamevalue10 = "0", gamevalue11 = "0", gamevalue12 = "0", gamevalue13 = "0", gamevalue14 = "0", gamevalue15 = "0", gamevalue16 = "0", gamevalue17 = "0", gamevalue18 = "0", gamevalue19 = "", gamevalue20 = "", gamevalue21 = "", gamevalue22 = "", gamevalue23 = "", gamevalue24 = "", gamevalue25 = "", gamevalue26 = "", gamevalue27 = "", gamevalue28 = "", gamevalue29 = "", gamevalue30 = "", gamevalue31 = "", gamevalue32 = "", gamevalue33 = "", gamevalue34 = "", gamevalue35 = "", gamevalue36 = "", gamevalue37 = "", gamevalue38 = "", gamevalue39 = "", gamevalue40 = "", gamevalue41 = "", gamevalue42 = "", gamevalue43 = "", gamevalue44 = "", gamevalue45 = "", gamevalue46 = "", gamevalue47 = "", gamevalue48 = "", gamevalue49 = "", gamevalue50 = "", gamevalue51 = "", gamevalue52 = "", gamevalue53 = "", gamevalue54 = "", gamevalue55 = "", gamevalue56 = "";
	string keypieces = "Pieces", keyplayersturn = "WhosTurn";
	string valuepieces = "", valueplayersturn = "";
	string dbName = "Cloud";
	string collectionName = "Global";
	JSONClass json = new JSONClass();
	public string jsonObj;
	bool meToca = true;
	jsonPrueba conversor = new jsonPrueba();
	
	public static ficha fich;
	
	void Awake()
	{
		opportunitiesIA = 0;
		mensajeRecibido = false;
		rendirse = false;
		finalPartida = false;
		StorageResponse.fg = "";
		mystats = stats.GetComponent<infoPlayer>();
		ProgressPuzzle = PuzzleP.GetComponent<PuzzleProgress>();
		mystats.puzzles = ProgressPuzzle;
		jugador = mystats.jugador;
		oponente = mystats.oponente;
		idjson = mystats.idjson;
		sp = new ServiceAPI("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
		App42API.Initialize("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
		//Seleccion de Puzzle
			mystats.puzzles.pieces[0] = false;
			mystats.puzzles.pieces[1] = false;
			mystats.puzzles.pieces[2] = false;
			mystats.puzzles.pieces[3] = false;
			mystats.puzzles.pieces[4] = false;
			mystats.puzzles.pieces[5] = false;
			mystats.puzzles.pieces[6] = false;
			mystats.puzzles.pieces[7] = false;
			mystats.puzzles.pieces[8] = false;
			mystats.puzzles.pieces[9] = false;
			mystats.puzzles.pieces[10] = false;
			mystats.puzzles.pieces[11] = false;
			mystats.puzzles.pieces[12] = false;
			mystats.puzzles.pieces[13] = false;
			mystats.puzzles.pieces[14] = false;
			mystats.puzzles.pieces[15] = false;
			mystats.puzzles.drawer[0,0] = 100;
			mystats.puzzles.drawer[1, 0] = 100;
			mystats.puzzles.drawer[2, 0] = 100;
			mystats.puzzles.drawer[3, 0] = 100;
			randompuzzle = UnityEngine.Random.Range(0, 7);
			Puzzles temp = puzzles[randompuzzle].GetComponent<Puzzles>();
			mystats.puzzles.puzzleID = randompuzzle;
			for (int x = 0; x < texpieces.Length; x++)
			{
				texpieces[x] = temp.pieces[x];
			}
			round = 0;
			turn = 0;
			changeturnpopup.text = "";
			deck();
			fichei();
			firstTimeGame = true;
			llena = false;
			firstsavegame = true;
			mystats.host = mystats.idplayer;
			activarllena = false;
		// Forces a different code path in the BinaryFormatter that doesn't rely on run-time code generation (which would break on iOS).
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
		savebool = false;
	}
	void Start()
	{
		
		//Valores iniciales.
		change = true;
		rendirse = false;
		puzzleoppprogress = 0;
		puzzleprogress = 0;
		ppnumber.text = "" + puzzleoppprogress;
		opnumber.text = "" + puzzleprogress;
		if (mystats.alreadyBegun == false)
		{
			fichei();
		}
		firstTimeGame = true;
		turn = turn + 1;
		clicked = false;
		cambio = helpbutton.GetComponent<UISprite>();
		idjson = mystats.idjson;
		#if UNITY_ANDROID
		StartAppWrapper.init();
		StartAppWrapper.loadAd();
		StartAppWrapper.removeBanner(StartAppWrapper.BannerPosition.BOTTOM);
		#endif
		#if UNITY_IPHONE
		StartAppWrapperiOS.hideBanner();
		StartAppWrapperiOS.loadAd();
		#endif
		/*
        advertisement = banner.GetComponent<AdMobPlugin>();
        advertisement.Hide();
         */
	}
	void Update()
	{
		//Espera tiempo para mirar en la nube
		contador2 = contador2 + Time.deltaTime;
		contadorsave = contadorsave + Time.deltaTime;
		if (activarllena == true)
		{
		}
		tiempo = tiempo + Time.deltaTime;
		tiempo2 = tiempo2 + Time.deltaTime;
		if (meToca == false && tiempo2 >= 5.0f)
		{
			IATurn();
			if (meToca == false && tiempo >= 5.0f)
			{
				tiempo = 0;
				if (checkTurn() == true)
				{
					meToca = true;
					Debug.Log("Me toca.");
				}
			}
		}
		if (contador2 >= 3)
		{
			changeturnpopup.text = "";
		}
		if (contadorsave >= 1 && savebool == true)
		{
			StartCoroutine(botonsave());
			savebool = false;
		}
		if (puzzleprogress == 16 && finalPartida == false)
		{
			saveGame();
			results.SetActive(true);
			defeat.SetActive(false);
			victory.SetActive(true);
			finalPartida = true;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
			if (Application.platform == RuntimePlatform.Android)
		{
			saveGame();
			botonsave();
			Application.LoadLevel("PruebaMatchlist");
		}
		//SI SE HABILITA, CRASHEA EN WAITING TURN
		/*if (popUp.activeInHierarchy == true && change == true)
        {
            advertisement.Show();
            change = false;
        }
        if (popUp.activeInHierarchy == false && change == false)
        {
            advertisement.Hide();
            change = true;
        }*/
	}
	public void fichei()
	{
		//Mueve la pieza "del turno siguiente" a la pieza "usable en el turno"
		StorageResponse.fg = "";
		if (firstTimeGame == true)
		{
			actualPiece.mainTexture = texpieces[aux];
			currentpieceposition[0] = aux;
			rotcurrentpiece.transform.eulerAngles = rotnextpiece.transform.eulerAngles;
			if (crot == 0f)
			{
				igualacero = true;
			}
			else
			{
				igualacero = false;
			}
			actualRot = crot;
			mystats.puzzles.cpiece[1] = actualRot;
			currentpieceposition[1] = (int)actualRot;
		}
		//Añade una pieza a la pieza "del turno siguiente"
		id = aux;
		mystats.puzzles.cpiece[0] = id;
		if (cola.Count > 0)
		{
			aux = cola.Dequeue();
			mystats.puzzles.npiece[0] = aux;
			mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
			followingPiece.mainTexture = texpieces[aux];
		}
		else
		{
			followingPiece.mainTexture = empty;
		}
		nextpieceposition[0] = aux;
		//Rotacion Aleatoria
		int rot = UnityEngine.Random.Range(0, 4);
		rotnextpiece.transform.eulerAngles = new Vector3(0, 0, 0);
		switch (rot)
		{
		case 0:
			rotnextpiece.transform.eulerAngles = new Vector3(0f, 0f, 0.0f);
			crot = 0f;
			break;
			
		case 1:
			rotnextpiece.transform.eulerAngles = new Vector3(0f, 0f, 90.0f);
			crot = 90f;
			break;
			
		case 2:
			rotnextpiece.transform.eulerAngles = new Vector3(0f, 0f, 180.0f);
			crot = 180f;
			break;
		case 3:
			rotnextpiece.transform.eulerAngles = new Vector3(0f, 0f, 270.0f);
			crot = 270f;
			break;
		}
		mystats.puzzles.npiece[1] = crot;
		nextpieceposition[1] = (int)crot;
		firsttime = true;
		endturn.isEnabled = false;
	}
	public void saveGame() //Termina el turno y envia la informacion a la nube
	{
		popUp.SetActive(true);
		meToca = false;
		endturn.isEnabled = false;
			idjson = mystats.idjson;
			/*
            jsonObj = StorageResponse.fg;
            Dictionary<string, object> jsonDoc = new Dictionary<string, object>();
            */
			value3 = oponente;
			value4 = "true";
			turn = turn + 1;
			round = (turn - 1) / 2;
			value1 = round.ToString();
			value2 = turn.ToString();
			mystats.puzzles.myprogress = puzzleprogress;
			mystats.puzzles.myoppprogress = puzzleoppprogress;
			mystats.puzzles.cpiece[0] = 100;
			//Actualiza el progreso de los jugadores en la partida
			if (jugador == "1")
			{
				value5 = mystats.idplayer2;
				value9 = mystats.idplayer;
				value6 = puzzleprogress.ToString();
				value7 = puzzleoppprogress.ToString();
			}
			else
			{
				value5 = mystats.idplayer;
				value9 = mystats.idplayer2;
				value7 = puzzleprogress.ToString();
				value6 = puzzleoppprogress.ToString();
			}
			/*
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
            jsonDoc.Add(key12, value12);
            storageService = sp.BuildStorageService();
            storageService.UpdateDocumentByDocId(dbName, mystats.idplayer + "'s Games", mystats.yourIdJson, jsonDoc, callBack);
            */
			
			//Updating match information.
			KiiObject obj = KiiObject.CreateByUri(new Uri(mystats.idjson));
			obj.Refresh((KiiObject obj2, Exception e) =>
			            {
				if (e != null)
				{
					Debug.LogError("Retreving Object failed: " + e.ToString());
					// handle error
					return;
				}
				else
				{
					mystats.groupURL = (string)obj2[key12]; //Coje el group Uri
					value12 = mystats.groupURL;
				}
				
				//Update following information
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
				
				obj2.SaveAllFields(false, (KiiObject updatedObj, Exception e2) =>
				                   {
					if (e2 != null)
					{
						Debug.LogError("Update Object failed: " + e2.ToString());
						// handle error
					}
					else
					{
						Debug.Log(value9 + " has finished his turn successfully.");
					}
				});
			});
			if (firstsavegame == false)
			{
				
			}
			else
			{
				firstsavegame = false;
			}
			
			/*
            queueService = sp.BuildQueueService();
            queueService.SendMessage(mystats.idjson + mystats.idplayer2 + "Queue", "TeToca", long.MaxValue, callMessage);
            */
			
			if (rendirse == false)
			{
				//Updating match information.
				KiiObject obj3 = KiiObject.CreateByUri(new Uri(mystats.groupURL));
				obj3.Refresh((KiiObject obj2, Exception e) =>
				             {
					if (e != null)
					{
						Debug.LogError("Retreving Object failed: " + e.ToString());
						// handle error
						return;
					}
					valuepieces = puzzleprogress.ToString();
					Debug.Log("Aqui el turno es de: " + valueplayersturn);
					Debug.Log("Aqui mystats.idplayer2 es: " + valueplayersturn);
					valueplayersturn = mystats.idplayer2;
					Debug.Log("Aqui el turno es de: " + valueplayersturn);
					//Update following information
					obj2[keypieces] = valuepieces;
					obj2[keyplayersturn] = valueplayersturn;
					
					obj2.SaveAllFields(false, (KiiObject updatedObj, Exception e2) =>
					                   {
						if (e2 != null)
						{
							Debug.LogError("Update Object failed: " + e2.ToString());
							// handle error
						}
						else
						{
							Debug.Log("MatchInfo updated successfully.");
						}
					});
				});
				/*
                    queueService = sp.BuildQueueService();
                    queueService.SendMessage(mystats.idjson + mystats.idplayer2 + "Pieces", puzzleprogress.ToString(), long.MaxValue, piecesMessage);
                    */
			}
			else
			{
				//Updating match information.
				KiiObject obj3 = KiiObject.CreateByUri(new Uri(mystats.groupURL));
				obj3.Refresh((KiiObject obj2, Exception e) =>
				             {
					if (e != null)
					{
						Debug.LogError("Retreving Object failed: " + e.ToString());
						// handle error
						return;
					}
					valuepieces = "100";
					valueplayersturn = mystats.idplayer2;
					//Update following information
					obj2[keypieces] = valuepieces;
					obj2[keyplayersturn] = valueplayersturn;
					
					obj2.SaveAllFields(false, (KiiObject updatedObj, Exception e2) =>
					                   {
						if (e2 != null)
						{
							Debug.LogError("Update Object failed: " + e2.ToString());
							// handle error
						}
						else
						{
							Debug.Log(value9 + " has finished his turn successfully.");
						}
					});
				});
				Uri objUri = new Uri(mystats.idjson);
				KiiObject objj = KiiObject.CreateByUri(objUri);
				
				objj.Delete((KiiObject deletedObj, Exception e2) =>
				            {
					if (e2 != null)
					{
						// handle error
					}
				});
				/*
                    queueService = sp.BuildQueueService();
                    queueService.SendMessage(mystats.idjson + mystats.idplayer2 + "Pieces", "100", long.MaxValue, piecesMessage);
                    storageService = sp.BuildStorageService();
                    storageService.DeleteDocumentById(dbName, collectionName, idjson, callBack);
                    */
			}
			//Aqui hay que cambiar el añadido para que el otro vea que le toca y gane.
			/*
            if (rendirse == false)
            {
                queueService = sp.BuildQueueService();
                queueService.SendMessage(mystats.idjson + mystats.idplayer2 + "Pieces", puzzleprogress.ToString(), long.MaxValue, piecesMessage);
            }
            else
            {
                queueService = sp.BuildQueueService();
                queueService.SendMessage(mystats.idjson + mystats.idplayer2 + "Pieces", "100", long.MaxValue, piecesMessage);
                storageService = sp.BuildStorageService();
                storageService.DeleteDocumentById(dbName, collectionName, idjson, callBack);
            }
            */
			firstsavegame = true;
			mensajeRecibido = true;
			Debug.Log("Turno finalizado. Informacion guardada en la nube.");
			userName = mystats.idplayer2;
			/*
            Debug.Log("Contenido FG: " + MessageResponse.fg);
            message = "Tu oponente ya ha terminado su turno. TE TOCA!";
            PushNotificationService pushService = sp.BuildPushNotificationService();
            PushNotificationService pushNotificationService = sp.BuildPushNotificationService();
            */
			/*
            #if UNITY_ANDROID
            pushService.SendPushMessageToUser(userName, message, callBack);
            #endif
            #if UNITY_IPHONE
            pushNotificationService.SendPushMessageToUser(userName, message, pushiOSBack);
            #endif
            */
			tiempo = 0.0f;
			tiempo2 = 0.0f;
		gamevalue56 = "2";
	}
	public bool checkTurn() //Verifica si le ha llegado el mensaje "Te Toca"
	{
		/* Retrieve the Object from Kii Cloud with a URI.
		KiiObject obj = KiiObject.CreateByUri(new Uri(mystats.groupURL));
		obj.Refresh((KiiObject refreshedObj, Exception e) =>
		            {
			if (e != null)
			{
				// handle error
				return;
			}
			// Get key-value pairs.
			valuepieces = (string)refreshedObj[keypieces];
			valueplayersturn = (string)refreshedObj[keyplayersturn];
			if (valueplayersturn == mystats.idplayer)
			{
				mensajeRecibido = true;
			} else if(valuepieces == "100"){
				mensajeRecibido = true;
			}
		});*/
		//queueService = sp.BuildQueueService();
		//queueService.ReceiveMessage(mystats.idjson + mystats.idplayer + "Queue", 10000, callMessage);
		//queueService.ReceiveMessage(mystats.idjson + mystats.idplayer + "Pieces", 10000, piecesMessage);
		/*if (mensajeRecibido == true)
		{
			gamevalue56 = "1";
			mensajeRecibido = false;
			if (firstsavegame == true)
			{
				firstsavegame = false;
				nextanimation.Play("Next_to_Currentpiece");
				interstitialloaded = true;
				#if UNITY_ANDROID
				StartAppWrapper.showAd();
				StartAppWrapper.loadAd();
				#endif
				#if UNITY_IPHONE
				StartAppWrapperiOS.showAd();
				#endif
				return false;
			}
			else
			{*/
				nextanimation.Play("Idle");
				currentanimation.Play("Idle");
				for (int x = 0; x < 15; x++)
				{
					casillaanimation[x].Play("Idle");
				}
				for (int x = 0; x < 3; x++)
				{
					draweranimation[x].Play("Idle");
				}
				puzzleoppprogress = int.Parse(valuepieces);
				if (puzzleoppprogress == 16)
				{
					results.SetActive(true);
					victory.SetActive(false);
					defeat.SetActive(true);
				}
				else if (puzzleoppprogress == 100)
				{
					surrendervictory.SetActive(true);
				}
				else
				{
					/*
                    jsonObj = StorageResponse.fg;
                    storageService = sp.BuildStorageService();
                    storageService.FindDocumentById(dbName, collectionName, idjson, callBack);
                    */
					contador2 = 0;
					firstTimeGame = true;
					//Verifica si se han terminado de colocar todas las piezas
					ppnumber.text = "" + puzzleoppprogress;
					value4 = "true";
					if (jugador == "2")
					{
						value5 = mystats.idplayer;
					}
					else
					{
						value5 = mystats.idplayer2;
					}
					//value5 = conversor.sacarinfo(key5, jsonObj);
					fichei();
				}
			//}
			popUp.SetActive(false);
			changeturnpopup.text = "Te Toca";
			return true;
	}
	public void botonback()
	{
		//Regresa al menu de seleccion de partidas
		savebool = true;
		contadorsave = 0.0f;
	}
	public void botonhelp()
	{
		if (clicked == false)
		{
			helpbutton.SetActive(false);
			helpbuttonexit.SetActive(true);
			helpToggle.SetActive(true);
			clicked = true;
		}
		else
		{
			clicked = false;
			helpbuttonexit.SetActive(false);
			helpbutton.SetActive(true);
			helpToggle.SetActive(false);
		}
	}
	public void botonSurrender()
	{
		SurrenderPopUp.SetActive(true);
	}
	public void acceptsurrender()
	{
		rendirse = true;
		Uri objUri = new Uri(mystats.yourIdJson);
		KiiObject obj = KiiObject.CreateByUri(objUri);
		
		obj.Delete((KiiObject deletedObj, Exception e) =>
		           {
			if (e != null)
			{
				// handle error
			}
		});
		KiiObject obj2 = KiiObject.CreateByUri(new Uri(mystats.groupURL));
		obj2[keypieces] = "100";
		obj2[keyplayersturn] = mystats.idplayer2;
		
		obj2.SaveAllFields(true, (KiiObject updatedObj, Exception e) =>
		                   {
			if (e != null)
			{
				// handle error
			}
		});
		/*
        queueService = sp.BuildQueueService();
        queueService.SendMessage(mystats.idjson + mystats.idplayer + "Queue", "TeToca", long.MaxValue, callMessage);
        queueService.SendMessage(mystats.idjson + mystats.idplayer + "Pieces", "100", long.MaxValue, piecesMessage);
        storageService = sp.BuildStorageService();
        storageService.DeleteDocumentById(dbName, collectionName, idjson, callBack);
        */
		finalPartida = true;
		//File.Delete(Application.persistentDataPath + "/savegame_" + idjson + ".dat");
		Application.LoadLevel("PruebaMatchlist");
	}
	public void cancelSurrender()
	{
		SurrenderPopUp.SetActive(false);
	}
	public void botoncontinue()
	{
		//Regresa al menu de seleccion de partidas (una vez finaliza la partida)
		Debug.Log("Si hay un error justo aqui, estoy en Botoncontinue, y no se si debe hacer Savegame()");
		saveGame();
		Uri objUri = new Uri(mystats.idjson);
		KiiObject obj = KiiObject.CreateByUri(objUri);
		
		obj.Delete((KiiObject deletedObj, Exception e) =>
		           {
			if (e != null)
			{
				// handle error
			}
		});
		Uri objUri2 = new Uri(mystats.yourIdJson);
		KiiObject obj2 = KiiObject.CreateByUri(objUri);
		
		obj2.Delete((KiiObject deletedObj, Exception e) =>
		            {
			if (e != null)
			{
				// handle error
			}
		});
		KiiObject obj3 = KiiObject.CreateByUri(new Uri(mystats.groupURL));
		
		obj3.Delete((KiiObject deletedObj, Exception e) =>
		            {
			if (e != null)
			{
				// handle error
			}
		});
		/*
        queueService = sp.BuildQueueService();
        queueService.DeletePullQueue(mystats.idjson + mystats.idplayer2 + "Queue", callMessage);
        queueService.DeletePullQueue(mystats.idjson + mystats.idplayer2 + "Pieces", piecesMessage);
        */
		Application.LoadLevel("PruebaMatchlist");
	}
	public void IATurn()
	{
		int chance;
		opportunitiesIA = opportunitiesIA + 1;
		chance = (int)UnityEngine.Random.Range(0.0f, 32.0f);
		if (opportunitiesIA >= chance) {
			puzzleoppprogress = puzzleoppprogress + 1;
			opportunitiesIA = opportunitiesIA + 2;
		}
		mensajeRecibido = true;
	}
	public void continuesurrender()
	{
		Uri objUri = new Uri(mystats.idjson);
		KiiObject obj = KiiObject.CreateByUri(objUri);
		
		obj.Delete((KiiObject deletedObj, Exception e) =>
		           {
			if (e != null)
			{
				// handle error
			}
		});
		Debug.Log("Esta es la Uri de la partida en TUS partidas: " + mystats.yourIdJson);
		KiiObject obj2 = KiiObject.CreateByUri(new Uri(mystats.yourIdJson));
		
		obj2.Delete((KiiObject deletedObj, Exception e) =>
		            {
			if (e != null)
			{
				// handle error
			}
		});
		KiiObject obj3 = KiiObject.CreateByUri(new Uri(mystats.groupURL));
		
		obj3.Delete((KiiObject deletedObj, Exception e) =>
		            {
			if (e != null)
			{
				// handle error
			}
		});
		/*
        queueService = sp.BuildQueueService();
        queueService.DeletePullQueue(mystats.idjson + mystats.idplayer2 + "Queue", callMessage);
        queueService.DeletePullQueue(mystats.idjson + mystats.idplayer2 + "Pieces", piecesMessage);
        storageService = sp.BuildStorageService();
        storageService.DeleteDocumentById(dbName, collectionName, idjson, callBack);
        */
		//File.Delete(Application.persistentDataPath + "/savegame_" + idjson + ".dat");
		Application.LoadLevel("PruebaMatchlist");
	}
	IEnumerator botonsave()
	{
		gamevalue1 = mystats.idjson;
		gamevalue2 = mystats.yourIdJson;
		gamevalue3 = mystats.puzzles.pieces[0].ToString();
		gamevalue4 = mystats.puzzles.pieces[1].ToString();
		gamevalue5 = mystats.puzzles.pieces[2].ToString();
		gamevalue6 = mystats.puzzles.pieces[3].ToString();
		gamevalue7 = mystats.puzzles.pieces[4].ToString();
		gamevalue8 = mystats.puzzles.pieces[5].ToString();
		gamevalue9 = mystats.puzzles.pieces[6].ToString();
		gamevalue10 = mystats.puzzles.pieces[7].ToString();
		gamevalue11 = mystats.puzzles.pieces[8].ToString();
		gamevalue12 = mystats.puzzles.pieces[9].ToString();
		gamevalue13 = mystats.puzzles.pieces[10].ToString();
		gamevalue14 = mystats.puzzles.pieces[11].ToString();
		gamevalue15 = mystats.puzzles.pieces[12].ToString();
		gamevalue16 = mystats.puzzles.pieces[13].ToString();
		gamevalue17 = mystats.puzzles.pieces[14].ToString();
		gamevalue18 = mystats.puzzles.pieces[15].ToString();
		gamevalue19 = mystats.puzzles.drawer[0, 0].ToString();
		gamevalue20 = mystats.puzzles.drawer[1, 0].ToString();
		gamevalue21 = mystats.puzzles.drawer[2, 0].ToString();
		gamevalue22 = mystats.puzzles.drawer[3, 0].ToString();
		gamevalue23 = mystats.puzzles.cpiece[0].ToString();
		gamevalue24 = mystats.puzzles.npiece[0].ToString();
		gamevalue25 = mystats.puzzles.deck[0].ToString();
		gamevalue26 = mystats.puzzles.deck[1].ToString();
		gamevalue27 = mystats.puzzles.deck[2].ToString();
		gamevalue28 = mystats.puzzles.deck[3].ToString();
		gamevalue29 = mystats.puzzles.deck[4].ToString();
		gamevalue30 = mystats.puzzles.deck[5].ToString();
		gamevalue31 = mystats.puzzles.deck[6].ToString();
		gamevalue32 = mystats.puzzles.deck[7].ToString();
		gamevalue33 = mystats.puzzles.deck[8].ToString();
		gamevalue34 = mystats.puzzles.deck[9].ToString();
		gamevalue35 = mystats.puzzles.deck[10].ToString();
		gamevalue36 = mystats.puzzles.deck[11].ToString();
		gamevalue37 = mystats.puzzles.deck[12].ToString();
		gamevalue38 = mystats.puzzles.deck[13].ToString();
		gamevalue39 = mystats.puzzles.deck[14].ToString();
		gamevalue40 = mystats.puzzles.deck[15].ToString();
		gamevalue41 = mystats.puzzles.drawer[0, 1].ToString();
		gamevalue42 = mystats.puzzles.drawer[1, 1].ToString();
		gamevalue43 = mystats.puzzles.drawer[2, 1].ToString();
		gamevalue44 = mystats.puzzles.drawer[3, 1].ToString();
		gamevalue45 = mystats.puzzles.cpiece[1].ToString();
		gamevalue46 = mystats.puzzles.npiece[1].ToString();
		gamevalue47 = mystats.jugador;
		gamevalue48 = mystats.puzzles.t.ToString();
		gamevalue49 = mystats.puzzles.r.ToString();
		gamevalue50 = mystats.puzzles.maxDeckValue.ToString();
		gamevalue51 = mystats.puzzles.puzzleID.ToString();
		gamevalue52 = mystats.puzzles.myprogress.ToString();
		gamevalue53 = mystats.puzzles.myoppprogress.ToString();
		gamevalue54 = mystats.oponente;
		gamevalue55 = mystats.host;
		
		KiiObject obj = KiiUser.CurrentUser.Bucket(mystats.idplayer + "SaveGames").NewKiiObject();
		
		// Set key-value pairs
		obj[gamekey1] = gamevalue1;
		obj[gamekey2] = gamevalue2;
		obj[gamekey3] = gamevalue3;
		obj[gamekey4] = gamevalue4;
		obj[gamekey5] = gamevalue5;
		obj[gamekey6] = gamevalue6;
		obj[gamekey7] = gamevalue7;
		obj[gamekey8] = gamevalue8;
		obj[gamekey9] = gamevalue9;
		obj[gamekey10] = gamevalue10;
		obj[gamekey11] = gamevalue11;
		obj[gamekey12] = gamevalue12;
		obj[gamekey13] = gamevalue13;
		obj[gamekey14] = gamevalue14;
		obj[gamekey15] = gamevalue15;
		obj[gamekey16] = gamevalue16;
		obj[gamekey17] = gamevalue17;
		obj[gamekey18] = gamevalue18;
		obj[gamekey19] = gamevalue19;
		obj[gamekey20] = gamevalue20;
		obj[gamekey21] = gamevalue21;
		obj[gamekey22] = gamevalue22;
		obj[gamekey23] = gamevalue23;
		obj[gamekey24] = gamevalue24;
		obj[gamekey25] = gamevalue25;
		obj[gamekey26] = gamevalue26;
		obj[gamekey27] = gamevalue27;
		obj[gamekey28] = gamevalue28;
		obj[gamekey29] = gamevalue29;
		obj[gamekey30] = gamevalue30;
		obj[gamekey31] = gamevalue31;
		obj[gamekey32] = gamevalue32;
		obj[gamekey33] = gamevalue33;
		obj[gamekey34] = gamevalue34;
		obj[gamekey35] = gamevalue35;
		obj[gamekey36] = gamevalue36;
		obj[gamekey37] = gamevalue37;
		obj[gamekey38] = gamevalue38;
		obj[gamekey39] = gamevalue39;
		obj[gamekey40] = gamevalue40;
		obj[gamekey41] = gamevalue41;
		obj[gamekey42] = gamevalue42;
		obj[gamekey43] = gamevalue43;
		obj[gamekey44] = gamevalue44;
		obj[gamekey45] = gamevalue45;
		obj[gamekey46] = gamevalue46;
		obj[gamekey47] = gamevalue47;
		obj[gamekey48] = gamevalue48;
		obj[gamekey49] = gamevalue49;
		obj[gamekey50] = gamevalue50;
		obj[gamekey51] = gamevalue51;
		obj[gamekey52] = gamevalue52;
		obj[gamekey53] = gamevalue53;
		obj[gamekey54] = gamevalue54;
		obj[gamekey55] = gamevalue55;
		obj[gamekey56] = gamevalue56;
		
		// Save the object
		obj.Save((KiiObject savedObj, Exception e) =>
		         {
			if (e != null)
			{
				Debug.LogError("Error when doing Botonsave: "+ e.ToString());
			}
			else
			{
				
				Debug.Log("Match information has been created with Botonsave ()");
			}
		});
		/*
        Dictionary<string, object> jsonSave = new Dictionary<string, object>();
        jsonSave.Add(gamekey1, gamevalue1);
        jsonSave.Add(gamekey2, gamevalue2);
        jsonSave.Add(gamekey3, gamevalue3);
        jsonSave.Add(gamekey4, gamevalue4);
        jsonSave.Add(gamekey5, gamevalue5);
        jsonSave.Add(gamekey6, gamevalue6);
        jsonSave.Add(gamekey7, gamevalue7);
        jsonSave.Add(gamekey8, gamevalue8);
        jsonSave.Add(gamekey9, gamevalue9);
        jsonSave.Add(gamekey10, gamevalue10);
        jsonSave.Add(gamekey11, gamevalue11);
        jsonSave.Add(gamekey12, gamevalue12);
        jsonSave.Add(gamekey13, gamevalue13);
        jsonSave.Add(gamekey14, gamevalue14);
        jsonSave.Add(gamekey15, gamevalue15);
        jsonSave.Add(gamekey16, gamevalue16);
        jsonSave.Add(gamekey17, gamevalue17);
        jsonSave.Add(gamekey18, gamevalue18);
        jsonSave.Add(gamekey19, gamevalue19);
        jsonSave.Add(gamekey20, gamevalue20);
        jsonSave.Add(gamekey21, gamevalue21);
        jsonSave.Add(gamekey22, gamevalue22);
        jsonSave.Add(gamekey23, gamevalue23);
        jsonSave.Add(gamekey24, gamevalue24);
        jsonSave.Add(gamekey25, gamevalue25);
        jsonSave.Add(gamekey26, gamevalue26);
        jsonSave.Add(gamekey27, gamevalue27);
        jsonSave.Add(gamekey28, gamevalue28);
        jsonSave.Add(gamekey29, gamevalue29);
        jsonSave.Add(gamekey30, gamevalue30);
        jsonSave.Add(gamekey31, gamevalue31);
        jsonSave.Add(gamekey32, gamevalue32);
        jsonSave.Add(gamekey33, gamevalue33);
        jsonSave.Add(gamekey34, gamevalue34);
        jsonSave.Add(gamekey35, gamevalue35);
        jsonSave.Add(gamekey36, gamevalue36);
        jsonSave.Add(gamekey37, gamevalue37);
        jsonSave.Add(gamekey38, gamevalue38);
        jsonSave.Add(gamekey39, gamevalue39);
        jsonSave.Add(gamekey40, gamevalue40);
        jsonSave.Add(gamekey41, gamevalue41);
        jsonSave.Add(gamekey42, gamevalue42);
        jsonSave.Add(gamekey43, gamevalue43);
        jsonSave.Add(gamekey44, gamevalue44);
        jsonSave.Add(gamekey45, gamevalue45);
        jsonSave.Add(gamekey46, gamevalue46);
        jsonSave.Add(gamekey47, gamevalue47);
        jsonSave.Add(gamekey48, gamevalue48);
        jsonSave.Add(gamekey49, gamevalue49);
        jsonSave.Add(gamekey50, gamevalue50);
        jsonSave.Add(gamekey51, gamevalue51);
        jsonSave.Add(gamekey52, gamevalue52);
        jsonSave.Add(gamekey53, gamevalue53);
        jsonSave.Add(gamekey54, gamevalue54);
        jsonSave.Add(gamekey55, gamevalue55);
        storageService = sp.BuildStorageService();
        storageService.UpdateDocumentByDocId(dbName, mystats.idplayer + "myDataBase", mystats.yourIdJson, jsonSave, savedGames);
        storageService.InsertJSONDocument(dbName, mystats.idplayer + "myDataBase", jsonSave, savedGames);
        */
		yield return new WaitForSeconds(1);
		Application.LoadLevel("PruebaMatchlist");
	}
	public void botonload()
	{
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter si = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)si.Deserialize(file);
			file.Close();
			mystats.idplayer = data.userGuest;
			Application.LoadLevel("PruebaMatchList");
			
		}
		else
		{
			//menuprincipal.SetActive (false);
			//menulogin.SetActive (true);
			//Match.SetActive (true);
		}
	}
	public void clickrotation()
	{
		//Rotar pieza "del turno actual" antes de colocarla
		if (actualRot == 270f)
		{
			igualacero = true;
		}
		else
		{
			igualacero = false;
		}
		rotcurrentpiece.transform.Rotate(0f, 0f, 90f);
		actualRot = actualRot + 90f;
		if (actualRot == 360f)
		{
			actualRot = 0f;
		}
	}
	//Mazo de Piezas del Puzzle (desordenadas)
	public void deck()
	{
		int[] temporal = randomvalidator;
		for (int x = 0; x < randomvalidator.Length; x++)
		{
			randomNumber = (int)UnityEngine.Random.Range(0.0f, (float)randomlength);
			cola.Enqueue(temporal[randomNumber]);
			mystats.puzzles.deck[x] = temporal[randomNumber];
			temporal[randomNumber] = temporal[randomlength];
			randomlength = randomlength - 1;
		}
		mystats.puzzles.maxDeckValue = 16;
	}
	//----------------------CAJON------------------------------------
	public void slot1()
	{
		if (firsttime == false && fullorempty[0] == true && correct == true)
		{
			actualPiece.mainTexture = cajon[0].mainTexture;
			contador--;
			cajon[0].mainTexture = empty;
			fullorempty[0] = false;
			firsttime = true;
			id = idscajon[0];
			mystats.puzzles.cpiece[0] = id;
			rotcurrentpiece.transform.eulerAngles = cajon[0].transform.eulerAngles;
			int cajonrotcero;
			switch ((int)rotcajon[0])
			{
			case 0:
				cajonrotcero = 0;
				break;
				
			case 90:
				cajonrotcero = 1;
				break;
				
			case 180:
				cajonrotcero = 2;
				break;
			case 270:
				cajonrotcero = 3;
				break;
			}
			actualRot = rotcajon[0];
			mystats.puzzles.cpiece[1] = actualRot;
			mystats.puzzles.drawer[0,0] = 100;
		}
	}
	public void slot2()
	{
		if (firsttime == false && fullorempty[1] == true && correct == true)
		{
			actualPiece.mainTexture = cajon[1].mainTexture;
			contador--;
			cajon[1].mainTexture = empty;
			fullorempty[1] = false;
			firsttime = true;
			id = idscajon[1];
			mystats.puzzles.cpiece[0] = id;
			rotcurrentpiece.transform.eulerAngles = cajon[1].transform.eulerAngles;
			int cajonrotcero;
			switch ((int)rotcajon[1])
			{
			case 0:
				cajonrotcero = 0;
				break;
				
			case 90:
				cajonrotcero = 1;
				break;
				
			case 180:
				cajonrotcero = 2;
				break;
			case 270:
				cajonrotcero = 3;
				break;
			}
			actualRot = rotcajon[1];
			mystats.puzzles.cpiece[1] = actualRot;
			mystats.puzzles.drawer[1, 0] = 100;
		}
	}
	public void slot3()
	{
		if (firsttime == false && fullorempty[2] == true && correct == true)
		{
			actualPiece.mainTexture = cajon[2].mainTexture;
			contador--;
			cajon[2].mainTexture = empty;
			fullorempty[2] = false;
			firsttime = true;
			id = idscajon[2];
			mystats.puzzles.cpiece[0] = id;
			rotcurrentpiece.transform.eulerAngles = cajon[2].transform.eulerAngles;
			int cajonrotcero;
			switch ((int)rotcajon[2])
			{
			case 0:
				cajonrotcero = 0;
				break;
				
			case 90:
				cajonrotcero = 1;
				break;
				
			case 180:
				cajonrotcero = 2;
				break;
			case 270:
				cajonrotcero = 3;
				break;
			}
			actualRot = rotcajon[2];
			mystats.puzzles.cpiece[1] = actualRot;
			mystats.puzzles.drawer[2, 0] = 100;
		}
	}
	public void slot4()
	{
		if (firsttime == false && fullorempty[3] == true && correct == true)
		{
			actualPiece.mainTexture = cajon[3].mainTexture;
			contador--;
			cajon[3].mainTexture = empty;
			fullorempty[3] = false;
			firsttime = true;
			id = idscajon[3];
			mystats.puzzles.cpiece[0] = id;
			rotcurrentpiece.transform.eulerAngles = cajon[3].transform.eulerAngles;
			int cajonrotcero;
			switch ((int)rotcajon[3])
			{
			case 0:
				cajonrotcero = 0;
				break;
				
			case 90:
				cajonrotcero = 1;
				break;
				
			case 180:
				cajonrotcero = 2;
				break;
			case 270:
				cajonrotcero = 3;
				break;
			}
			actualRot = rotcajon[3];
			mystats.puzzles.cpiece[1] = actualRot;
			mystats.puzzles.drawer[3, 0] = 100;
		}
	}
	//-------------------------Fin CAJON-------------------------------------
	//--------------------------CASILLAS-------------------------------------
	public void confirm1()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[0] && igualacero == true)
			{
				casillaanimation[0].SetBool("userGuessed", true);
				casillaanimation[0].SetTrigger("isP1");
				piezas[0].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[0] = 1;
				gamevalue3 = mystats.puzzles.deck[0].ToString();
				mystats.puzzles.pieces[0] = true;
				casilla[0].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[0] = true;
			}
			else
			{
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
						
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm2()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[1] && igualacero == true)
			{
				casillaanimation[1].SetBool("userGuessed", true);
				casillaanimation[1].SetTrigger("isP2");
				piezas[1].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[1] = 1;
				gamevalue4 = mystats.puzzles.deck[1].ToString();
				mystats.puzzles.pieces[1] = true;
				casilla[1].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[1] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
		
	}
	public void confirm3()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[2] && igualacero == true)
			{
				
				casillaanimation[2].SetBool("userGuessed", true);
				casillaanimation[2].SetTrigger("isP3");
				piezas[2].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[2] = 1;
				gamevalue5 = mystats.puzzles.deck[2].ToString();
				mystats.puzzles.pieces[2] = true;
				casilla[2].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[2] = true;
			}
			else
			{
				;
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm4()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[3] && igualacero == true)
			{
				
				casillaanimation[3].SetBool("userGuessed", true);
				casillaanimation[3].SetTrigger("isP4");
				piezas[3].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[3] = 1;
				gamevalue6 = mystats.puzzles.deck[3].ToString();
				mystats.puzzles.pieces[3] = true;
				casilla[3].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[3] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm5()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[4] && igualacero == true)
			{
				casillaanimation[4].SetBool("userGuessed", true);
				casillaanimation[4].SetTrigger("isP5");
				piezas[4].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[4] = 1;
				gamevalue7 = mystats.puzzles.deck[4].ToString();
				mystats.puzzles.pieces[4] = true;
				casilla[4].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[4] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm6()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[5] && igualacero == true)
			{
				casillaanimation[5].SetBool("userGuessed", true);
				casillaanimation[5].SetTrigger("isP6");
				piezas[5].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[5] = 1;
				gamevalue8 = mystats.puzzles.deck[5].ToString();
				mystats.puzzles.pieces[5] = true;
				casilla[5].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[5] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm7()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[6] && igualacero == true)
			{
				
				casillaanimation[6].SetBool("userGuessed", true);
				casillaanimation[6].SetTrigger("isP7");
				piezas[6].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[6] = 1;
				gamevalue9 = mystats.puzzles.deck[6].ToString();
				mystats.puzzles.pieces[6] = true;
				casilla[6].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[6] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm8()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[7] && igualacero == true)
			{
				
				casillaanimation[7].SetBool("userGuessed", true);
				casillaanimation[7].SetTrigger("isP8");
				piezas[7].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[7] = 1;
				gamevalue10 = mystats.puzzles.deck[7].ToString();
				mystats.puzzles.pieces[7] = true;
				casilla[7].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[7] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm9()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[8] && igualacero == true)
			{
				
				casillaanimation[8].SetBool("userGuessed", true);
				casillaanimation[8].SetTrigger("isP9");
				piezas[8].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[8] = 1;
				gamevalue11 = mystats.puzzles.deck[8].ToString();
				mystats.puzzles.pieces[8] = true;
				casilla[8].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[8] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm10()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[9] && igualacero == true)
			{
				
				casillaanimation[9].SetBool("userGuessed", true);
				casillaanimation[9].SetTrigger("isP10");
				piezas[9].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[9] = 1;
				gamevalue12 = mystats.puzzles.deck[9].ToString();
				mystats.puzzles.pieces[9] = true;
				casilla[9].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[9] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm11()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[10] && igualacero == true)
			{
				
				casillaanimation[10].SetBool("userGuessed", true);
				casillaanimation[10].SetTrigger("isP11");
				piezas[10].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[10] = 1;
				gamevalue13 = mystats.puzzles.deck[10].ToString();
				mystats.puzzles.pieces[10] = true;
				casilla[10].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[10] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm12()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[11] && igualacero == true)
			{
				
				casillaanimation[11].SetBool("userGuessed", true);
				casillaanimation[11].SetTrigger("isP12");
				piezas[11].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[11] = 1;
				gamevalue14 = mystats.puzzles.deck[11].ToString();
				mystats.puzzles.pieces[11] = true;
				casilla[11].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[11] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm13()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[12] && igualacero == true)
			{
				
				casillaanimation[12].SetBool("userGuessed", true);
				casillaanimation[12].SetTrigger("isP13");
				piezas[12].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[12] = 1;
				gamevalue15 = mystats.puzzles.deck[12].ToString();
				mystats.puzzles.pieces[12] = true;
				casilla[12].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[12] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm14()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[13] && igualacero == true)
			{
				
				casillaanimation[13].SetBool("userGuessed", true);
				casillaanimation[13].SetTrigger("isP14");
				piezas[13].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[13] = 1;
				gamevalue16 = mystats.puzzles.deck[13].ToString();
				mystats.puzzles.pieces[13] = true;
				casilla[13].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[13] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm15()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[14] && igualacero == true)
			{
				
				casillaanimation[14].SetBool("userGuessed", true);
				casillaanimation[14].SetTrigger("isP15");
				piezas[14].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[14] = 1;
				gamevalue17 = mystats.puzzles.deck[14].ToString();
				mystats.puzzles.pieces[14] = true;
				casilla[14].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[14] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	public void confirm16()
	{
		if (firsttime == true)
		{
			mystats.puzzles.cpiece[0] = 100;
			if (id == positioner[15] && igualacero == true)
			{
				
				casillaanimation[15].SetBool("userGuessed", true);
				casillaanimation[15].SetTrigger("isP16");
				piezas[15].mainTexture = actualPiece.mainTexture;
				currentanimation.SetBool("backToCurrent", true);
				correct = true;
				mystats.puzzles.maxDeckValue = mystats.puzzles.maxDeckValue - 1;
				mystats.puzzles.deck[15] = 1;
				gamevalue18 = mystats.puzzles.deck[15].ToString();
				mystats.puzzles.pieces[15] = true;
				casilla[15].isEnabled = false;
				puzzleprogress = puzzleprogress + 1;
				opnumber.text = "" + puzzleprogress;
				Debug.Log("ACIERTO, PIEZA CORRECTAMENTE COLOCADA.");
				llenoornot[15] = true;
			}
			else
			{
				
				contador++;
				if (contador > 4)
				{
					contador = 4;
					cola.Enqueue(id);
				}
				else
				{
					for (int x = 0; x < 4; x++)
					{
						if (fullorempty[x] == false)
						{
							rotcajon[x] = actualRot;
							mystats.puzzles.drawer[x, 1] = actualRot;
							cajon[x].mainTexture = actualPiece.mainTexture;
							cajon[x].transform.eulerAngles = rotcurrentpiece.transform.eulerAngles;
							idscajon[x] = id;
							mystats.puzzles.drawer[x, 0] = id;
							fullorempty[x] = true;
							int cajonrotcero = 0;
							switch ((int)rotcajon[3])
							{
							case 0:
								cajonrotcero = 0;
								break;
								
							case 90:
								cajonrotcero = 1;
								break;
								
							case 180:
								cajonrotcero = 2;
								break;
							case 270:
								cajonrotcero = 3;
								break;
							}
							drawerposition[x, cajonrotcero] = idscajon[x];
							Debug.Log(drawerposition[x, cajonrotcero]);
							break;
						}
					}
					draweranimation[contador - 1].SetTrigger("userFailed");
					draweranimation[contador - 1].Play("D" + contador + "_to_Currentpiece");
				}
				correct = false;
				Debug.Log("FALLO, PIEZA MAL COLOCADA.");
			}
			actualPiece.mainTexture = empty;
			firsttime = false;
			endturn.isEnabled = true;
		}
	}
	//--------------------------------Fin CASILLAS----------------------------------
}
/*
[Serializable]
class loadableinfo
{
	public int puzzle;
	public bool[] pieces;
	public int[,] drawer;
	public int[] currpiece;
	public int[] nxtpiece;
	public string jsonid;
	public int playerProgress;
	public int opponentProgress;
	public string player;
	public string oponente;
	public string idplayer1;
	public string idplayer2;
	public int rnd;
	public int trn;
	public int ax;
	public int ID;
}
*/