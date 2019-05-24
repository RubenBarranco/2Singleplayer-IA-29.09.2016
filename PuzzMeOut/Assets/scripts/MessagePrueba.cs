using UnityEngine;
using System.Collections;
using com.shephertz.app42.paas.sdk.csharp;    
using com.shephertz.app42.paas.sdk.csharp.message;
using AssemblyCSharp;

public class MessagePrueba : MonoBehaviour {
	ServiceAPI sp = null;
	QueueService queueService = null;
	MessageResponse MessageBack = new MessageResponse();
	public UIButton crear, enviar, recibir;
	public UILabel textoenviar;

	// Use this for initialization
	void Start () {
        sp = new ServiceAPI("cc5e4b986d3d998ac24752f4796db9da71b4ca958a405d4da416a5e254762284", "4ff997d23e3d2ae89e207a1899f0be8b3df96da3ec0118f64d7fe1859d0a6078"); 
	}
	
	// Update is called once per frame
	void Update () {
		textoenviar.text = MessageResponse.fg;
	}
	public void enviarmensaje () {
		string queueName = "MyQueue";  
		string message = "Hola Mundo.";  
		long  expiryTime = 10000; 
		queueService = sp.BuildQueueService();
		queueService.SendMessage(queueName, message, expiryTime,MessageBack);
	}
	public void recibirmensaje () {
		string queueName = "MyQueue";  
		long  receiveTimeOut = 10000;
		queueService = sp.BuildQueueService();
		queueService.ReceiveMessage(queueName, receiveTimeOut, MessageBack); 
	}
	public void crearcola () {
		string queueName = "MyQueue";  
		string queueDescription = "Cola para turnos de partida.";
		queueService = sp.BuildQueueService();
		queueService.CreatePullQueue(queueName, queueDescription, MessageBack);
	}
}
