using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FillTimer : MonoBehaviour 
{

	public float time;
	float reductionValue;
	Image image;


	void Start()
	{
		reductionValue = 1 / time;
		image = GetComponent<Image>();
		StartCoroutine (StartTimer());
	}


	IEnumerator StartTimer()
	{
		while(image.fillAmount>0)
		{
			image.fillAmount = image.fillAmount - reductionValue;
			yield return new WaitForSeconds(1);
		}
	}
}
