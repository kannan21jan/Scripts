using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ActionButton : ButtonComponent 
{
	public PostGameAction action;
	public override void OnPointerUp (PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		switch(action)
		{
			case PostGameAction.call:
				GameManager.instance.game.Call();
			break;
			case PostGameAction.check:
				GameManager.instance.game.Check();
			break;
			case PostGameAction.fold:
				GameManager.instance.game.Fold();
			break;
			case PostGameAction.raise100:
				GameManager.instance.game.Raise(100);
			break;
			case PostGameAction.raise20:
				GameManager.instance.game.Raise(20);
			break;
			case PostGameAction.raise40:
				GameManager.instance.game.Raise(40);
			break;
		}
	}
}

public enum PostGameAction
{
	fold,
	call,
	raise20,
	raise40,
	raise100,
	check
}
