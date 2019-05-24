using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SocialPlatforms;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.storage;
using com.shephertz.app42.paas.sdk.csharp.user;
using KiiCorp.Cloud.Unity;
using KiiCorp.Cloud.Storage;
using SimpleJSON;
using AssemblyCSharp;
using StartApp;

public class Login : MonoBehaviour {
	public static Login log;

	jsonPrueba nuevoguest = new jsonPrueba();
	string userguest;
    public int guestnumber;
    string userToken;
    public int numero;
	
	//register variables
	string emailId = "123456";
	string userName;
	string pwd;
	string deviceToken = "Device Token 1";
    float contador;
    bool checklogin;
	public UIInput mailregister;
	public UIInput passregister;
	public UIInput nameregister;
	public UIInput namelogin;
	public UIInput passlogin;
	public GameObject cLabel;
	public GameObject menuprincipal;
	public GameObject menulogin;
	public GameObject menudemo;
	public GameObject message;
	public GameObject stats;
	public GameObject PuzzleP;
	public GameObject Cancel;
	public GameObject Accept;
	public GameObject Register;
	public GameObject LoginNator;
	public GameObject mailNator;
	public GameObject banner;
    public GameObject fullcollider;
	public UILabel faltan;
	public UILabel registerlabel;
	infoPlayer mystats;
	PuzzleProgress ProgressPuzzle;
	AdMobPlugin advertisement;
    JSONClass json = new JSONClass();
	
	//Cosas del APP42
	UserService userService = null;
	ServiceAPI sp = null;
	StorageService storageService = null;
	StorageResponse callBack = new StorageResponse ();
    StorageResponse callBack1 = new StorageResponse();
	UserResponse callBackUser = new UserResponse ();
	string dbName = "Cloud";
	string collectionName = "Guests";
    string jsonid = "5605d10de4b0e65b235a8430";
	
