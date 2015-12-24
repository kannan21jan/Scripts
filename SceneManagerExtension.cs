using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagerExtension : SingletonEternal<SceneManagerExtension>
{


	void Start()
	{

	}


	void OnDisable()
	{

	}

	public void LoadScene(string sceneName)
	{
		StartCoroutine (m_LoadScene(sceneName));
	}


	IEnumerator m_LoadScene(string sceneName)
	{
		yield return SceneManager.LoadSceneAsync (Scene.loading);
		yield return SceneManager.LoadSceneAsync (sceneName);
	}
}
