using System;
using com.shephertz.app42.paas.sdk.csharp.storage;
using com.shephertz.app42.paas.sdk.csharp;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class StorageResponse : App42CallBack
	{
		public static string fg = null;
		public static string id = null;
        public string fg1 = null;
        public string id1 = null;
		public static string resul = null;
		public static IList<Storage.JSONDocument> take;
		public IList<Storage.JSONDocument> take1;
		private string result = "";
		 public void OnSuccess(object obj)
        {
			result = obj.ToString();
			resul = "excepsion";
			if (obj is Storage)
			{
				Storage storage = (Storage)obj;
				Debug.Log ("Storage Response : " + storage);
				IList<Storage.JSONDocument> jsonDocList = storage.GetJsonDocList();
				take = jsonDocList;
				take1 = take;
				for(int i=0;i<storage.GetJsonDocList().Count;i++){
					App42Log.Console("ObjectId is : " + jsonDocList[i].GetDocId());
					App42Log.Console("jsonDoc is : " + jsonDocList[i].GetJsonDoc());
					fg = jsonDocList[i].GetJsonDoc();
					id = jsonDocList[i].GetDocId();
                    fg1 = fg;
                    id1 = id;
				}
			}
		}
	

        public void OnException(Exception e)
        {
			result = e.ToString();
			resul = "exception";
            App42Log.Console("Exception is : " + e);

		}
		
		public string getResult() {
			return result;
		}
	}
      
}

