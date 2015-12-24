//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net;
//using System.Data;
//using System.IO;
//using System.Collections.Specialized;
//using System.Xml;
//using System.Web;
//using MiniJSON;
//using Newtonsoft.Json;
//
//
//
//namespace WordBet.WordBetService
//{
//    
//    public class SaveMember
//    {
//        public string Name { get; set; }
//        public string Pwd { get; set; }
//        public string Email { get; set; }
//        public string FacebookId { get; set; }
//        public string Results { get; set; }
//    }
//    public class Login
//    {
//        public string Name { get; set; }
//        public string Pwd { get; set; }
//        public string Email { get; set; }
//        public object FacebookId { get; set; }
//        public string Ranking { get; set; }
//        public string Games { get; set; }
//        public string ChallengesIssued { get; set; }
//        public string ChallengesWon { get; set; }
//        public string ChallengesReceived { get; set; }
//        public string ChallengesReceivedWon { get; set; }
//        public object BestWord { get; set; }
//        public string BestWordScore { get; set; }
//        public string Chips { get; set; }
//        public string LastSeen { get; set; }
//        public string Activegames { get; set; }
//        public string Averagescore { get; set; }
//        public string Averagewinnings { get; set; }
//        public string RoundsWon { get; set; }
//        public string RoundsLost { get; set; }
//        public string Results { get; set; }
//       
//    }   
//    public class GetCards
//    {
//        public GetPocketCards[] PocketCard { get; set; }
//        public GetCommunityCards[] CommunityCards { get; set; }
//        public GetWords[] Words { get; set; }
//    }
//    public class GetPocketCards
//    {
//        public string PocketCard { get; set; }
//        public int PocketCardScore { get; set; }
//    }
//    public class GetCommunityCards
//    {
//        public string CommunityCard { get; set; }
//        public int CommunityCardScore { get; set; }
//    }
//    public class GetWords
//    {
//        public string Word { get; set; }
//        public int Score { get; set; }
//        public string Xplode { get; set; }
//        public string Bonus { get; set; }
//    }
//    public class PendingGamesByUser
//    {
//        public PendingGamesYourTurn[] PendingYourTurn { get; set; }
//        public PendingGamesTheirTurn[] PendingTheirTurn { get; set; }
//    }
//    public class PendingGamesYourTurn
//    {
//        public string GameID { get; set; }
//        public string Player1 { get; set; }
//        public string Player2 { get; set; }
//        public string Deck { get; set; }
//        public string NumRounds { get; set; }
//        public string Jackpot { get; set; }
//        public string CurrRound { get; set; }
//        public string CurrTurn { get; set; }
//        public string State { get; set; }
//        public string LastMove { get; set; }
//        public string CurrPot { get; set; }
//        public string Player1Stake { get; set; }
//        public string Player2Stake { get; set; }
//        public string P1Rounds { get; set; }
//        public string P2Rounds { get; set; }
//    }
//    public class PendingGamesTheirTurn
//    {
//        public string GameID { get; set; }
//        public string Player1 { get; set; }
//        public string Player2 { get; set; }
//        public string Deck { get; set; }
//        public string NumRounds { get; set; }
//        public string Jackpot { get; set; }
//        public string CurrRound { get; set; }
//        public string CurrTurn { get; set; }
//        public string State { get; set; }
//        public string LastMove { get; set; }
//        public string CurrPot { get; set; }
//        public string Player1Stake { get; set; }
//        public string Player2Stake { get; set; }
//        public string P1Rounds { get; set; }
//        public string P2Rounds { get; set; }
//    }
//    public class RoundInfo
//    {
//        public string CC1 { get; set; }
//        public string CC2 { get; set; }
//        public string CC3 { get; set; }
//        public string CC4 { get; set; }
//        public string CC5 { get; set; }
//        public string RoundId{ get; set; }
//        public string P1C1 { get; set; }
//        public string P1C2 { get; set; }
//        public string P2C1 { get; set; }
//        public string P2C2 { get; set; }
//        public string P1Word { get; set; }
//        public string P2Word { get; set; }
//        public string P1Score { get; set; }
//        public string P2Score { get; set; }
//        public string P1Bet { get; set; }
//        public string P2Bet { get; set; }
//        public string RoundPot { get; set; }
//        public string PlayerTurn { get; set; }
//        public string GameId { get; set; }
//        public string CC1V { get; set; }
//        public string CC2V { get; set; }
//        public string CC3V { get; set; }
//        public string CC4V { get; set; }
//        public string CC5V { get; set; }
//        public string P1C1V { get; set; }
//        public string P1C2V { get; set; }
//        public string P2C1V { get; set; }
//        public string P2C2V { get; set; }
//        public string Winner { get; set; }
//        public string WinReason { get; set; }
//    }
//    public class RoundInfoByGameID
//    {
//        public RoundInfo[] RoundInfo { get; set; }
//    }
//    public class GetRoundWords
//    {
//        public GetWords[] RoundWords { get; set; }
//    }
//    public class NewGameDetails
//    {
//        public string GameID { get; set; }
//        public string Player1 { get; set; }
//        public string Player2 { get; set; }
//        public string Deck { get; set; }
//        public string Numrounds { get; set; }
//        public string Jackpot { get; set; }
//        public string Currround { get; set; }
//        public string Currturn { get; set; }
//        public string State { get; set; }
//        public string Lastmove { get; set; }
//        public string Currpot { get; set; }
//        public string Player1stake { get; set; }
//        public string Player2stake { get; set; }
//        public string P1rounds { get; set; }
//        public string P2rounds { get; set; }
//    }
//    public class NewGameInfo
//    {
//        public NewGameDetails[] NewGameDetailInfo { get; set; }
//    }
//    public class UpdateUser
//    {
//        public string Name { get; set; }
//        public string Pwd { get; set; }
//        public string Email { get; set; }
//        public object FacebookId { get; set; }
//        public string Ranking { get; set; }
//        public string Games { get; set; }
//        public string ChallengesIssued { get; set; }
//        public string ChallengesWon { get; set; }
//        public string ChallengesReceived { get; set; }
//        public string ChallengesReceivedWon { get; set; }
//        public object BestWord { get; set; }
//        public string BestWordScore { get; set; }
//        public string Chips { get; set; }
//        public string LastSeen { get; set; }
//        public string Activegames { get; set; }
//        public string Averagescore { get; set; }
//        public string Averagewinnings { get; set; }
//        public string RoundsWon { get; set; }
//        public string RoundsLost { get; set; }
//    }
//    public class GetFriendsList
//    {
//        public FriendsList[] members { get; set; }
//    }
//    public class FriendsList
//    {
//        public string FId { get; set; }
//        public string MemberId { get; set; }
//        public string RelatedmemberId { get; set; }
//        public string CreatedDate { get; set; }
//        public object CreatedBy { get; set; }
//        public object UpdatedBy { get; set; }
//        public string UpdatedDate { get; set; }
//        public string Name { get; set; }
//        public string Email { get; set; }
//        public string Pwd { get; set; }
//        public string Ranking { get; set; }
//        public string Games { get; set; }
//        public string ChallengesIssued { get; set; }
//        public string ChallengesWon { get; set; }
//        public string ChallengesReceived { get; set; }
//        public string ChallengesReceivedWon { get; set; }
//        public object BestWord { get; set; }
//        public string BestWordScore { get; set; }
//        public string Chips { get; set; }
//        public string LastSeen { get; set; }
//        public string Activegames { get; set; }
//        public string Averagescore { get; set; }
//        public string Averagewinnings { get; set; }
//        public string RoundsWon { get; set; }
//        public string RoundsLost { get; set; }
//        public string FacebookId { get; set; }
//    }
//    public class WordBetService
//    {
//        public static string gameServerUrl = "http://www.poquere.com/gotchha/";
//
//        public string SignUpMember(string userName, string email, string Pwd, string facebookId)
//        {
//            string loadJsonData = string.Empty;
//            try
//            {
//                var loginDetails = new SaveMember();
//                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/signUpMember.php?name=" + userName + "&email=" + email + "&pwd=" + Pwd + "&facebookId=" + facebookId);
//                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//                StreamReader input = new StreamReader(response.GetResponseStream());
//
//                String responseString = input.ReadToEnd();
//                XmlDocument doc = new XmlDocument();                
//                doc.LoadXml(responseString);
//                foreach (XmlNode node in doc.SelectNodes("//result/error"))
//                {
//                    loadJsonData = node.InnerText;
//                }
//                foreach (XmlNode node in doc.SelectNodes("//result/success"))
//                {
//                    loadJsonData = node.InnerText;
//                }
//            }
//            catch (Exception ex)
//            {
//                loadJsonData = ex.Message;
//            }
//            return loadJsonData;
//        }
//        /*public Login ValidateCredential(string userName, string email, string Pwd, string facebookId)
//        {
//            var loginDetails = new Login();
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/getMembers.php?name=" + userName + "&email=" + email + "&pwd=" + Pwd + "&facebookId=" + facebookId);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            string loadJsonData = string.Empty;
//            foreach (XmlNode node in doc.SelectNodes("//response/data"))
//            {
//                loadJsonData = node["member"].InnerText;
//                //loginDetails = JsonConvert.DeserializeObject<Login>(loadJsonData);
//                loginDetails = Json.DeserializeCustom(loadJsonData,loginDetails);
//            }
//            return loginDetails;
//        }*/
//        public Login GetMemberDetails(string userName, string email, string Pwd, string facebookId)
//        {
//            var loginDetails = new Login();
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/getMemberDetails.php?name=" + userName + "&email=" + email + "&pwd=" + Pwd + "&facebookId=" + facebookId);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            string loadJsonData = string.Empty;
//            foreach (XmlNode node in doc.SelectNodes("//result/error"))
//            {
//                loadJsonData = node.InnerText;
//                loginDetails.Results = loadJsonData;
//            }
//            foreach (XmlNode node in doc.SelectNodes("//response/data"))
//            {
//                loadJsonData = node["member"].InnerText;
//                loginDetails = Json.DeserializeCustom(loadJsonData, loginDetails);
//            }
//            return loginDetails;
//        }
//        public bool ValidateCredential(string userName, string email, string Pwd)
//        {
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/ValidateCredential.php?name=" + userName + "&email=" + email + "&pwd=" + Pwd);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            bool retValue = false;
//            foreach (XmlNode node in doc.SelectNodes("//result"))
//            {
//                retValue = Convert.ToBoolean(node.InnerText);
//            }
//            return retValue;
//        }
//        public bool ValidateFacebookMembers(string facebookId)
//        {
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/validateFacebookMembers.php?facebookId=" + facebookId);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            bool retValue = false;
//            foreach (XmlNode node in doc.SelectNodes("//result"))
//            {
//                retValue =Convert.ToBoolean(node.InnerText);
//            }
//            return retValue;
//        }
//        public GetFriendsList GetWBFriendsList(string memberId)
//        {
//
//            /* var getFriendsList = new GetFriendsList();
//             FriendsList _friendsList;
//             List<FriendsList> _lstFriendsList = new List<FriendsList>();
//
//             HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/friendsList.php?memberId=" + memberId);
//             HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//             StreamReader input = new StreamReader(response.GetResponseStream());
//
//             String responseString = input.ReadToEnd();
//             XmlDocument doc = new XmlDocument();
//             doc.LoadXml(responseString);
//             string loadJsonData = string.Empty;
//             foreach (XmlNode node in doc.SelectNodes("//response/data/result"))
//             {
//                 _friendsList = new FriendsList();
//                 _friendsList.Name = node["member"].InnerText;
//                 //_getmembers.members = Convert.ToInt32(node["cv"].InnerText);
//                 _lstFriendsList.Add(_friendsList);
//                // loadJsonData = node["member"].InnerText;
//                 //loginDetails = JsonConvert.DeserializeObject<Login>(loadJsonData);
//                 //friendsList = Json.DeserializeCustom(loadJsonData, friendsList);
//             }
//             getFriendsList.members = _lstFriendsList.ToArray();
//             return getFriendsList;*/
//            var getFriendsList = new GetFriendsList();
//            FriendsList friendsList;
//            List<FriendsList> _lstFriendsList = new List<FriendsList>();
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/friendsList.php?memberId=" + memberId);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            string loadJsonData = string.Empty;
//            foreach (XmlNode node in doc.SelectNodes("//response/data/result"))
//            {
//                loadJsonData = node["member"].InnerText;
//                friendsList = new FriendsList();
//                //loginDetails = JsonConvert.DeserializeObject<Login>(loadJsonData);
//                friendsList = Json.DeserializeCustom(loadJsonData, friendsList);
//                _lstFriendsList.Add(friendsList);
//            }
//            getFriendsList.members = _lstFriendsList.ToArray();
//            return getFriendsList;
//
//        }
//
//        public GetCards GetCardDetails(string deckName)
//        {
//            GetCards _getCardsDetails = new GetCards();
//            GetCommunityCards _getCommunityCards;
//            List<GetCommunityCards> _lstCommunityCards = new List<GetCommunityCards>();
//            GetPocketCards _getPocketCards;
//            List<GetPocketCards> _lstPocketCards = new List<GetPocketCards>();
//            GetWords _getWords;
//            List<GetWords> _lstWords = new List<GetWords>();
//            
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/createGame2.php?deck=" + deckName);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());            
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            
//            foreach (XmlNode node in doc.SelectNodes("//response/data/community"))
//            {
//                _getCommunityCards = new GetCommunityCards();
//                _getCommunityCards.CommunityCard = node["ch"].InnerText;
//                _getCommunityCards.CommunityCardScore =Convert.ToInt32(node["cv"].InnerText);
//                _lstCommunityCards.Add(_getCommunityCards);
//            }
//            
//            foreach (XmlNode node in doc.SelectNodes("//response/data/hand"))
//            {
//                _getPocketCards = new GetPocketCards();
//                _getPocketCards.PocketCard = node["ch"].InnerText;
//                _getPocketCards.PocketCardScore = Convert.ToInt32(node["cv"].InnerText);
//                _lstPocketCards.Add(_getPocketCards);
//            }
//            
//            foreach (XmlNode node in doc.SelectNodes("//response/data/worddef"))
//            {
//                _getWords = new GetWords();
//                _getWords.Word = node["word"].InnerText;
//                _getWords.Score = Convert.ToInt32(node["score"].InnerText);
//                _getWords.Xplode = node["xplode"].InnerText;
//                _getWords.Bonus = node["bonus"].InnerText;
//                _lstWords.Add(_getWords);
//            }
//            _getCardsDetails.CommunityCards = _lstCommunityCards.ToArray();
//            _getCardsDetails.PocketCard = _lstPocketCards.ToArray();
//            _getCardsDetails.Words = _lstWords.ToArray();
//            return _getCardsDetails;
//        }


