using UnityEngine;
using System.Collections;

public class ScrollRefresh : Singleton<ScrollRefresh> 
{


	public bool stop;


	void Start () 
	{

	}

	public void Scrolling(Vector2 val)
	{
		if (val == new Vector2 (0.0f, 1.0f) && !stop)
		{
			GameManager.instance.GetPendingGames();
			stop = true;
		}
	}
}
