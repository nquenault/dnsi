using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

static class Utility
{
	public static void ParallelWhile(Func<bool> condition, Action body, int? MaxDegreeOfParallelism = null)
	{
		ParallelOptions opts = new ParallelOptions();

		if (MaxDegreeOfParallelism.HasValue)
			opts.MaxDegreeOfParallelism = MaxDegreeOfParallelism.Value;

		System.Threading.Tasks.Parallel.ForEach(IterateUntilFalse(condition), opts, ignored => body());
	}

	private static IEnumerable<bool> IterateUntilFalse(Func<bool> condition)
	{
		while (condition()) yield return true;
	}

	private static class Generator
	{
		private static readonly Random _random = new Random();
		public static int Rand(int max = 100, int min = 0) { return _random.Next(min, max + 1); }
	}
	public static int Rand(int max = 100, int min = 0) { return Generator.Rand(max, min); }
	public static T Rand<T>(IEnumerable<T> items)
	{
		return items.ElementAt(Utility.Rand(items.Count() - 1, 0));
	}

	public static void TryInvoke(Control control, Delegate method)
	{
		try
		{
			if (control == null) return;
			else if (control.InvokeRequired)
				control.Invoke(method);
			else
				method.DynamicInvoke();
		}
		catch { }
	}

	public static string IncWord(string value, string charset)
	{
		StringBuilder buffer = new StringBuilder();

		if (!string.IsNullOrEmpty(charset))
		{
			bool incnext = true;

			for (int i = value.Length - 1; i >= 0; i--)
			if (incnext)
			{
				int index = charset.IndexOf(value[i]);
				incnext = index == charset.Length - 1;
				buffer.Insert(0, charset[incnext ? 0 : index + 1]);
			}
			else buffer.Insert(0, value[i]);

			if (incnext)
				buffer.Insert(0, charset[1]);
		}

		return buffer.ToString();
	}

	public static string RandWord(string charset, int length)
	{
		StringBuilder buffer = new StringBuilder();

		if (!string.IsNullOrEmpty(charset))
		{
			for (int i = 0; i < length; i++)
				buffer.Append(charset[Generator.Rand(charset.Length - 1)]);
		}

		return buffer.ToString();
	}

	public static string EncodeToCharCode(string value, bool doNotEncap = false)
	{
		string encodedString = "";

		foreach (char c in value.ToArray())
			encodedString += ((int)c).ToString() + ",";

		encodedString = encodedString.TrimEnd(new char[] { ',' });

		if (!doNotEncap)
			encodedString = "String.fromCharCode(" + encodedString + ")";

		return encodedString;
	}

	public static string UnescapeUnicode(string value)
	{
		return Regex.Replace(
			value,
			@"\\[Uu]([0-9A-Fa-f]{4})",
			m => char.ToString(
				(char)ushort.Parse(m.Groups[1].Value, NumberStyles.AllowHexSpecifier))
		);
	}

	public static string strip_tags(string value)
	{
		return Regex.Replace(value, "<[^>]*>", "");
	}

	public static long ip2long(IPAddress ip)
	{
		Match match = Regex.Match(ip.ToString(), @"^([0-9]{1,3})\.([0-9]{1,3})\.([0-9]{1,3})\.([0-9]{1,3})$");
		int ipa = int.Parse(match.Groups[1].Value);
		int ipb = int.Parse(match.Groups[2].Value);
		int ipc = int.Parse(match.Groups[3].Value);
		int ipd = int.Parse(match.Groups[4].Value);

		return ipd + (ipc * 256) + (ipb * (long)Math.Pow(256, 2)) + (ipa * (long)Math.Pow(256, 3));
	}

	public static IPAddress add2ip(IPAddress ip, double add)
	{
		var ipdec = ip2long(ip);
		ipdec += (long)add;

		var r = new ModuloEx((double)ipdec, Math.Pow(256, 3));
		int ipra = (int)r.Multiplicator;
		r = new ModuloEx(r.Reste, Math.Pow(256, 2));
		int iprb = (int)r.Multiplicator;
		r = new ModuloEx(r.Reste, Math.Pow(256, 1));
		int iprc = (int)r.Multiplicator;
		int iprd = (int)r.Reste;

		return IPAddress.Parse(ipra.ToString() + "." + iprb.ToString() + "." + iprc.ToString() + "." + iprd.ToString());
	}

	public static bool isPrivateIp(IPAddress ip)
	{
		return Regex.IsMatch(
			ip.ToString(),
			@"^(127\.0\.0\.1)|(10\.)|(172\.1[6-9]\.)|(172\.2[0-9]\.)|(172\.3[0-1]\.)|(192\.168\.)"
		);
	}

	public static IPAddress GetRandomIP(int? forceClassA = null, int? forceClassB = null, int? forceClassC = null, int? forceClassD = null, bool includePrivates = false)
	{
		int ipca = forceClassA.HasValue ? forceClassA.Value : Utility.Rand(255, 1);
		int ipcb = forceClassB.HasValue ? forceClassB.Value : Utility.Rand(255, 0);
		int ipcc = forceClassC.HasValue ? forceClassC.Value : Utility.Rand(255, 0);
		int ipcd = forceClassD.HasValue ? forceClassD.Value : Utility.Rand(255, 0);
		IPAddress ip = null;

		try
		{
			ip = IPAddress.Parse(ipca.ToString() + "." + ipcb.ToString() + "." + ipcc.ToString() + "." + ipcd.ToString());

			if (!includePrivates && Utility.isPrivateIp(ip))
				return GetRandomIP(forceClassA, forceClassB, forceClassC, forceClassD, includePrivates);
		}
		catch { }

		return ip;
	}
}
