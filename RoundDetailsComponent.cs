using UnityEngine;
using System.Collections;

public class RoundDetailsComponent : MonoBehaviour 
{
	public RoundComponent round1,round2,round3;

	public void Build(Game game)
	{
		round1.left.Fill (game.rounds.round1.p1score.ToInt(),100);
		round1.right.Fill (game.rounds.round1.p2score.ToInt(),100);
		round2.left.Fill (game.rounds.round2.p1score.ToInt(),100);
		round2.right.Fill (game.rounds.round2.p2score.ToInt(),100);
		round3.left.Fill (game.rounds.round3.p1score.ToInt(),100);
		round3.right.Fill (game.rounds.round3.p2score.ToInt(),100);
	}
}
