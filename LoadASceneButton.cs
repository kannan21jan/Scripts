using UnityEngine;
using System.Collections;

public class LoadASceneButton : ButtonComponent
{
	public string sceneName;

	public override void OnPointerUp (UnityEngine.EventSystems.PointerEventData eventData)
	{
		base.OnPointerUp (eventData);
		SceneManagerExtension.instance.LoadScene (sceneName);
	}
}
