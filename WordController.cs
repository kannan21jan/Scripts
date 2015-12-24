using UnityEngine;
using System.Collections;

public class WordController 
{

	public WordController(Game game)
	{
		MultiplayerGame _game = game.multiplayerGame.data.games [0];
		Round _round = game.roundData.data.round [0];
		Word word = new Word ();
		try
		{
			word = game.MyMaxWord ();
		}
		catch
		{
			word = new Word();
		}
		if(_game.currturn==_game.player1)
		{
			if(string.IsNullOrEmpty(_round.p1word))
			{
				_round.p1word = word.word;
				_round.p1score = word.score.ToString();
			}
		}
		else if(_game.currturn==_game.player2)
		{
			if(string.IsNullOrEmpty(_round.p2word))
			{
				_round.p2word = word.word;
				_round.p2score = word.score.ToString();
			}
		}
	}
}
