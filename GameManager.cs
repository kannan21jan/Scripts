using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameManager : SingletonEternal<GameManager> 
{

	public Game game=new Game();

	public PendingGamesRoot pendingGames = new PendingGamesRoot();
	
	public List<string> currentWord = new List<string>();

	public AudioClip wordFound;

	public UserStatistics statistics;


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.G))
		{
			GetStats();
		}
		if(Input.GetKeyDown(KeyCode.P))
		{
			statistics.Update();
		}
	}

	protected virtual void Start () 
	{
		EventsManager.instance.CreateSolitareGameEvent += CreateSolitareGame;
		EventsManager.instance.CreateGuruGameEvent += CreateMultiplayerGame;
		EventsManager.instance.cardSelectedEvent += FormWord;
		EventsManager.instance.cardSelectedEvent += CheckIfWordFound;
		EventsManager.instance.cardDeSelectedEvent += ReFormWord;
		EventsManager.instance.wordFound += WordFound;
		StartCoroutine (GettingPendingGames());
	}
	
	protected virtual void OnDisable () 
	{
		if(EventsManager.instance!=null)
		{
			EventsManager.instance.CreateSolitareGameEvent -= CreateSolitareGame;
			EventsManager.instance.CreateGuruGameEvent -= CreateMultiplayerGame;
			EventsManager.instance.cardSelectedEvent -= FormWord;
			EventsManager.instance.cardSelectedEvent -= CheckIfWordFound;
			EventsManager.instance.cardDeSelectedEvent -= ReFormWord;
			EventsManager.instance.wordFound -= WordFound;
		}
	}

	IEnumerator GettingPendingGames()
	{
		while (true) 
		{
			if (SceneManager.GetActiveScene ().name == Scene.menu) 
			{
				string url = Url.getPendingGames + FB.UserId;
				WWW www = new WWW (url);
				yield return www;
				PendingGamesRoot temp = www.text.ToClass<PendingGamesRoot> ();
				if (temp.ToJson () != pendingGames.ToJson ()) 
				{
					GetPendingGames ();
			    }
				yield return new WaitForSeconds (10);
			} 
			else
				yield return null;
		}
	}
	
	public void GetPendingGames()
	{
		string url = Url.getPendingGames + FB.UserId;
		MyRequest.CreateRequest (url,GetPendingGamesCallback);
	}

	void GetPendingGamesCallback(WWW www)
	{
		pendingGames = www.text.ToClass<PendingGamesRoot> ();
		if ((pendingGames.data.yourturns.Count - 1)!= statistics.activegames)
			statistics.ActiveGames ((pendingGames.data.yourturns.Count));

		if (SceneManager.GetActiveScene().name==Scene.menu)
		{
			WBGuru.instance.CheckForSystemGames();
			NotificationsGUI.instance.ConstructGUI ();
			ScrollRefresh.instance.stop = false;
		}
	}

	void CreateSolitareGame()
	{
		MyRequest.CreateRequest (Url.createSolitareGame,CreateSolitareGameCallback);
	}

	public void CreateSolitareGameCallback(WWW request)
	{
		game = request.text.ToClass<Game> ();
		game.mode = GameMode.solitare;
		SceneManagerExtension.instance.LoadScene (Scene.game);
	}

	public void GetStats()
	{
		string link = Url.getMember;
		link = link.Replace ("{name}",FB.UserId);
		MyRequest.CreateRequest (link,GetStatsCallback);
	}

	void GetStatsCallback(WWW www)
	{
		statistics = www.text.TrimLooseEnds().ToClass<UserStatisticsRoot>().member;
	}

	void CreateMultiplayerGame(string opponent)
	{
		string link = Url.createMultiplayerGame.Replace ("{player1}",FB.UserId);
		link = link.Replace ("{player2}",opponent);
		MyRequest.CreateRequest (link,CreateMultiplayerGameCallback);
	}


	void CreateMultiplayerGameCallback(WWW ww)
	{
		game.mode = GameMode.multiplayer;
		game.multiplayerGame = ww.text.ToClass<MultiplayerGameRoot>();
		game.Init ();
		game.GetRoundInfos ();
		SceneManagerExtension.instance.LoadScene (Scene.game);
	}

	void FormWord(Card card)
	{
		for(int i=0;i<currentWord.Count;i++)
		{
			if(currentWord[i]=="")
			{
				currentWord[i] = card.letter.text;
				break;
			}
		}
	}

	void CheckIfWordFound(Card card)
	{
		string wordFormed = string.Join ("",currentWord.ToArray());
		try
		{
			Word word = new Word();
			if(game.mode==GameMode.solitare)
			{
				word = game.data.worddefs.Where(a=>a.word==wordFormed.ToLower()).First();
			}
			else if(game.mode==GameMode.multiplayer)
			{
				word = game.roundWords.data.worddef.Where(a=>a.word==wordFormed.ToLower()).First();
			}
			if(!game.wordsFound.Contains(word))
			{
				EventsManager.instance.wordFound(word);
				game.wordsFound.Add(word);
			}
		}
		catch{}
	}

	void ReFormWord(Card card)
	{
		if(card.destination!=null)
		{
			int index = GameGUI.instance.GetIndex (card.destination);
			currentWord [index] = "";
		}
	}

	void WordFound(Word word)
	{
		GameObject obj = new GameObject ("wordfound");
		AudioSource source = obj.AddComponent<AudioSource>();
		source.clip = wordFound;
		source.Play ();
		Destroy (obj,wordFound.length);
		for(int i=0;i<currentWord.Count;i++)
		{
			currentWord[i] = "";
		}
		if(word.score>statistics.bestWordScore)
		{
			statistics.UpdateWord(word);
		}
		Utility.DisableButtons ();
		GameGUI.instance.ClearsCards (2);
	}

	void OnApplicationQuit()
	{
//		statistics.LastSeen ();
	}

}
