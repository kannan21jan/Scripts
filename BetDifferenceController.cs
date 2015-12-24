using UnityEngine;
using System.Collections;

public class BetDifferenceController
{

	public BetDifferenceController(Game game)
	{
		int amount = 0;
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		Round _round = game.roundData.data.round [0];
		if(_game.currturn==_game.player1)
		{
			if(_round.p2bet=="999")
				_round.p2bet = "0";
			amount = _round.p2bet.ToInt() - _round.p1bet.ToInt();
			if(_game.player1stake.ToInt()<amount)
				return;
			_game.player1stake = (_game.player1stake.ToInt() - amount).ToString();
			_round.p1bet = (_round.p1bet.ToInt() + amount).ToString();
		}
		else if(_game.currturn==_game.player2)
		{
			if(_round.p1bet=="999")
				_round.p1bet = "0";
			amount = _round.p1bet.ToInt() - _round.p2bet.ToInt();
			if(_game.player2stake.ToInt()<amount)
				return;
			_game.player2stake = (_game.player2stake.ToInt() - amount).ToString();
			_round.p2bet = (_round.p2bet.ToInt() + amount).ToString();
		}
		_game.currpot = (_game.currpot.ToInt() + amount).ToString();
	}
}
