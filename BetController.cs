using UnityEngine;
using System.Collections;

public class BetController 
{

	public BetController(Game game,int amount)
	{
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		Round _round = game.roundData.data.round [0];
		if(_game.currturn==_game.player1)
		{
			if(_round.p2bet=="999")
				_round.p2bet = "0";
			if(_game.player1stake.ToInt()<amount)
				return;
			_game.player1stake = (_game.player1stake.ToInt() - amount).ToString();
			_round.p1bet = amount.ToString();
		}
		else if(_game.currturn==_game.player2)
		{
			if(_round.p1bet=="999")
				_round.p1bet = "0";
			if(_game.player2stake.ToInt()<amount)
				return;
			_game.player2stake = (_game.player2stake.ToInt() - amount).ToString();
			_round.p2bet = amount.ToString();
		}
		_game.currpot = (_game.currpot.ToInt() + amount).ToString();
	}
}
