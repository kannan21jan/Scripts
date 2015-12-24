using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonComponent : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IEndDragHandler,IDragHandler
{
	public Sprite downSprite;
	protected Sprite normalSprite;
	protected Image m_image;
	protected Image image
	{
		get
		{
			if(m_image==null)
			{
				m_image = GetComponent<Image>();
				normalSprite = m_image.sprite;
			}

			return m_image;
		}
	}



	protected virtual void Start () 
	{

	}

	public virtual void OnPointerDown (PointerEventData eventData)
	{
		if(downSprite)
		image.sprite = downSprite;
	}

	public virtual void OnPointerUp (PointerEventData eventData)
	{
		image.sprite = normalSprite;
	}


	public virtual void OnDrag (PointerEventData eventData)
	{

	}
	
	public virtual void OnEndDrag (PointerEventData eventData)
	{

	}
}
