/*using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class PruebaNET : MonoBehaviour {
	public UIButton email;

	public void pruebaemail (){
		MailMessage mail = new MailMessage();
		
		mail.From = new MailAddress("sashasanchez@gmail.com");
		mail.To.Add("dokairsbc@gmail.com");
		mail.Subject = "HIJOPUTA";
		mail.Body = "A ver si funciona esto...";
		
		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("sashasanchez@gmail.com", "password") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
		smtpServer.Send(mail);
		Debug.Log("Email was sent.");
		
	}
}*/
