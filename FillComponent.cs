using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FillComponent : MonoBehaviour 
{

	public void Fill(int score,int maxscore)
	{
		float value = ((float)score / (float)maxscore);
		Image img = GetComponent<Image>();
		img.fillAmount = value;
	}
}
