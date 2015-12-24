using UnityEngine;
using System.Collections;

public class FriendsGUI : Singleton<FriendsGUI> 
{

	public GameObject friend;
	public Transform content;
	public GameObject popup;

	void Start () 
	{
		foreach(var friend in FacebookManager.instance.fbFriendsResult.data)
		{
			GameObject obj = Instantiate<GameObject>(this.friend);
			FriendBar script = obj.GetComponent<FriendBar>();
			string friendName = friend.name;
			string id = friend.id;
			script.Set(friendName,id);
			obj.transform.SetParent(content,false);
		}
	}

	public void EnablePopup()
	{
		CreateGameWithFriendButton[] array = GameObject.FindObjectsOfType<CreateGameWithFriendButton>();
		foreach (var but in array)
			but.enabled = false;
		popup.SetActive (true);
	}

	public void DisablePopup()
	{
		CreateGameWithFriendButton[] array = GameObject.FindObjectsOfType<CreateGameWithFriendButton>();
		foreach (var but in array)
			but.enabled = true;
		popup.SetActive (false);
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManagerExtension.instance.LoadScene(Scene.menu);
		}
	}
}
