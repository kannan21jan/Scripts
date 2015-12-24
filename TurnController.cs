using UnityEngine;
using System.Collections;

public class TurnController 
{
	public TurnController(Game game)
	{
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		if(_game.currturn==_game.player1)
		{
			_game.currturn = _game.player2;
		}
		else if(_game.currturn==_game.player2)
		{
			_game.currturn = _game.player1;
		}
	}
}
