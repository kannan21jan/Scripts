using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GameGUI : Singleton<GameGUI> 
{
	public List<Card> communityCards;
	public List<Card> pocketCards;
	public List<GlowComponent> outputCards;
	bool quitting;
	public Text maxPoints;
	public Text bestWord;
	public Text yourPoints;

	public Image img;

	public bool firstHint;

	public bool secondHint;

	public WordbetModeElements wordbetModeElements;

	public List<RectTransform> communityCardPositions = new List<RectTransform>();

	public bool shuffling;

	int cardNo;

	IEnumerator Start () 
	{
		EventsManager.instance.cardSelectedEvent += InputCardClicked;
		EventsManager.instance.cardDeSelectedEvent += CardDeselected;
		EventsManager.instance.wordFound += WordFound;
		yield return StartCoroutine(GotSolitareGame (GameManager.instance.game));
		if (FB.IsLoggedIn)
		{
			while(FacebookManager.instance.pic==null)
				yield return null;
			img.sprite = FacebookManager.instance.pic.ToSprite();
			img.gameObject.SetActive(true);
		}
		GetCardPositions ();
		if(GameManager.instance.game.FirstRound())
		{
			if(FB.UserId==GameManager.instance.game.multiplayerGame.data.games[0].player2)
			{
				GameManager.instance.statistics.ChallengeReceived();
			}
		}
	}

	void OnDisable()
	{
//		if(!quitting && GameManager.instance!=null && GameManager.instance.game.mode==GameMode.multiplayer)
//		GameManager.instance.statistics.Chips (GameManager.instance.game.CurrentChips().ToInt());
		if(EventsManager.instance!=null)
		{
			EventsManager.instance.cardSelectedEvent -= InputCardClicked;
			EventsManager.instance.cardDeSelectedEvent -= CardDeselected;
			EventsManager.instance.wordFound -= WordFound;
		}
	}

	void OnApplicationQuit()
	{
//		quitting = true;
	}


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			GameManager.instance.game = new Game();
			SceneManagerExtension.instance.LoadScene(Scene.menu);
		}
	}

	IEnumerator GotSolitareGame(Game game)
	{
		if(game.mode==GameMode.multiplayer)
		while(game.roundData.data.round.Count==0 || game.roundWords.data.worddef.Count==0)
		yield return null;
		if(game.mode==GameMode.solitare)
		{
			wordbetModeElements.Disable();
			for(int i=0;i<communityCards.Count;i++)
			{
				communityCards[i].letter.text = game.data.communities[i].ch.ToUpper();
				communityCards[i].score.text = game.data.communities[i].cv.ToString();
			}
			for(int i=0;i<pocketCards.Count;i++)
			{
				pocketCards[i].letter.text = game.data.hands[i].ch.ToUpper();
				pocketCards[i].score.text = game.data.hands[i].cv.ToString();
			}
		}
		else if(game.mode==GameMode.multiplayer)
		{
			communityCards[0].letter.text = game.roundData.data.round[0].cc1.ToUpper();
			communityCards[0].score.text = game.roundData.data.round[0].cc1v.ToUpper();
			communityCards[1].letter.text = game.roundData.data.round[0].cc2.ToUpper();
			communityCards[1].score.text = game.roundData.data.round[0].cc2v.ToUpper();
			communityCards[2].letter.text = game.roundData.data.round[0].cc3.ToUpper();
			communityCards[2].score.text = game.roundData.data.round[0].cc3v.ToUpper();
			communityCards[3].letter.text = game.roundData.data.round[0].cc4.ToUpper();
			communityCards[3].score.text = game.roundData.data.round[0].cc4v.ToUpper();
			communityCards[4].letter.text = game.roundData.data.round[0].cc5.ToUpper();
			communityCards[4].score.text = game.roundData.data.round[0].cc5v.ToUpper();

			if(FB.UserId==game.multiplayerGame.data.games[0].player1)
			{
				pocketCards[0].letter.text = game.roundData.data.round[0].p1c1.ToUpper();
				pocketCards[0].score.text = game.roundData.data.round[0].p1c1v.ToString();
				pocketCards[1].letter.text = game.roundData.data.round[0].p1c2.ToUpper();
				pocketCards[1].score.text = game.roundData.data.round[0].p1c2v.ToString();
			}
			else
			{
				pocketCards[0].letter.text = game.roundData.data.round[0].p2c1.ToUpper();
				pocketCards[0].score.text = game.roundData.data.round[0].p2c1v.ToString();
				pocketCards[1].letter.text = game.roundData.data.round[0].p2c2.ToUpper();
				pocketCards[1].score.text = game.roundData.data.round[0].p2c2v.ToString();
			}

			wordbetModeElements.Set(GameManager.instance.game.multiplayerGame.data.games[0].currround,game.CurrentChips());
		}
		maxPoints.text = GameManager.instance.game.MaxWord ().score.ToString();
	}

	void InputCardClicked(Card card)
	{
		foreach(var o in outputCards)
		{
			if(!o.gameObject.activeSelf)
			{
				card.MoveForward(o.transform);
				o.gameObject.SetActive(true);
				break;
			}
		}
		communityCardPositions.Remove (card.GetComponent<RectTransform>());
	}

	void CardDeselected(Card card)
	{
		communityCardPositions.Add(card.GetComponent<RectTransform>());
	}

	public int GetIndex(GlowComponent holder)
	{
		return outputCards.IndexOf(holder);
	}

	void WordFound(Word word)
	{
		int m_maxPoints = 0;
		try
		{
			m_maxPoints = System.Int32.Parse (yourPoints.text);
		}
		catch{}
		if(word.score>=m_maxPoints)
		{

			string str = word.word.ToString();
			str = str[0].ToString().ToUpper()+str.Substring(1);
			yourPoints.text = (word.score).ToString();
			bestWord.text = str;

		}
		StartCoroutine (PlayAnim());
	}

	IEnumerator PlayAnim()
	{
		yield return new WaitForSeconds (0.5f);
		foreach(var pos in outputCards)
		{
			if(pos.gameObject.activeSelf)
			{
				pos.Glow();
				yield return new WaitForSeconds(0.1f);
			}
		}
	}

	public void ClearsCards(int time)
	{
		StartCoroutine (m_ClearCards(time));
	}
		
	IEnumerator m_ClearCards(int time)
	{
		yield return new WaitForSeconds (time);
		foreach(var card in outputCards)
		{
			if(card.card!=null)
			{
				Card temp = card.card;
				card.card.MoveBack();
				yield return new WaitForSeconds(0.1f);
				EventsManager.instance.cardDeSelectedEvent(temp);
			}
		}
		Utility.EnableButtons ();
	}

	void GetCardPositions ()
	{
		foreach (var card in communityCards) 
		{
			if(card.GetComponent<RectTransform>().localScale.x==1)
			communityCardPositions.Add (card.GetComponent<RectTransform> ());
		}
	}

	public void Shuffle()
	{
		if(!shuffling)
		{
			shuffling = true;
			foreach(var card in communityCards)
			{
				if(card.GetComponent<RectTransform>().localScale.x==1)
					ShuffleTo(card,GetRectTransform(card));
			}
			GetCardPositions ();
		}
	}

	RectTransform GetRectTransform(Card card)
	{
		int index = Random.Range (0,communityCardPositions.Count);
		try
		{
			if (card.GetComponent<RectTransform> ().position != communityCardPositions [index].position)
			{
				RectTransform temp = communityCardPositions [index];
				communityCardPositions.Remove(temp);
				return temp;
			}
			else
				return GetRectTransform (card);
		}
		catch
		{
			RectTransform temp = card.GetComponent<RectTransform>();
			communityCardPositions.Remove(temp);
			return temp;
		}
	}
	
	void ShuffleTo(Card card,RectTransform trans)
	{
		iTween.MoveTo (card.gameObject,iTween.Hash("position",trans.position,"oncompletetarget",gameObject,"oncomplete","Callback"));
	}

	void Callback()
	{
		if(cardNo<communityCardPositions.Count-1)
		{
			cardNo++;
		}
		else
		{
			cardNo = 0;
			shuffling = false;
		}
	}

	void ShowFirstHint()
	{
		Word word = GameManager.instance.game.MaxWord ();
		string[] str = word.xplode.Split ('|');
		foreach(var card in communityCards)
		{
			if(card.letter.text.ToLower()==str[0])
			{
				StartCoroutine(card.Hint());
			}
		}
	}

	void ShowSecondHint()
	{
		Word word = GameManager.instance.game.MaxWord ();
		string[] str = word.xplode.Split ('|');
		foreach(var card in communityCards)
		{
			if(card.letter.text.ToLower()==str[str.Length-2])
			{
				StartCoroutine(card.Hint());
			}
		}
	}

	public void Hint()
	{
		ClearsCards (0);
		ShowFirstHint();
		if (firstHint)
			ShowSecondHint ();
		if(!secondHint)
		{
//			GameManager.instance.game.Hint ();
			wordbetModeElements.Set(GameManager.instance.game.multiplayerGame.data.games[0].currround,GameManager.instance.game.CurrentChips());
			if(!firstHint)
			{
				firstHint = true;
				return;
			}
			secondHint = true;
		}
	}


}
