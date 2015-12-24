using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InviteButton : ButtonComponent 
{

	public override void OnPointerUp (PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		FacebookManager.instance.Invite ();
	}
}
