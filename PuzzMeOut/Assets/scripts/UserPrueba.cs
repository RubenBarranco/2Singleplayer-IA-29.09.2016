using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using System;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.user;
using AssemblyCSharp;

	public class UserPrueba : MonoBehaviour
	{ 
	ServiceAPI sp = null;
	UserService userService = null;

	string userName = "Nick";  
	string pwd = "********";  
	string emailId = "nick@shephertz.com";
	UserResponse callBack = new UserResponse ();
	//public static bool Validator (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
	//{return true;}
	void Start (){
        sp = new ServiceAPI("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
	}
	void OnMouseUpAsButton () {
		userService = sp.BuildUserService ();
		userService.CreateUser (userName, pwd, emailId, callBack);
		//ServicePointManager.ServerCertificateValidationCallback = Validator;
		Debug.Log ("El Usuario ha sido creado.");
		}
	}