using System.Collections.Generic;
using System;

[Serializable]
public class MultiplayerGame
{
	public string gameID;
	public string player1;
	public string player2;
	public string deck;
	public string numrounds;
	public string jackpot;
	public string currround;
	public string currturn;
	public string state;
	public string lastmove;
	public string currpot;
	public string player1stake;
	public string player2stake;
	public string p1rounds;
	public string p2rounds;
}

[Serializable]
public class MultiplayerGameData
{
	public List<MultiplayerGame> games = new List<MultiplayerGame>();
}

[Serializable]
public class MultiplayerGameRoot
{
	public MultiplayerGameData data = new MultiplayerGameData();
}

[Serializable]
public class RoundWordsData
{
	public string message;
	public List<Word> worddef = new List<Word>();
}

[Serializable]
public class RoundWordsRoot
{
	public RoundWordsData data = new RoundWordsData();
}

[Serializable]
public class Round
{
	public string cc1;
	public string cc2;
	public string cc3;
	public string cc4;
	public string cc5;
	public string roundid;
	public string p1c1;
	public string p1c2;
	public string p2c1;
	public string p2c2;
	public string p1word;
	public string p2word;
	public string p1score;
	public string p2score;
	public string p1bet;
	public string p2bet;
	public string roundpot;
	public string playerturn;
	public string gameid;
	public string cc1v;
	public string cc2v;
	public string cc3v;
	public string cc4v;
	public string cc5v;
	public string p1c1v;
	public string p1c2v;
	public string p2c1v;
	public string p2c2v;
	public string winner;
	public string winreason;
}

[Serializable]
public class GetRoundData
{
	public string message;
	public List<Round> round = new List<Round>();
}

[Serializable]
public class GetRoundDataRoot
{
	public GetRoundData data = new GetRoundData();
}

