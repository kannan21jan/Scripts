using UnityEngine;
using System;

[System.Serializable]
public class UserStatistics
{
	public string name;
	public string email;
	public string pwd;
	public int ranking;
	public int games;
	public int challengesIssued;
	public int challengesWon;
	public int challengesReceived;
	public int challengesReceivedWon;
	public string bestWord;
	public int bestWordScore;
	public int chips;
	public string lastSeen;
	public int activegames;
	public int averagescore;
	public int averagewinnings;
	public int roundsWon;
	public int roundsLost;
	public string facebookId;
	public string displayName;


	public void CreateGame()
	{
		games++;
		challengesIssued++;
		Update ();
	}

	public void ActiveGames(int no)
	{
		if(no>1)
		{
			activegames = no-1;
			Update ();
		}
	}


	public void LastSeen()
	{
		lastSeen = DateTime.Now.Date.ToString();
		Update ();
	}


	public void UpdateWord(Word word)
	{
		bestWord = word.word;
		bestWordScore = word.score;
	}

	public void Chips(int chips)
	{
		this.chips = chips;
		Update ();
	}

	public void ChallengeReceived()
	{
		challengesReceived++;
		Update ();
	}

	public void RoundWon(bool val)
	{
		if(val)
		{
			if(GameManager.instance.game.multiplayerGame.data.games[0].currround.ToInt()==3)
			{
				if(FB.UserId==GameManager.instance.game.multiplayerGame.data.games[0].player1)
					challengesWon++;
				else
					challengesReceivedWon++;
			}
			roundsWon++;
		}
		else
		{
			roundsLost++;
		}
		Update ();
	}


	public void Update()
	{
		string data = this.ToJson ();
		data = Url.updateMember+WWW.EscapeURL(data);
		MyRequest.CreateRequest (data);
	}
}

[System.Serializable]
public class UserStatisticsRoot
{
	public UserStatistics member;
}