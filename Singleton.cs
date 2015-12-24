using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	static T m_instance;

	static bool isQuitting;

	public static T instance
	{
		get
		{
			if(isQuitting)
				return null;

			if(m_instance==null)
			{
				m_instance = GameObject.FindObjectOfType<T>();

				if(m_instance==null)
					m_instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
			}

			return m_instance;
		}
	}


	void OnApplicationQuit()
	{
		isQuitting = true;
	}

	protected virtual void Awake () 
	{
		if (m_instance == null)
			m_instance = this as T;
		else
			Destroy (gameObject);
	}
}
