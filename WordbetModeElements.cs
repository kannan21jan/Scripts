using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class WordbetModeElements
{
	public Text roundLabel;
	public Text roundNo;
	public Text chips;


	public void Disable()
	{
		roundLabel.gameObject.SetActive (false);
		roundNo.gameObject.SetActive (false);
		chips.gameObject.SetActive (false);
	}

	public void Set(string roundNo,string chips)
	{
		this.roundNo.text = roundNo;
		this.chips.text = chips;
	}
}
