using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using Facebook.MiniJSON;
using System.Linq;

public class FacebookManager : SingletonEternal<FacebookManager> 
{
	public string accessToken;
	public FacebookFriends fbFriendsResult;
	public MyFacebookInfo myInfo = new MyFacebookInfo();
	public Texture2D pic;

	IEnumerator Start () 
	{
		if (!FB.IsInitialized)
			FB.Init (null);

		while (!FB.IsInitialized)
			yield return null;

		#if UNITY_EDITOR
		FacebookManager.instance.Login();
		#endif

		if(FB.IsLoggedIn)
		{
			IsLoggedIn();
		}
	}

	void SetMyPicture(WWW www)
	{
		pic = www.texture;
	}

	public void Login()
	{
		FB.Login ("user_friends, email, public_profile",LoginCallback);
	}

	void LoginCallback(FBResult result)
	{
		if(result.Error!=null)
		{
			
		}
		else
		{
			IsLoggedIn();
		}
	}

	void IsLoggedIn()
	{
		GetMyInformation();
		GetMyFriendsList();
		GameManager.instance.GetPendingGames();
		GameManager.instance.GetStats();
		SceneManagerExtension.instance.LoadScene(Scene.menu);
	}

	public void Logout()
	{
		FB.Logout ();
	}

	void GetMyInformation()
	{
		FB.API ("me?fields=id,name,picture",Facebook.HttpMethod.GET,GotMyInformationCallback);
	}

	void GotMyInformationCallback(FBResult result)
	{
		if(result.Error!=null)
		{
			
		}
		else
		{
			myInfo = JsonConvert.DeserializeObject<MyFacebookInfo>(result.Text);
			MyRequest.CreateRequest(myInfo.picture.data.url,SetMyPicture);
		}
	}

	void GetMyFriendsList()
	{
		FB.API ("me/friends?fields=name,picture",Facebook.HttpMethod.GET,GotMyFriendsListCallback);
	}

	void GotMyFriendsListCallback(FBResult result)
	{
		if(result.Error!=null)
		{
			
		}
		else
		{
			fbFriendsResult = JsonConvert.DeserializeObject<FacebookFriends>(result.Text);
			fbFriendsResult.data = fbFriendsResult.data.OrderBy(a=>a.name).ToList();
		}
	}

	public void Invite()
	{
		FB.AppRequest ("Invite friends!");
	}

	[ContextMenu("Get Token")]
	void Open()
	{
		Application.OpenURL ("https://developers.facebook.com/tools/accesstoken/?app_id=816573561727746");
	}
}