//        public string GetWordDefinition(string word, string direction)
//        {            
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/getWordDefinition.php?word=" + word + "&direction=" + direction);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            string responseWordDefinition = string.Empty;
//            foreach (XmlNode node in doc.SelectNodes("//response/data"))
//            {
//                responseWordDefinition = node["definition"].InnerText;
//            }
//            return responseWordDefinition;
//        }
//
//        public PendingGamesByUser GetPendingGamesByUser(string userName)
//        {
//            PendingGamesByUser _pendingGamesByUser = new PendingGamesByUser();
//            PendingGamesYourTurn _getYourTurn;
//            List<PendingGamesYourTurn> _lstPendingYourTurn = new List<PendingGamesYourTurn>();
//            PendingGamesTheirTurn _getTheirTurn;
//            List<PendingGamesTheirTurn> _lstPendingTheirTurn = new List<PendingGamesTheirTurn>();
//
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/getPendingGames.php?name=" + userName);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            string loadJsonData = string.Empty;
//            foreach (XmlNode node in doc.SelectNodes("//response/data/yourturn"))
//            {
//                loadJsonData = node.InnerText;
//                _getYourTurn = new PendingGamesYourTurn();
//               // _getYourTurn = JsonConvert.DeserializeObject<PendingGamesYourTurn>(loadJsonData);
//                _getYourTurn = Json.DeserializeCustom(loadJsonData, _getYourTurn);
//                _lstPendingYourTurn.Add(_getYourTurn);
//            }
//            foreach (XmlNode node in doc.SelectNodes("//response/data/theirturn"))
//            {
//                loadJsonData = node.InnerText;
//                _getTheirTurn = new PendingGamesTheirTurn();
//                //_getTheirTurn = JsonConvert.DeserializeObject<PendingGamesTheirTurn>(loadJsonData);
//                _getTheirTurn = Json.DeserializeCustom(loadJsonData, _getTheirTurn);
//                _lstPendingTheirTurn.Add(_getTheirTurn);
//            }
//            _pendingGamesByUser.PendingYourTurn = _lstPendingYourTurn.ToArray();
//            _pendingGamesByUser.PendingTheirTurn = _lstPendingTheirTurn.ToArray();
//            return _pendingGamesByUser;
//        }

