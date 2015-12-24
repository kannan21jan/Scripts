using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
	public float seconds;
	public string levelToLoad;
	
	void Start () 
	{
		StartCoroutine (StartTimer());
	}

	IEnumerator StartTimer()
	{
		while(seconds>0)
		{
			seconds--;
			yield return new WaitForSeconds(1);
		}
		if(GameManager.instance.game.mode==GameMode.solitare)
		SceneManagerExtension.instance.LoadScene (levelToLoad);
		else if(GameManager.instance.game.mode==GameMode.multiplayer)
		{
			SceneManagerExtension.instance.LoadScene (Scene.roundSummary);
		}
	}
}
