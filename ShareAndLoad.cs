using UnityEngine;
using System.Collections;

public class ShareAndLoad : LoadASceneButton
{

	public override void OnPointerUp (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		FB.Feed (toId:FB.UserId,linkName:"Won a wordbet game!");
	}
}
