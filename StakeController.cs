using UnityEngine;
using System.Collections;

public class StakeController
{
	public StakeController(Game game)
	{
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		string winner = game.GetWinnerName ();
		if(winner==_game.player1)
		{
			_game.player1stake = (_game.player1stake.ToInt() + _game.currpot.ToInt()).ToString();
		}
		else if(winner==_game.player2)
		{
			_game.player2stake = (_game.player2stake.ToInt() + _game.currpot.ToInt()).ToString();
		}
		_game.currpot = "0";
	}
}
