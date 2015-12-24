using UnityEngine;
using System.Collections;
using System.Linq;

public class WBGuru : SingletonEternal<WBGuru> 
{

	int no=0;

	public Game game = new Game();

	float val;


	void Start()
	{

	}

	public void CheckForSystemGames()
	{
		foreach(var game in GameManager.instance.pendingGames.data.theirturns)
		{
			if(game.game.currturn=="System" && game.game.currround!="4")
			{
				no++;
				this.game.GetMultiplayerGame(game.game,Callback);
			}
		}
	}


	void Callback()
	{
		StartCoroutine(ProcessGame());
	}


	IEnumerator ProcessGame()
	{
		while(game.roundWords.data.worddef.Count==0 || game.roundData.data.round.Count==0)
		{
			yield return null;
		}
		if(game.FirstRound())
		{
			Word word = game.roundWords.data.worddef[Random.Range(0,game.roundWords.data.worddef.Count-1)];
			game.wordsFound.Add (word);
			Word maxword = game.MaxWord ();
			val = ((float)word.score / (float)maxword.score) * 100f;
			if(val<=40)
			{
				game.Raise(20);
			}
			else if(val>40 && val<=70)
			{
				game.Raise(40);
			}
			else if(val>70)
			{
				game.Raise(100);
			}
		}
		else
		{
			if(val<=50)
				game.Fold();
			else if(val>50)
				game.Call();
		}
	}
}
