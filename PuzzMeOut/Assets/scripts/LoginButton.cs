using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using System;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.user;
using AssemblyCSharp;


public class LoginButton : MonoBehaviour {
	
	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease,
		Custom,
	}
	
	
	
	public Trigger trigger = Trigger.OnClick;
	
	
	
	public UILabel name;
	public UIInput pass;
	public GameObject clabel; 
	string userName;
	string pwd;
	ServiceAPI sp = null;
	UserService userService = null;
	UserResponse callBack = new UserResponse ();
	//public static bool Validator (object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
	//{return true;}
	void Start (){
        sp = new ServiceAPI("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078");
		clabel.SetActive(false);
	}
	
	
	
	 void OnClick ()
	{
		userName = name.text;
		pwd = pass.value;
		if (trigger == Trigger.OnClick) {

			userService = sp.BuildUserService ();
			userService.Authenticate(userName,pwd, callBack); 
	
			//ServicePointManager.ServerCertificateValidationCallback = Validator;
			Debug.Log ("El Usuario se ha logueado.");
			clabel.SetActive(true);
		}
		
	}
	
	
	
	
}
