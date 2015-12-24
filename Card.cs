using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class Card : ButtonComponent
{
	public Text letter;
	public Text score;
	public float targetSize;
	public GameObject hintGlow;

	bool isDone;
	
	[HideInInspector]public GlowComponent destination;
	
	[HideInInspector]public Vector3 position;
	[HideInInspector]public Vector3 rotation;
	float time = 0.5f;
	bool stillMoving;
	
	protected override void Start()
	{
		base.Start();
		rotation = transform.eulerAngles;
	}

	void Reset()
	{
		isDone = false;
		image.sprite = normalSprite;
	}


	public override void OnPointerDown(PointerEventData eventData)
	{
		if(!isDone)
		position = transform.position;
	}

	public override void OnPointerUp (PointerEventData eventData)
	{
		if (stillMoving)
			return;
		if(!isDone)
		{
			isDone = true;
			EventsManager.instance.cardSelectedEvent (this);
			return;
		}
		if(!eventData.dragging && isDone)
		{
				EventsManager.instance.cardDeSelectedEvent(this);
				MoveBack();
				return;
		}
		else
		{
			GameGUI.instance.ClearsCards(0);
		}
	}
	
	public override void OnDrag (PointerEventData eventData)
	{
		if(!isDone)
		{
			transform.position = new Vector3 (eventData.position.x,eventData.position.y,transform.position.z);
		}
	}
	
	public void MoveForward(Transform trans)
	{
		destination = trans.GetComponent<GlowComponent>();
		destination.card = this;
		stillMoving = true;
		iTween.MoveTo(gameObject,iTween.Hash("position",trans.position,"time",time,"oncompletetarget",gameObject,"oncomplete","MoveCallback"));
		iTween.ScaleTo(gameObject,iTween.Hash("scale",new Vector3(targetSize,targetSize,targetSize),"time",time));
		iTween.RotateTo(gameObject,iTween.Hash("rotation",new Vector3(0,0,0),"time",time));
	}
	
	public void MoveBack()
	{
		if (destination != null) 
		{
			destination.gameObject.SetActive (false);
			destination = null;
			isDone = !isDone;
			stillMoving = true;
			iTween.MoveTo(gameObject,iTween.Hash("position",position,"time",time,"easetype",iTween.EaseType.easeInBack,"oncompletetarget",gameObject,"oncomplete","MoveCallback"));
			iTween.ScaleTo(gameObject,iTween.Hash("scale",new Vector3(1,1,1),"time",time));
			iTween.RotateTo(gameObject,iTween.Hash("rotation",rotation,"time",time));
		}
	}


	void MoveCallback()
	{
		stillMoving = false;
	}


	[ContextMenu("Get elements")]
	protected void GetElements()
	{
		letter = transform.FindChild ("letter").GetComponent<Text>();
		score = transform.FindChild ("score").GetComponent<Text>();
	}

	public IEnumerator Hint()
	{
		hintGlow.SetActive (true);
		yield return new WaitForSeconds(2);
		hintGlow.SetActive (false);
	}
}
