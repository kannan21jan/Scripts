using UnityEngine;
using System.Collections;

public class WinnerController
{
	public WinnerController(Game game,string reason)
	{
		Round _round = game.roundData.data.round [0];
		_round.winner = game.GetWinnerName ();
		_round.winreason = reason;
	}
}
