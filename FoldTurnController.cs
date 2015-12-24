using UnityEngine;
using System.Collections;

public class FoldTurnController 
{
	public FoldTurnController(Game game)
	{
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		if(_game.currturn==_game.player1)
		{
			_game.currturn = _game.player2;
			new WinnerController(game,_game.player1+" has folded");
		}
		else if(_game.currturn==_game.player2)
		{
			_game.currturn = _game.player1;
			new WinnerController(game,_game.player2+" has folded");
		}
	}
}