	void Awake (){
		faltan.text = "";
        mystats = stats.GetComponent<infoPlayer>();
        mystats.idplayer2 = "";
        // Forces a different code path in the BinaryFormatter that doesn't rely on run-time code generation (which would break on iOS).
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
	}
	// Use this for initialization
	void Start () {
        fullcollider.SetActive(false);
		menudemo.SetActive (false);
        checklogin = false;
		ProgressPuzzle = PuzzleP.GetComponent <PuzzleProgress> ();
		mystats.puzzles = ProgressPuzzle;
        sp = new ServiceAPI("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
        App42API.Initialize("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
        #if UNITY_ANDROID
        StartAppWrapper.init();
        StartAppWrapper.addBanner(
           StartAppWrapper.BannerType.AUTOMATIC,
           StartAppWrapper.BannerPosition.BOTTOM);
        #endif
        #if UNITY_IPHONE
            StartAppWrapperiOS.unityOrientation(StartAppWrapperiOS.STAUnityOrientation.STALandscape);   
        	StartAppWrapperiOS.addBanner(StartAppWrapperiOS.BannerPosition.BOTTOM);
            StartAppWrapperiOS.disableReturnAd();
        #endif
        /*
        advertisement = banner.GetComponent<AdMobPlugin> ();
		advertisement.verticalPosition = AdVerticalPosition.TOP;
		advertisement.Reconfigure ();
        */
	}
	
	// Update is called once per frame
	void Update () {
        contador = contador + Time.deltaTime;
        if (checklogin == true && contador > 3.0f)
        {
            comprobarlogin();
        }
	}
    public void comprobarlogin()
    {
        if (UserResponse.resul == "vacio")
        {
            Debug.Log("El Usuario se ha logueado.");
            Dictionary<string, object> jsonDoc = new Dictionary<string, object>();
            storageService = sp.BuildStorageService();
            storageService.FindDocumentById(dbName, collectionName, jsonid, callBack);
            
            Save();
            
        }
        else
        {
            message.SetActive (false);
            faltan.text = "Incorrect username or password.";
        }
    }
	public void principal () {
		LoadDemo ();
	}
	public void login () {
		//Espacio para que el usuario se loguee
		userName = namelogin.value;
        mystats.idplayer = userName;
		pwd = passlogin.value;
        faltan.text = "";
		if (userName == "" || pwd == "") {
			faltan.text = "One or more required field(s) are missing.";
		} else {
			message.SetActive (true);
            KiiUser.LogIn(userName, pwd, (KiiUser user, Exception e) =>
            {
                if (e != null)
                {
                    // handle error
                    faltan.text = "Incorrect username or password.";
                    return;
                }
                else
                {
                    Save();
                    Application.LoadLevel("PruebaMatchList");
                }
            });
		}
	}
	public void register () {
		//Espacio para que el usuario se registre
		userName = nameregister.value;
		pwd = passregister.value;
		emailId = mailregister.value;
		if (userName == "" || pwd == "" || emailId == "") {
			faltan.text = "One or more required field(s) are missing.";
		} else {
            /*userService = sp.BuildUserService ();
            userService.CreateUser (userName, pwd, emailId, callBackUser);
            cLabel.SetActive (true);
            Debug.Log ("El Usuario ha sido creado.");
            mystats.idplayer = userName;
            Dictionary <string, object> jsonDoc = new Dictionary <string,object> ();
            storageService = sp.BuildStorageService ();
            storageService.FindDocumentById (dbName, collectionName, jsonid, callBack);
            storageService.InsertJSONDocument(dbName, mystats.idplayer + "myDataBase", json, callBack1);
            */
            mystats.idplayer = userName;
            KiiUser.Builder builder = KiiUser.BuilderWithName(userName);
            builder.WithEmail(emailId);
            KiiUser usr = builder.Build();
            usr.Register(pwd, (KiiUser user, Exception e) =>
            {
                if (e != null)
                {
                    faltan.text = "Password must be between 4 to 50 alphanumeric characters.";
                    Debug.LogError("Signup failed: " + e.ToString());
                    // process error
                }
                else
                {
                    Debug.Log("Signup succeeded.");
                    faltan.text = "Signup succeeded. Signing in...";
                    Save();
                    Application.LoadLevel("PruebaMatchList");
                    // do something with user, it's a valid user now
                }
            });
		}
	}
    IEnumerator waitToSignIn()
    {
        fullcollider.SetActive(true);
        menuprincipal.SetActive(false);
        menulogin.SetActive(true);
        message.SetActive(true);
         KiiUser.LogIn(userName, pwd, (KiiUser user, Exception e) =>
            {
                if (e != null)
                {
                    // handle error
                    faltan.text = "Incorrect username or password.";
                    return;
                }
            });
		
        Debug.Log("USUARIO PRE-LOGUEADO. INICIANDO SESION...");
        yield return new WaitForSeconds(5);
        Application.LoadLevel("PruebaMatchList");
    }
	public void guest () { //Espacio para que el usuario se loguee como invitado
        numero = 1;
        mystats.idplayer = "Guest";
        Debug.Log("Creando nuevo Guest...");
        // Creating Pseudouser.
        UserFields userFields = new UserFields();
        userFields.Displayname = mystats.idplayer;
        userFields["Guest_number"] = numero;
        KiiUser.RegisterAsPseudoUser(userFields, (KiiUser pseudoUser, Exception e) =>
        {
            if (e != null)
            {
                // handle error
                return;
            }
            else
            {
                Debug.Log("GUEST CREADO.");
                message.SetActive(true);
                Debug.Log("STARTING reading from the cloud...");
                // Retrieving Guest number from cloud.
                KiiObject obj = KiiObject.CreateByUri(new Uri("kiicloud://buckets/GuestList/objects/05c8b620-8b07-11e5-ac4d-22000af941bb"));
                obj.Refresh((KiiObject refreshedObj, Exception e2) =>
                {
                    if (e2 != null)
                    {
                        Debug.LogError("Retreving Object failed: " + e2.ToString());
                        // handle error
                        return;
                    }
                    else
                    {
                        // Get key-value pairs.
                        guestnumber = (int)refreshedObj["Guestnumber"];
                        Debug.Log("Guestnumber in cloud: " + guestnumber);
                        Debug.Log("FINISHED reading from the cloud...");
                        numero += guestnumber;
                        //Updating cloud with +1 Guestnumber.
                        KiiObject obj2 = KiiObject.CreateByUri(new Uri("kiicloud://buckets/GuestList/objects/05c8b620-8b07-11e5-ac4d-22000af941bb"));
                        obj2.Refresh((KiiObject obj3, Exception e3) =>
                        {
                            if (e3 != null)
                            {
                                Debug.LogError("Retreving Object failed: " + e3.ToString());
                                // handle error
                                return;
                            }
                            obj3["Guestnumber"] = numero;
                            obj3.SaveAllFields(false, (KiiObject updatedObj, Exception e4) =>
                            {
                                if (e4 != null)
                                {
                                    Debug.LogError("Update Object failed: " + e4.ToString());
                                    // handle error
                                }
                                else
                                {
                                    Debug.Log("Object updated successfully: Guestnumber " + numero);
                                    mystats.idplayer = "Guest" + numero;
                                    Save();
                                    Application.LoadLevel("PruebaMatchList");
                                }
                            });
                        });
                    }
                    // Get key-value pairs.
                    guestnumber = (int)refreshedObj["Guestnumber"];

                });
            }
            // Must save the token.
            // If it's lost the user will not be able to access KiiCloud.
            PlayerPrefs.SetString("token", KiiUser.AccessToken);
            userToken = KiiUser.AccessToken;
        });
	}
	public void Save (){
		BinaryFormatter si = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		PlayerData data = new PlayerData ();
		data.userGuest = mystats.idplayer;
        data.userToken = userToken;
        data.userPWD = pwd;
		si.Serialize (file, data);
		file.Close ();
	}
	public void LoadDemo () {
		menuprincipal.SetActive (false);
		menudemo.SetActive (true);
	}
	public void Singleplayer (){
		Application.LoadLevel("Singleplayer");
	}
	public void Multiplayer (){
		LoadMulti ();
	}
	public void LoadMulti(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter si = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)si.Deserialize (file);
			file.Close ();
			mystats.idplayer = data.userGuest;
            userName = mystats.idplayer;
            pwd = data.userPWD;
            StartCoroutine(waitToSignIn());
		} else {
			menuprincipal.SetActive (false);
			menudemo.SetActive (false);
			menulogin.SetActive (true);
		}
	}
	public void RegisterNator(){
		registerlabel.text = "";
		mailNator.SetActive (true);
		Cancel.SetActive (true);
		Accept.SetActive (true);
		LoginNator.SetActive (false);
	}
	public void cancelNator(){
		registerlabel.text= "Register";
		mailNator.SetActive (false);
		Cancel.SetActive (false);
		Accept.SetActive (false);
		LoginNator.SetActive (true);
		Register.SetActive (true);
	}
}


[Serializable]
class PlayerData
{
	public string userGuest;
    public string userToken;
    public string userPWD;
	public int[] partidasjugadas;
}
