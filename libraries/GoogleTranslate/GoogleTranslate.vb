using System.Net;


namespace Utility
{
	public class GoogleTranslate
	{
		private GoogleTranslate() { }

		public static string Translate(string words, string tl)
		{
			var wc = new WebClient();
			var data = wc.DownloadString("http://translate.google.fr/translate_a/t?client=t&text=" + Uri.EscapeUriString(words) + "&hl=fr&sl=auto&tl=" + Uri.EscapeUriString(tl) + "&multires=1&otf=2&ssel=0&tsel=0&sc=1");

			data = data.Substring(data.IndexOf("\"") + 1);
			return data.Substring(0, data.IndexOf("\""));
		}
	}
}