//        public RoundInfoByGameID GetRoundInfoByGameID(string gameId,int round)
//        {
//            RoundInfoByGameID _roundInfoByGameID = new RoundInfoByGameID();
//            RoundInfo _getRoundInfo;
//            List<RoundInfo> _lstRoundInfo = new List<RoundInfo>();
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/getRound.php?gameid=" + gameId + "&round=" + round);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            string loadJsonData = string.Empty;
//            foreach (XmlNode node in doc.SelectNodes("//response/data/round"))
//            {
//                loadJsonData = node.InnerText;
//                _getRoundInfo = new RoundInfo();
//                //_getRoundInfo = JsonConvert.DeserializeObject<RoundInfo>(loadJsonData);
//                _getRoundInfo = Json.DeserializeCustom(loadJsonData, _getRoundInfo);
//                _lstRoundInfo.Add(_getRoundInfo);
//            }
//            _roundInfoByGameID.RoundInfo = _lstRoundInfo.ToArray();
//            return _roundInfoByGameID;
//        }

//        public GetRoundWords GetRoundWords(string gameId, int round, int playerToken)
//        {
//            GetRoundWords _getRoundWords = new GetRoundWords();
//            GetWords _getWords;
//            List<GetWords> _lstWords = new List<GetWords>();
//
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/getRoundWords.php?gameid=" + gameId +"&round=" + round + "&player="+playerToken);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            var a = response.ContentLength;
//            StreamReader input = new StreamReader(response.GetResponseStream());
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            foreach (XmlNode node in doc.SelectNodes("//response/data/worddef"))
//            {
//                _getWords = new GetWords();
//                _getWords.Word = node["word"].InnerText;
//                _getWords.Score = Convert.ToInt32(node["score"].InnerText);
//                _getWords.Xplode = node["xplode"].InnerText;
//                _getWords.Bonus = node["bonus"].InnerText;
//                _lstWords.Add(_getWords);
//            }
//            _getRoundWords.RoundWords = _lstWords.ToArray();
//            return _getRoundWords;
//        }

