using UnityEngine;
using System.Collections;

public class CheckController
{

	public CheckController(Game game)
	{
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		Round _round = game.roundData.data.round [0];
		if(_game.currturn==_game.player1)
		{
			_round.p1bet = "999";
		}
		else if(_game.currturn==_game.player2)
		{
			_round.p2bet = "999";
		}
	}
}
