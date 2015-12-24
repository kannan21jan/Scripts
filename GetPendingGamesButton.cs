using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GetPendingGamesButton : ButtonComponent
{

	public override void OnPointerUp (PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		GameManager.instance.GetPendingGames ();
	}
}
