using UnityEngine;
using System.Collections;

public class WinLostTurnController  
{
	public WinLostTurnController(Game game)
	{
		string winner = game.GetWinnerName ();
		if (winner == FB.UserId && EventsManager.instance.won!=null)
			EventsManager.instance.won ();
		else if(EventsManager.instance.lost!=null)
			EventsManager.instance.lost ();
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		if(winner==_game.player1)
		{
			_game.currturn = _game.player1;
		}
		else if(winner==_game.player2)
		{
			_game.currturn = _game.player2;
		}
	}
}
