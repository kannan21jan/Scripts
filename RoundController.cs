using UnityEngine;
using System.Collections;

public class RoundController 
{
	public RoundController(Game game)
	{
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		if (game.IsNotLastRound ())
			_game.currround = (_game.currround.ToInt () + 1).ToString ();
		else
			_game.state = "0.0.0";
	}
}
