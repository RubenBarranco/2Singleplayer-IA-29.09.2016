using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using System.Collections.Generic;
using System;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.user;
using AssemblyCSharp;


public class RegisterButton : MonoBehaviour {

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
	
	//bool mIsOver = false;


	
	public UILabel name;
	public UILabel mail;
	public UIInput passv;
	public GameObject clabel; 
	string userName = "123456";
	string pwd = "123456";
	string emailId = "123456";
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
		
		if (trigger == Trigger.OnClick) {


			userName = name.text;
			//Debug.Log("pv "+passv.value);
			pwd = passv.value;
			//Debug.Log("pvs "+pwd );
			emailId = mail.text;
			userService = sp.BuildUserService ();
			userService.CreateUser (userName, pwd, emailId, callBack);
			//ServicePointManager.ServerCertificateValidationCallback = Validator;
			Debug.Log ("El Usuario ha sido creado.");
			clabel.SetActive(true);
		}
		
	}
	

	

}
