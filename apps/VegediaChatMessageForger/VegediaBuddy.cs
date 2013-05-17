using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace VegediaChatMessageForger
{
    partial class VegediaAPI
    {
        public struct VegediaBuddy
        {
            private string _id;
            private string _username;
            private string _pseudo;
            private string _status;
            private string _avatarUrl;
            private string _profilUrl;
            
            public string Id { get { return _id; } }
            public string Username { get { return _username; } }
            public string Pseudo { get { return _pseudo; } }
            public string Status { get { return _status; } }
            public string AvatarUrl { get { return _avatarUrl; } }
            public string ProfilUrl { get { return _profilUrl; } }

            public static string JSonParseRegex { get { return (
                @"{'id':'([0-9]+)','n':'([^']+)','s':'([\w]+)','a':'" +
                @"(\\/arrowchat\\/\.\.)?([^']+)','l':'(\\/arrowchat\\/\.\.)?([^']+)'}"
            ).Replace("'", "\""); } }

            public VegediaBuddy(string id, string username, string status, string avatarUrl, string profilUrl)
            {
                _id = id;
                _username = username;
                _status = status;
                _avatarUrl = avatarUrl;
                _profilUrl = profilUrl;
                _pseudo = Regex.Match(username, @"([^\s]+)").Groups[1].Value;
            }

            [DebuggerHidden()]
            public static VegediaBuddy ParseFromJSon(string json)
            {
                Match match = Regex.Match(json, "^(?i)" + JSonParseRegex + "$");

                if (match.Success)
                {
                    return new VegediaBuddy(
                        match.Groups[1].Value,
                        match.Groups[2].Value,
                        match.Groups[3].Value,
                        match.Groups[5].Value.Replace("\\", ""),
                        match.Groups[7].Value.Replace("\\", "")
                    );
                }
                else throw new Exception("Bad json format");
            }
        }
    }
}