//        public NewGameInfo CreateWordBetGame(string player1, string player2, string deckValue, int rounds, int stake)
//        {
//            NewGameInfo _newGameInfo = new NewGameInfo();
//            NewGameDetails _newGameDetails;
//            List<NewGameDetails> _lstNewGameDetails = new List<NewGameDetails>();
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/createWordBetGame.php?player1=" + player1 + "&player2=" + player2 + "&deck=" + deckValue + "&rounds=" + rounds + "&stake=" + stake * 160);         
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            string loadJsonData = string.Empty;
//            foreach (XmlNode node in doc.SelectNodes("//response/data"))
//            {
//               
//                _newGameDetails = new NewGameDetails();
//                loadJsonData = node["game"].InnerText;
//               // _newGameDetails = JsonConvert.DeserializeObject<NewGameDetails>(loadJsonData);
//                _newGameDetails = Json.DeserializeCustom(loadJsonData, _newGameDetails);
//                _lstNewGameDetails.Add(_newGameDetails);
//            }
//            _newGameInfo.NewGameDetailInfo = _lstNewGameDetails.ToArray();
//            return _newGameInfo;
//        }

//        public bool UpdateGames(NewGameDetails gameinfo,RoundInfo roundInfo)
//        {
//            bool retValue = false;
//            string jsonGameInfo;
//            HttpWebRequest request = null;
//            HttpWebResponse response = null; ;
//            StreamReader input = null;
//            String responseString = string.Empty;
//            if (roundInfo==null)
//            {
//                jsonGameInfo = ToGameInfoJSON(gameinfo);
//                request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/updateGame.php?db=games&gamestate=" + jsonGameInfo);
//                response = (HttpWebResponse)request.GetResponse();
//                input = new StreamReader(response.GetResponseStream());
//                responseString = input.ReadToEnd();
//                retValue = true;
//            }
//            else
//            {
//                jsonGameInfo = ToGameInfoJSON(gameinfo);
//                request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/updateGame.php?db=games&gamestate=" + jsonGameInfo);
//                response = (HttpWebResponse)request.GetResponse();
//                input = new StreamReader(response.GetResponseStream());
//                responseString = input.ReadToEnd();
//                jsonGameInfo = ToRoundInfoJSON(roundInfo);
//                request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/updateGame.php?db=rounds&gamestate=" + jsonGameInfo);
//                response = (HttpWebResponse)request.GetResponse();
//                input = new StreamReader(response.GetResponseStream());
//                responseString = input.ReadToEnd();
//                retValue = true;
//            }
//          
//            return retValue;
//        }
//        public bool UpdateUser(UpdateUser updateUserDetails)
//        {
//            bool retValue = false;
//            string jsonUserInfo;
//            HttpWebRequest request = null;
//            HttpWebResponse response = null; 
//            StreamReader input = null;
//            String responseString = string.Empty;
//            jsonUserInfo = JsonConvert.SerializeObject(updateUserDetails);
//            request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/updateMember.php?state=" + jsonUserInfo);
//            retValue = true;
//            response = (HttpWebResponse)request.GetResponse();
//            input = new StreamReader(response.GetResponseStream());
//            responseString = input.ReadToEnd();
//            return retValue;
//        }
//
//        private string FireGetRequest(string requestUrl, string qParameters)
//        {
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(gameServerUrl + requestUrl + "?" + qParameters);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//            return input.ReadToEnd();            
//        }        
//
//        public string MakeFriend(string userName, string friendName)
//        {
//            return this.FireGetRequest("makefriends.php", "name=" + userName + "&fname=" + friendName);
//        }        
//
//        public string LinkFb(string userName, string facebookId)
//        {
//            return this.FireGetRequest("linkfb.php", "name=" + userName + "&fid=" + facebookId);
//        }
//
//        public string GetFriends(string userName)
//        {
//            return this.FireGetRequest("getwordbet_friends.php", "name=" + userName);
//        }
//
//        public string GetRandom10(string userName)
//        {            
//            return this.FireGetRequest("getrandom10.php", "name=" + userName);
//        }
//
//        public string CreateNotification(string fromMember, string toMember, string message, int messageType, string gameId)
//        {
//            return this.FireGetRequest("createnotification.php", "name=" + fromMember + "&fname=" + toMember + "&msg=" + message + "&type=" + messageType + "&gameid=" + gameId);
//        }
//
//        public string GetNotification(string userName, int type)
//        {
//            return this.FireGetRequest("getnotifications.php", "name=" + userName + "&type=" + type);
//        }
//
//        public string GetPendingGames(string userName)
//        {
//            return this.FireGetRequest("getpending_games.php", "name=" + userName);
//        }
//
//        public string UpdateNotification(string userName, string notificationIds)
//        {
//            return this.FireGetRequest("readnotifications.php", "name=" + userName + "&ids=" + notificationIds);
//        }
//
//        public Login GetRandomPlayer(string userName, int oppChoice)
//        {
//            var loginDetails = new Login();
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.poquere.com/gotchha/getRecentPlayers.php?name=" + userName + "&random=" + oppChoice);
//            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//            StreamReader input = new StreamReader(response.GetResponseStream());
//
//            String responseString = input.ReadToEnd();
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(responseString);
//            string loadJsonData = string.Empty;
//            foreach (XmlNode node in doc.SelectNodes("//response/data"))
//            {
//                loadJsonData = node["member"].InnerText;
//                //loginDetails = JsonConvert.DeserializeObject<Login>(loadJsonData);
//                loginDetails = Json.DeserializeCustom(loadJsonData, loginDetails);
//            }
//            return loginDetails;
//        }
//
//
//        
//        public static string ToGameInfoJSON(NewGameDetails gameinfo)
//        {
//            return JsonConvert.SerializeObject(gameinfo);
//           //return Json.Serialize(gameinfo);
//        }

//        public static string ToRoundInfoJSON(RoundInfo roundInfo)
//        {
//            return JsonConvert.SerializeObject(roundInfo);
//           // return Json.Serialize(roundInfo);
//        }
//    }
//}
