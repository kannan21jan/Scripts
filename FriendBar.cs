using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FriendBar : MonoBehaviour 
{
	public Text friendName;
	public string playerId;

	public void Set(string friend,string id)
	{
		if(friend.Length>20)
		{
			friend = friend.Substring(0,20);
			friend = friend + "..";
		}
		friendName.text = friend;
		playerId = id;
	}
}
