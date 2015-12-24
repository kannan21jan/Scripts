using System.Collections.Generic;
using System;

[Serializable]
public class PictureData
{
	public bool is_silhouette ;
	public string url ;
}

[Serializable]
public class Picture
{
	public PictureData data ;
}

[Serializable]
public class FacebookFriend
{
	public string name ;
	public string id ;
	public Picture picture ;
}

//[Serializable]
//public class Paging
//{
//	public string next ;
//}

[Serializable]
public class Summary
{
	public int total_count ;
}

[Serializable]
public class FacebookFriends
{
	public List<FacebookFriend> data ;
	//public Paging paging ;
	public Summary summary ;
}