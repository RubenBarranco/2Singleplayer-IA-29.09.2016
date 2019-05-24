using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.message;
using AssemblyCSharp;

public class CrearPrueba : MonoBehaviour {
	ServiceAPI sp = null;
	QueueService queueService = null;
	MessageResponse MessageBack = new MessageResponse();
	// Use this for initialization
	void Start () {
		sp = new ServiceAPI("43f6b65747952492b5e30056ac9539ef7c50b44c4178e7c361cfa3b20ee52095","e09348180158fb9304906d696dec68b3e2f074747a09ec93284271627f7c2599"); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseUpAsButton () {
		string queueName = "MyQueue";  
		string queueDescription = "Cola para turnos de partida.";
		queueService = sp.BuildQueueService();
		queueService.CreatePullQueue(queueName, queueDescription, MessageBack);
	}
}