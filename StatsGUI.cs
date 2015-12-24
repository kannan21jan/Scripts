using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatsGUI : MonoBehaviour 
{
	public Text playerName;
	public Text games;
	public Text challengesWon;
	public Text challengesReceivedWon;
	public Text challengesIssued;
	public Text challengesReceived;
	public Text bestWord;
	public Text bestWordScore;
	public Text chips;
	public Text lastSeen;
	public Text activeGames;
	public Text averageScore;
	public Text roundsWon;
	public Text roundsLost;


	// Use this for initialization
	void Start () 
	{
		playerName.text = FacebookManager.instance.myInfo.name;
		games.text = GameManager.instance.statistics.games.ToString();
		challengesWon.text = GameManager.instance.statistics.challengesWon.ToString();
		challengesReceivedWon.text = GameManager.instance.statistics.challengesReceivedWon.ToString();
		challengesIssued.text = GameManager.instance.statistics.challengesIssued.ToString();
		challengesReceived.text = GameManager.instance.statistics.challengesReceived.ToString();
		bestWord.text = GameManager.instance.statistics.bestWord.ToString();
		bestWordScore.text = GameManager.instance.statistics.bestWordScore.ToString();
		chips.text = GameManager.instance.statistics.chips.ToString();
		lastSeen.text = GameManager.instance.statistics.lastSeen.ToString();
		activeGames.text = GameManager.instance.statistics.activegames.ToString();
		averageScore.text = GameManager.instance.statistics.averagescore.ToString();
		roundsWon.text = GameManager.instance.statistics.roundsWon.ToString();
		roundsLost.text = GameManager.instance.statistics.roundsLost.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManagerExtension.instance.LoadScene(Scene.menu);
		}
	}
}
