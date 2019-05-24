using UnityEngine;
using System.Collections;
using SimpleJSON;
public class jsonPrueba : MonoBehaviour {
	JSONObject pruebi = null;
	string palabra;
	int numero;
	string key;
	//access data (and print it)
	void accessData(JSONObject obj){
		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
				accessData(j);
			}
			break;
		//case JSONObject.Type.ARRAY:
		//	foreach(JSONObject j in obj.list){
		//		accessData(j);
		//	}
		//	break;
		case JSONObject.Type.STRING:
			Debug.Log(obj.str);
			break;
		case JSONObject.Type.NUMBER:
			Debug.Log(obj.n);
			break;
		case JSONObject.Type.BOOL:
			Debug.Log(obj.b);
			break;
		case JSONObject.Type.NULL:
			Debug.Log("NULL");
			break;
			
		}
	}
	public bool convertir (string jsonObject, string jugador, string llave) {
		//Compara el key y el value enviadas con las de la nube
		pruebi = new JSONObject (jsonObject);
		accessData (pruebi);
		for (int x = 0; x<pruebi.list.Count; x++) {
			string compare = pruebi.keys[x].ToString();
			string compare2 = pruebi.list[x].str;
			compare2.Replace ("\"","");
			Debug.Log ("EN LA NUBE -> KEY: "+compare+" VALUE: "+compare2);
			if (compare == llave){
				Debug.Log ("KEY: "+compare+" enviado para comparar con la nube.");
				if (compare2 == jugador){
					Debug.Log ("VALUE: "+compare2+" enviado para comparar con la nube");
					return true;
				}
			}
		}
		return false;
	}
	public string sacarinfo(string jugador, string jsonObject) {
		//Busca la key especifica en la nube y devuele el value
		pruebi = new JSONObject (jsonObject);
		accessData (pruebi);
		for (int x= 0; x<pruebi.list.Count; x++) {
			string compare = pruebi.keys[x].ToString();
			string nfichasopp = pruebi.list [x].str;
			if (compare == jugador)  {
				return nfichasopp;
			}
		}
		return null;
	}
	}
