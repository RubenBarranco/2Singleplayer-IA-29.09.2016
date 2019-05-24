using System;
using com.shephertz.app42.paas.sdk.csharp.message;
using com.shephertz.app42.paas.sdk.csharp;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class MessageResponse : App42CallBack {
		public static string fg = null;

	public void OnSuccess(object response)  
	{  
		com.shephertz.app42.paas.sdk.csharp.message.Queue queue = (com.shephertz.app42.paas.sdk.csharp.message.Queue) response;        
		Debug.Log("QueueName :" + queue.GetQueueName()); 
		Debug.Log("QueueType :" + queue.GetQueueType());  
		IList<com.shephertz.app42.paas.sdk.csharp.message.Queue.Message> messageList = queue.GetMessageList();    
		for(int i = 0; i<messageList.Count; i++)    
		{      
			Debug.Log("CorrelationId : " + messageList[i].GetCorrelationId());    
			Debug.Log("PayLoad MENSAJE"+i+": " + messageList[i].GetPayLoad());
				fg = messageList[i].GetPayLoad();
		}     
		Debug.Log("JsonResponse :" + queue.ToString());
	} 
	public void OnException(Exception e)  
	{  
			Debug.Log("Exception : " + e);
	}  
}
}
