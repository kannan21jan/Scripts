using UnityEngine;
using System.Collections;

public static class Utility 
{
	public static void DisableButtons()
	{
		ButtonComponent[] buttons = GameObject.FindObjectsOfType<ButtonComponent>();
		foreach (var button in buttons)
			button.enabled = false;
	}

	public static void EnableButtons()
	{
		ButtonComponent[] buttons = GameObject.FindObjectsOfType<ButtonComponent>();
		foreach (var button in buttons)
			button.enabled = true;
	}

//	public static Game CreateASolitareGame()
//	{
//
//	}
}
