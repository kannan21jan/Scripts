using UnityEngine;
using System.Collections;

public class FoldPenaltyController 
{
	public FoldPenaltyController(Game game)
	{
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		Round _round = game.roundData.data.round [0];
		if(_game.currturn==_game.player1)
		{
			if(_round.p2bet=="999")
				_round.p2bet = "0";
			_game.player1stake = (_game.player1stake.ToInt() - 20).ToString();
			_round.p1score = "0";
			if(_round.p2score=="0" ||  _round.p2score=="")
				_round.p2score = "1";
		}
		else if(_game.currturn==_game.player2)
		{
			if(_round.p1bet=="999")
				_round.p1bet = "0";
			_game.player2stake = (_game.player2stake.ToInt() - 20).ToString();
			_round.p2score = "0";
			if(_round.p1score=="0" ||  _round.p1score=="")
				_round.p1score = "1";
		}
		_game.currpot = (_game.currpot.ToInt() + 20).ToString();
	}

}
