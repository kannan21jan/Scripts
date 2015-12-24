using System.Collections.Generic;
using System;

[Serializable]
public class Yourturn
{
	public MultiplayerGame game;

	public string GetOpponentName()
	{
		string result = "";
		if(game.currturn==game.player1)
		{
			result = game.player2;
		}
		else
		{
			result = game.player1;
		}
		if(result!="System")
		foreach(var friend in FacebookManager.instance.fbFriendsResult.data)
		{
			if(result==friend.id)
			{
				result = friend.name;
				break;
			}
		}
		return result;
	}
//	public object chatmsg;
}
[Serializable]
public class Theirturn
{
	public MultiplayerGame game;

	public string GetOpponentName()
	{
		string result = "";
		if(FB.UserId==game.player1)
		{
			result = game.player2;
		}
		else
		{
			result = game.player1;
		}
		if(result!="System")
			foreach(var friend in FacebookManager.instance.fbFriendsResult.data)
		{
			if(result==friend.id)
			{
				result = friend.name;
				break;
			}
		}
		return result;
	}
//	public List<object> chatmsg;
}
[Serializable]
public class CompletedGame
{
	public MultiplayerGame game;
//	public List<object> chatmsg;
}
[Serializable]
public class PendingGamesData
{
	public List<Yourturn> yourturns;
	public List<Theirturn> theirturns;
	public List<CompletedGame> completedgames;
}
[Serializable]
public class PendingGamesRoot
{
	public PendingGamesData data;
}