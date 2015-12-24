using UnityEngine;
using System.Collections;

public class SingletonEternal<T> : Singleton<T> where T : MonoBehaviour
{

	protected override void Awake ()
	{
		base.Awake ();
		DontDestroyOnLoad (gameObject);
	}
}
