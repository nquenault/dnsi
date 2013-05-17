using System.Net;
using System.Text.RegularExpressions;

namespace Utility
{
	public class Twitter
	{
		private Twitter() { }

		public static Account GetAccountInfos(string username)
		{
			if(username.StartsWith("@"))
				username = username.Substring(1);
			
			var wc = new WebClient();
			wc.Encoding = System.Text.Encoding.UTF8;

			var data = wc.DownloadString("https://api.twitter.com/1/users/lookup.json?include_entities=true&screen_name=" + Uri.EscapeUriString(username));

			var account = new Account();
			account.Id = GetJSOnValue(data, "id");
			account.Name = GetJSOnValue(data, "name");
			account.Location = GetJSOnValue(data, "location");
			account.FriendsCount = int.Parse(GetJSOnValue(data, "friends_count"));
			account.FollowersCount = int.Parse(GetJSOnValue(data, "followers_count"));
			account.Website = GetJSOnValue(data, "url").Replace("\\/", "/");
			account.TweetsCount = int.Parse(GetJSOnValue(data, "statuses_count"));
			account.LastTweet = GetJSOnValue(data, "text").Replace("\\/", "/");
			account.CreatedAt = GetJSOnValue(data, "created_at");

			return account;
		}

		private static string GetJSOnValue(string json, string varname, string defaultValue = null)
		{
			if(Regex.IsMatch(json, "\"" + varname + "\":\"([^\"]*)\"", RegexOptions.IgnoreCase))
			{
				var matches = Regex.Match(json, "\"" + varname + "\":\"([^\"]*)\"", RegexOptions.IgnoreCase);
				return matches.Groups[1].Value;
			}
			else if(Regex.IsMatch(json, "\"" + varname + "\":([^,]*)", RegexOptions.IgnoreCase))
			{
				var matches = Regex.Match(json, "\"" + varname + "\":([^,]*)", RegexOptions.IgnoreCase);
				return matches.Groups[1].Value;
			}
			else return defaultValue;
		}
	}

	partial class Twitter
	{
		public class Account
		{
			public string Id;
			public string Name;
			public string Location;
			public int FriendsCount;
            public int FollowersCount;
			public string Website;
            public int TweetsCount;
			public string LastTweet;
			public string CreatedAt;
		}
	}
}