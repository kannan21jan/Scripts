using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Row : MonoBehaviour 
{
	public Text word;
	public Text score;
	public Text bonus;
	Color color;

	public void Set(Word word)
	{
		this.word.text = word.word;
		this.score.text = word.score.ToString();
		this.bonus.text = word.bonus;
		color = GameManager.instance.game.wordsFound.Contains (word) ? Color.green : Color.white;
		color = (GameManager.instance.game.MaxWord () == word) ? Color.yellow : color;
		if(color==Color.white)
		{
			color.a = 0.75f;
		}
		this.word.color = color;
		this.score.color = color;
		this.bonus.color = color;

	}
}
