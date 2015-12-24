using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : SingletonEternal<LoadingScreen>
{
	void Start()
	{
		gameObject.SetActive (false);
	}

	public void StartLoading()
	{
		gameObject.SetActive (true);
	}


	public void StopLoading()
	{
		gameObject.SetActive (false);
	}
}
