using System;
using com.shephertz.app42.paas.sdk.csharp.pushNotification;
using com.shephertz.app42.paas.sdk.csharp.storage;
using com.shephertz.app42.paas.sdk.csharp;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class PushNotificationResponse : App42CallBack 
	{   
	public void OnSuccess(object response)  
	{  
		PushNotification pushNotification = (PushNotification) response;    
			Debug.Log("Notification for " + pushNotification.GetUserName());  
			Debug.Log("Device Type is " +  pushNotification.GetType());  
			Debug.Log("DeviceToken is " +  pushNotification.GetDeviceToken());
            Debug.Log("Message is: " + pushNotification.GetMessage());
            Debug.Log("Sent on date&time : " + pushNotification.GetExpiry());
            Debug.Log("pushNotification : " + pushNotification.GetStrResponse());
            Debug.Log("pushNotification : " + pushNotification.GetTotalRecords());
	}  
	
	public void OnException(Exception e)  
	{  
			Debug.Log("Exception : " + e);  
	}  
}
}