using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Linq;

public class CreateGameWithFriendButton : ButtonComponent
{
	public override void OnPointerUp (PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		FriendBar script = transform.parent.GetComponent<FriendBar>();
		var yourTurnP1 = GameManager.instance.pendingGames.data.yourturns.Exists (a=>a.game.player1==script.playerId);
		var yourTurnP2 = GameManager.instance.pendingGames.data.yourturns.Exists (a=>a.game.player2==script.playerId);
		var theirTurnP1 = GameManager.instance.pendingGames.data.theirturns.Exists (a=>a.game.player1==script.playerId);
		var theirTurnP2 = GameManager.instance.pendingGames.data.theirturns.Exists (a=>a.game.player2==script.playerId);
		if(yourTurnP1==false && yourTurnP2==false && theirTurnP1==false && theirTurnP2==false)
		{
			GameManager.instance.statistics.CreateGame ();
			EventsManager.instance.CreateGuruGameEvent (script.playerId);
		}
		else
		{
			FriendsGUI.instance.EnablePopup();
		}
	}
}
