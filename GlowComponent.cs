using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlowComponent : MonoBehaviour 
{
	public Animator bottom;
	public Animator top;
	public Card card;



	void OnDisable()
	{
		bottom.gameObject.SetActive (false);
		top.gameObject.SetActive (false);
		card = null;
	}

	public void Glow()
	{
		bottom.gameObject.SetActive (true);
		top.gameObject.SetActive (true);
		bottom.Play ("bottom");
		top.Play ("top");
	}
}
