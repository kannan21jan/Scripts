using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetWordDefinitionButton : ButtonComponent
{
	public Text text;

	public override void OnPointerUp (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		WordlistGUI.instance.GetWordDefinition (text.text);
	}
}