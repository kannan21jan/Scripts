using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class Hand
{
	public string ch;
	public int cv;
}

[Serializable]
public class Community
{
	public string ch;
	public int cv;
}

[Serializable]
public class Word
{
	public string word;
	public int score;
	public string xplode;
	public string bonus;
}

[Serializable]
public class GameData
{
	public List<Hand> hands;
	public List<Community> communities;
	public List<Word> worddefs;
}

[Serializable]
public class Game
{
	public GameMode mode;
	public GameData data;
	Word maxWord=null;
	int? noOfWords=null;
	ParameterlessDelegate gotGame=null;
	public List<Word> wordsFound=new List<Word>();

	public Rounds rounds;

	public MultiplayerGameRoot multiplayerGame = new MultiplayerGameRoot();
	
	public GetRoundDataRoot roundData = new GetRoundDataRoot();
	
	public RoundWordsRoot roundWords = new RoundWordsRoot();


	public void Init()
	{
		multiplayerGame.data.games [0].player1stake = Values.chips;
		multiplayerGame.data.games [0].player2stake = Values.chips;
	}

	public void GetMultiplayerGame(MultiplayerGame game,ParameterlessDelegate callback=null)
	{
		rounds = new Rounds (game.gameID);
		mode = GameMode.multiplayer;
		if(multiplayerGame.data.games.Count==0)
		{
			multiplayerGame.data.games.Add(new MultiplayerGame());
		}
		multiplayerGame.data.games [0] = game;
		GetRoundInfos ();
		if(callback!=null)
		gotGame = callback;
	}

	string GetCurrentPlayerIndex()
	{
		MultiplayerGame _g = multiplayerGame.data.games [0];
		if(_g.currturn==_g.player1)
		{
			return "1";
		}
		else if(_g.currturn==_g.player2)
		{
			return "2";
		}
		return "1";
	}
	
	public void GetRoundInfos()
	{
		string link = Url.getRoundWords.Replace ("{gameid}",multiplayerGame.data.games[0].gameID);
		link = link.Replace("{round}",multiplayerGame.data.games[0].currround);
		link = link.Replace("{player}",GetCurrentPlayerIndex());
		MyRequest.CreateRequest (link,GetRoundWordsCallback);
		link = Url.getRoundData.Replace ("{gameid}",multiplayerGame.data.games[0].gameID);
		link = link.Replace ("{round}",multiplayerGame.data.games[0].currround);
		MyRequest.CreateRequest (link,GetRoundDataCallback);
	}

	void GetRoundWordsCallback(WWW ww)
	{
		this.roundWords = ww.text.ToClass<RoundWordsRoot>();
	}
	
	void GetRoundDataCallback(WWW ww)
	{
		this.roundData = ww.text.ToClass<GetRoundDataRoot>();
		if(gotGame!=null)
		{
			gotGame ();
			gotGame = null;
		}
	}

	public Word MaxWord()
	{
		if(mode==GameMode.solitare)
		{
			maxWord = data.worddefs.OrderByDescending(a=>a.score).First();
		}
		else
		{
			maxWord = roundWords.data.worddef.OrderByDescending(a=>a.score).First();
		}
		return maxWord;
	}


	public Word MyMaxWord()
	{
		return wordsFound.OrderByDescending(a=>a.score).First();
	}

	public int NoOfWords()
	{
		if(noOfWords==null)
		{
			noOfWords = data.worddefs.Count;
		}
		return (int)noOfWords;
	}


	public string GetWinnerName()
	{
		MultiplayerGame _game = multiplayerGame.data.games [0];
		Round _round = roundData.data.round [0];
		if (_round.p1score.ToInt() > _round.p2score.ToInt())
			return _game.player1;
		else
			return _game.player2;
	}

	public bool IsNotLastRound()
	{
		return this.multiplayerGame.data.games [0].currround.ToInt() <= 2;
	}

	public bool FirstRound()
	{
		MultiplayerGame game = multiplayerGame.data.games [0];
		Round round = roundData.data.round [0];
		if(game.currturn == game.player1)
		{
			if(!string.IsNullOrEmpty(round.p1word) && round.p1score!="0")
				return false;
			return round.p1bet == "0";
		}
		else
		{
			if(!string.IsNullOrEmpty(round.p2word) && round.p2score!="0")
				return false;
			return round.p2bet == "0";
		}
	}

	public bool Checkable()
	{
		return roundData.data.round [0].p1bet.ToInt () == 0 && roundData.data.round [0].p2bet.ToInt () == 0 && roundData.data.round [0].p1bet.ToInt () != 999 && roundData.data.round [0].p2bet.ToInt () != 999;
	}

	public bool FinalRound()
	{
		return ((roundData.data.round [0].p1bet.ToInt () != 0 && roundData.data.round [0].p2bet.ToInt () != 0) || (roundData.data.round [0].p1score.ToInt() != 0 && roundData.data.round [0].p2score.ToInt() != 0));
	}


	public string CurrentChips()
	{
		MultiplayerGame g = multiplayerGame.data.games [0];
		if(g.currturn==g.player1)
		{
			return g.player1stake;
		}
		else
		{
			return g.player2stake;
		}
	}

	void Update()
	{
		string multiplayer = Url.updateMultiplayerGame+WWW.EscapeURL(multiplayerGame.data.games[0].ToJson());
		string roundInfo = Url.updateRoundInfo + WWW.EscapeURL(roundData.data.round[0].ToJson ());
		MyRequest.CreateRequest (multiplayer);
		MyRequest.CreateRequest (roundInfo,UpdateCallback);
	}

	void Update(bool val)
	{
		string multiplayer = Url.updateMultiplayerGame+WWW.EscapeURL(multiplayerGame.data.games[0].ToJson());
		string roundInfo = Url.updateRoundInfo + WWW.EscapeURL(roundData.data.round[0].ToJson ());
		MyRequest.CreateRequest (multiplayer);
		MyRequest.CreateRequest (roundInfo,UpdateCallback2);
	}

	void UpdateCallback(WWW www)
	{
		GameManager.instance.GetPendingGames ();
		SceneManagerExtension.instance.LoadScene (Scene.menu);
	}

	void UpdateCallback2(WWW www)
	{
		GameManager.instance.GetPendingGames ();
	}

	public void Fold()
	{
		new FoldPenaltyController (this);
		new StakeController (this);
		new RoundController (this);
		if(multiplayerGame.data.games[0].currturn!="System")
		new FoldTurnController (this);
		if(EventsManager.instance.lost!=null)
		EventsManager.instance.lost ();
		Update (false);
	}

	public void Check()
	{
		new CheckController (this);
		new WordController (this);
		new TurnController (this);
		Update ();
	}

	public void Raise(int amount)
	{
		new BetController (this,amount);
		new WordController (this);
		new TurnController (this);
		Update ();
	}

	public void Call()
	{
		new BetDifferenceController (this);
		new WordController (this);
		new StakeController (this);
		new RoundController (this);
		new WinnerController(this,this.GetWinnerName()+" has found the max word");
		new WinLostTurnController (this);
		Update (false);
	}
}

public enum GameMode
{
	solitare,
	multiplayer
}


