using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class RoundSummaryGUI : MonoBehaviour 
{
	public GameObject checkButton;
	public GameObject callButton;
	public GameObject raiseButton;


	public GameObject won;
	public GameObject lost;

	public Text playerName;
	public Text maxPoints;
	public Text yourPoints;
	public Text wordsFound;
	public Image dp,opponentDp;
	void Start () 
	{
		EventsManager.instance.won += Won;
		EventsManager.instance.lost += Lost;
		GetOpponentDP ();
		try
		{
			maxPoints.text = GameManager.instance.game.MaxWord ().score.ToString ();
			wordsFound.text = GameManager.instance.game.wordsFound.Count.ToString();
		}
		catch
		{
			maxPoints.text = "";
			wordsFound.text = "0";
		}
		try
		{	if(GameManager.instance.game.FirstRound())
			yourPoints.text = GameManager.instance.game.wordsFound.OrderByDescending(a=>a.score).ToList()[0].score.ToString();
			else
			{
				if(FB.UserId==GameManager.instance.game.multiplayerGame.data.games[0].player1)
				{
					yourPoints.text = GameManager.instance.game.roundData.data.round[0].p1score;
				}
				else
				{
					yourPoints.text = GameManager.instance.game.roundData.data.round[0].p2score;
				}
			}
		}
		catch
		{
			yourPoints.text = "0";
		}
		playerName.text = FacebookManager.instance.myInfo.name;
		dp.sprite = FacebookManager.instance.pic.ToSprite();
		if(GameManager.instance.game.Checkable())
		{
			checkButton.SetActive(true);
			callButton.SetActive(false);
		}
		else
		{
			checkButton.SetActive(false);
			callButton.SetActive(true);
		}
		if (GameManager.instance.game.FinalRound ())
			raiseButton.SetActive (false);
	}


	void GetOpponentDP()
	{
		if(GameManager.instance.game.multiplayerGame.data.games[0].player1==FB.UserId)
		{
			foreach(var friend in FacebookManager.instance.fbFriendsResult.data)
			{
				if(friend.id==GameManager.instance.game.multiplayerGame.data.games[0].player2)
				{
					MyRequest.CreateRequest(friend.picture.data.url,GetOpponentDPCallback);
				}
			}
		}
		else
		{
			foreach(var friend in FacebookManager.instance.fbFriendsResult.data)
			{
				if(friend.id==GameManager.instance.game.multiplayerGame.data.games[0].player1)
				{
					MyRequest.CreateRequest(friend.picture.data.url,GetOpponentDPCallback);
				}
			}
		}
	}


	void GetOpponentDPCallback(WWW www)
	{
		opponentDp.sprite = www.texture.ToSprite();
	}

	void OnDisable()
	{
		if(EventsManager.instance!=null)
		{
			EventsManager.instance.won -= Won;
			EventsManager.instance.lost -= Lost;
		}
		if(GameManager.instance!=null)
			GameManager.instance.game = new Game ();
	}

	void Won()
	{
		GameManager.instance.statistics.RoundWon (true);
		won.SetActive (true);
	}

	void Lost()
	{
		GameManager.instance.statistics.RoundWon (false);
		lost.SetActive (true);
		StartCoroutine (LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		yield return new WaitForSeconds(3);
		SceneManagerExtension.instance.LoadScene (Scene.menu);
	}
}
