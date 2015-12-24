using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class NormalButton : ButtonComponent
{
	public Button.ButtonClickedEvent onClick;

	public override void OnPointerDown (PointerEventData eventData)
	{
		base.OnPointerDown (eventData);
	}
	
	public override void OnPointerUp (PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		if (onClick != null)
			onClick.Invoke ();
	}
}
 