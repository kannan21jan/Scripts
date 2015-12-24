using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CardClearer : NormalButton
{

	public override void OnPointerUp (PointerEventData eventData)
	{
		if(eventData.dragging)
		{
			GameGUI.instance.ClearsCards(0);
		}
	}
}