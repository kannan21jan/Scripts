using UnityEngine;
using System.Collections;

public class MyRequest : MonoBehaviour
{
	WWW request;


	void Start()
	{
		DontDestroyOnLoad (gameObject);
	}

	IEnumerator InitiateWebRequest(string url,MyRequestCallback callback=null)
	{
		request = new WWW (url);
		yield return request;
		if(callback!=null)
		callback (request);
		LoadingScreen.instance.StopLoading ();
		Destroy (gameObject);
	}

	public static void CreateRequest(string url,MyRequestCallback callback=null)
	{
		LoadingScreen.instance.StartLoading ();
		GameObject obj = new GameObject("WebRequest");
		MyRequest script = obj.AddComponent<MyRequest>();
		script.StartCoroutine(script.InitiateWebRequest (url,callback));
	}



}

public delegate void MyRequestCallback(WWW request);
