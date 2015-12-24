using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotificationBar : MonoBehaviour 
{
	public Text player;
	public Text state;
	public MultiplayerGame game;


	public void OnClick()
	{
//		NotificationsGUI.instance.EnableRoundDetails (game);
		GameManager.instance.game.GetMultiplayerGame (game,Callback);
	}

	public void Set(string player,string state,MultiplayerGame game)
	{
		this.player.text = player;
		this.state.text = state;
		this.game = game;
	}

	void Callback()
	{
		if(GameManager.instance.game.FirstRound())
		{
			SceneManagerExtension.instance.LoadScene (Scene.game);
		}
		else
		{
			SceneManagerExtension.instance.LoadScene (Scene.roundSummary);
		}
	}
}
