using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotificationsGUI : Singleton<NotificationsGUI> {


	public GameObject yourTurn;
	public GameObject theirTurn;
	public Transform content;
	public Transform theirTurnHeader;
	public int theirTurnIndex;
	public bool constructed;
	public GameObject startGamebutton;
	public Animator button;
	public Animator textImage;
	public GameObject startButton;
	public GameObject roundDetails;
	public GameObject popup;

	public void ConstructGUI()
	{

		foreach(Transform trans in content)
		if(trans!=theirTurnHeader)
		{
			Destroy(trans.gameObject);
		}
		foreach(var turn in GameManager.instance.pendingGames.data.yourturns)
		{
			GameObject obj = Instantiate<GameObject>(yourTurn);
			obj.transform.SetParent(content,false);
			NotificationBar script = obj.GetComponent<NotificationBar>();
			string player = "Playing with "+turn.GetOpponentName();
			string state = "Round "+turn.game.currround;
			script.Set(player,state,turn.game);
		}
		int count = content.childCount;
		theirTurnHeader.SetSiblingIndex (count-1);
		theirTurnIndex = theirTurnHeader.GetSiblingIndex ();
		foreach(var turn in GameManager.instance.pendingGames.data.theirturns)
		{
			GameObject obj = Instantiate<GameObject>(theirTurn);
			obj.transform.SetParent(content,false);
			obj.transform.SetSiblingIndex(theirTurnIndex+1);
			NotificationBar script = obj.GetComponent<NotificationBar>();
			script.player.text = "Playing with "+turn.GetOpponentName();
			script.state.text = "Round "+turn.game.currround;
			script.game = turn.game;
		}
		constructed = true;
	}


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(roundDetails.activeSelf)
			{
				roundDetails.SetActive(false);
			}
			else
			{
				Application.Quit();
			}
		}
	}

	public void Normal()
	{
		button.Play ("normal");
		textImage.Play ("normal");
		StartCoroutine (StartButtonToggler());
	}

	public void Reverse()
	{
		startButton.SetActive (!startButton.activeSelf);
		button.Play ("reverse");
		textImage.Play ("reverse");
	}

	IEnumerator StartButtonToggler()
	{
		yield return new WaitForSeconds(0.5f);
		startButton.SetActive (!startButton.activeSelf);
	}

	public void CreateGuruGame()
	{
		var yourTurnP1 = GameManager.instance.pendingGames.data.yourturns.Exists (a=>a.game.player1=="System");
		var yourTurnP2 = GameManager.instance.pendingGames.data.yourturns.Exists (a=>a.game.player2=="System");
		var theirTurnP1 = GameManager.instance.pendingGames.data.theirturns.Exists (a=>a.game.player1=="System");
		var theirTurnP2 = GameManager.instance.pendingGames.data.theirturns.Exists (a=>a.game.player2=="System");
		if(yourTurnP1==false && yourTurnP2==false && theirTurnP1==false && theirTurnP2==false)
		{
			EventsManager.instance.CreateGuruGameEvent ("System");
		}
		else
		{
			EnablePopup();
		}
	}


	public void EnablePopup()
	{
		Button[] array = GameObject.FindObjectsOfType<Button>();
		foreach (var but in array)
			but.enabled = false;
		popup.SetActive (true);
	}
	
	public void DisablePopup()
	{
		Button[] array = GameObject.FindObjectsOfType<Button>();
		foreach (var but in array)
			but.enabled = true;
		popup.SetActive (false);
	}

	public void CreateSolitareGame()
	{
		EventsManager.instance.CreateSolitareGameEvent ();
	}


	public void EnableRoundDetails(MultiplayerGame game)
	{
		LoadingScreen.instance.StartLoading ();
		GameManager.instance.game.GetMultiplayerGame (game,Callback);
	}

	void Callback()
	{
		LoadingScreen.instance.StopLoading ();
		roundDetails.SetActive (true);
		RoundDetailsComponent script = roundDetails.GetComponent<RoundDetailsComponent>();
		script.Build (GameManager.instance.game);
	}

}
