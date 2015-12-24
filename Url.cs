using UnityEngine;
using System.Collections;

public class Url : MonoBehaviour 
{
	public const string getWordDefinition = "http://www.poquere.com/gotchha/getWordDefinition.php?word=";
	public const string createSolitareGame = "http://www.poquere.com/gotchha/createGame2.php?deck=Easy";
	public const string validate = "http://poquere.com/gotchha/validateFacebookMembers.php?facebookId=";
	public const string signup = "http://poquere.com/gotchha/signUpMember.php?facebookId=";
	public const string createMultiplayerGame = "http://www.poquere.com/gotchha/createWordBetGame.php?player1={player1}&player2={player2}&deck=Easy&rounds=3&stake=1*160";
	public const string getRoundWords = "http://www.poquere.com/gotchha/getRoundWords.php?gameid={gameid}&round={round}&player={player}";
	public const string getRoundData = "http://www.poquere.com/gotchha/getRound.php?gameid={gameid}&round={round}";
	public const string updateMultiplayerGame = "http://www.poquere.com/gotchha/updateGame.php?db=games&gamestate=";
	public const string updateRoundInfo = "http://www.poquere.com/gotchha/updateGame.php?db=rounds&gamestate=";
	public const string getPendingGames = "http://www.poquere.com/gotchha/getpending_games.php?name=";
	public const string getNotification = "http://poquere.com/gotchha/getnotifications.php?name={name}&type=1";
	public const string createNotification = "http://www.poquere.com/gotchha/createnotification.php?name={fromname}&fname={toname}&msg={msg}&type=1&gameid={gameid}";
	public const string readNotification = "http://poquere.com/gotchha/readnotifications.php?name={name}&ids={id}";
	public const string updateMember = "http://www.poquere.com/gotchha/updateMember.php?state=";
	public const string getMember = "http://www.poquere.com/gotchha/getMembers.php?name={name}";
}
