using UnityEngine;
using System.Collections;

public class WordlistGUI : Singleton<WordlistGUI> 
{
	public GameObject prefab;
	public Transform content;
	
	void Start () 
	{
		CreateWordList ();
	}
	
	void CreateWordList()
	{
		foreach(Word word in GameManager.instance.game.data.worddefs)
		{
			GameObject obj = Instantiate(prefab) as GameObject;
			Row script = obj.GetComponent<Row>();
			script.Set(word);
			obj.transform.SetParent(content,false);
		}
	}

	public void GoToMenu()
	{
		SceneManagerExtension.instance.LoadScene (Scene.menu);
	}

	public void GetWordDefinition(string word)
	{
		MyRequest.CreateRequest (Url.getWordDefinition+word,GotWordDefinition);
	}
	
	void GotWordDefinition(WWW www)
	{
		print (www.text);
	}
}
