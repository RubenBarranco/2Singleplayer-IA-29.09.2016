using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.user;
using com.shephertz.app42.paas.sdk.csharp.storage;
using com.shephertz.app42.paas.sdk.csharp.message;
using com.shephertz.app42.paas.sdk.csharp.social;
using com.shephertz.app42.paas.sdk.csharp.pushNotification;

public class AsyncApp42Prueba : MonoBehaviour {
	ServiceAPI sp = null;
	UserService userService = null;
	StorageService storageService = null;
	PushNotificationService pushService = null;
	SocialService socialService = null;
	QueueService queueService = null;


	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void AsyncApp42Api () {
		ServiceAPI sp = new ServiceAPI("43f6b65747952492b5e30056ac9539ef7c50b44c4178e7c361cfa3b20ee52095" , "e09348180158fb9304906d696dec68b3e2f074747a09ec93284271627f7c2599");
		this.userService = sp.BuildUserService();
		this.storageService = sp.BuildStorageService();
		this.pushService = sp.BuildPushNotificationService();
		this.socialService=sp.BuildSocialService();
	}
}
