using UnityEngine;
using System.Collections;

public class Initiator : MonoBehaviour 
{
	void Start () 
	{
		StartCoroutine(Initiate ());
	}


	IEnumerator Initiate()
	{
		FB.Init (null);
		while (!FB.IsInitialized)
			yield return null;
		if(FB.IsLoggedIn)
		{
			string url = Url.signup;
			url += FB.UserId;
			MyRequest.CreateRequest(url);
			SceneManagerExtension.instance.LoadScene(Scene.menu);
		}
		else
			SceneManagerExtension.instance.LoadScene(Scene.login);
	}
}
