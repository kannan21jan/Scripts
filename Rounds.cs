using UnityEngine;
using System.Collections;

[System.Serializable]
public class Rounds
{
	public Round round1;
	public Round round2;
	public Round round3;

	public Rounds(string gameid)
	{
		string url = Url.getRoundData;
		url = url.Replace ("{gameid}",gameid);
		url = url.Replace ("{round}","1");
		MyRequest.CreateRequest (url,Round1Callback);
		url = Url.getRoundData;
		url = url.Replace ("{gameid}",gameid);
		url = url.Replace ("{round}","2");
		MyRequest.CreateRequest (url,Round2Callback);
		url = Url.getRoundData;
		url = url.Replace ("{gameid}",gameid);
		url = url.Replace ("{round}","3");
		MyRequest.CreateRequest (url,Round3Callback);
	}


	void Round1Callback(WWW www)
	{
		round1 = www.text.ToClass<GetRoundDataRoot>().data.round[0];
	}

	void Round2Callback(WWW www)
	{
		round2 = www.text.ToClass<GetRoundDataRoot>().data.round[0];
	}

	void Round3Callback(WWW www)
	{
		round3 = www.text.ToClass<GetRoundDataRoot>().data.round[0];
	}
}
