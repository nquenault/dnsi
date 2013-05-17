/*
<dnsi>
	<link src="https://dnsi.googlecode.com/svn/libraries/Arguments/Arguments.cs" />
</dnsi>
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utility
{
	public class XMLNodeLight
	{
		private string _name;
		private Arguments _attributs = new Arguments();

		private string _innerText = null;
		public Arguments Attributs { get { return _attributs; } }
		public List<XMLNodeLight> ChildNodes { get { return ParseXml(_innerText); } }
		public string InnerText { get { return _innerText; } set { _innerText = value; } }

		public Arguments Values
		{
			get
			{
				Arguments allvalues = new Arguments(_attributs.ToDictionary(true));

				foreach (XMLNodeLight node in ChildNodes)
				{
					var attributs = node.Attributs;
					var adict = attributs.ToDictionary();

					if (attributs.HasValue("value"))
					{
						allvalues.AddValue(node.Name, attributs.GetValue<string>("value"), false);
					}
					else if (adict.Count == 1 && (node.InnerText == null))
					{
						allvalues.AddValue(node.Name, adict.Values.ToList()[0].ToString(), false);
					}
					else if (adict.Count == 2 && attributs.HasValue("name"))
					{
						string name = null;
						string value = null;

						foreach (var item in adict)
							if (item.Key.ToLower() == "name")
								name = item.Value.ToString();
							else
								value = item.Value.ToString();

						allvalues.AddValue(name, value, false);
					}
					else
						allvalues.AddValue(node.Name, node.InnerText, false);
				}

				return allvalues;
			}
		}

		public string Name
		{
			get { return _name; }
			set
			{
				value = Regex.Replace(value, "([^a-zA-Z0-9])", "");
				value = Regex.Replace(value, "^([0-9]*)", "");
				_name = value;
			}
		}

		public string InnerXml
		{
			get { return _innerText; }
			set
			{
				string xml = "";
				var nodes = ParseXml(value);

				foreach (var node in nodes)
					xml += node.ToString();

				_innerText = xml;
			}
		}

		public string OuterXml
		{
			get
			{
				string xml = "<" + Name + " ";

				if (Attributs.ToDictionary(true).Count != 0)
				{
					foreach (var attributName in Attributs.ToDictionary(true).Keys)
					{
						string attributValue = Attributs.GetValue<string>(attributName, "");
						attributValue = attributValue.Replace("\"", "&#34;").Replace("<", "&#lt;").Replace(">", "&#gt;");

						xml += attributName + "=\"" + attributValue + "\" ";
					}
				}

				string t_innerXml = InnerXml;

				if ((t_innerXml != null))
					xml = xml.TrimEnd() + ">" + t_innerXml + "</" + Name + ">";
				else
					xml = xml.TrimEnd() + " />";

				return xml;
			}
		}

		public XMLNodeLight(string name) { this.Name = name; }
		public XMLNodeLight(string name, object innerText)
		{
			this.Name = name;
			_innerText = (innerText != null) ? innerText.ToString() : null;
		}

		public XMLNodeLight(string name, object innerText, Arguments attributs)
		{
			this.Name = name;
			_innerText = (innerText != null) ? innerText.ToString() : null;
			_attributs = attributs;
		}

		public XMLNodeLight(string name, object innerText, Dictionary<string, object> attributs)
		{
			this.Name = name;
			_innerText = (innerText != null) ? innerText.ToString() : null;
			_attributs = new Arguments(attributs);
		}

		public XMLNodeLight(string name, Arguments attributs)
		{
			this.Name = name;
			_attributs = attributs;
		}

		public XMLNodeLight(string name, Dictionary<string, object> attributs)
		{
			this.Name = name;
			_attributs = new Arguments(attributs);
		}

		public static List<XMLNodeLight> ParseXml(string xml)
		{
			List<XMLNodeLight> nodes = new List<XMLNodeLight>();
			if (string.IsNullOrEmpty(xml))
				return nodes;

			xml = Regex.Replace(xml, "<!--(.*?)-->", "", RegexOptions.Singleline);

			var matches = Regex.Matches(xml, "<([a-zA-Z0-9]+)(\\s+([^/>]*))?(/)?>(?(4)|(.*?)</\\1>)", RegexOptions.Singleline);

			foreach (Match match in matches)
			{
				string nodeName = match.Groups[1].Value;
				string arguments = null;
				string content = null;

				if (match.Groups[3].Success)
					arguments = match.Groups[3].Value;

				if (match.Groups[5].Success)
					content = match.Groups[5].Value;

				XMLNodeLight node = new XMLNodeLight(nodeName);
				node.InnerText = content;

				if ((arguments != null))
				{
					var argMatches = Regex.Matches(arguments, "(\\w+)=\"([^\"]*)\"", RegexOptions.IgnoreCase);

					foreach (Match argMath in argMatches)
					{
						string argName = argMath.Groups[1].Value;
						string argValue = argMath.Groups[2].Value;

						node.Attributs.AddValue(argName, argValue);
					}
				}

				nodes.Add(node);
			}

			return nodes;
		}
		
		public List<XMLNodeLight> SelectNodes(string xpath)
		{
			List<XMLNodeLight> nodes = new List<XMLNodeLight>();
			var xdoc = new System.Xml.XmlDocument();

			try
			{
				xdoc.LoadXml(OuterXml);
				var xnodes = xdoc.SelectNodes(xpath);

				foreach (System.Xml.XmlNode xnode in xnodes)
					nodes.Add(XMLNodeLight.ParseXml(xnode.OuterXml).FirstOrDefault());
			} catch { }

			return nodes;
		}

		public XMLNodeLight SelectSingleNode(string xpath)
		{
			return SelectNodes(xpath).FirstOrDefault();
		}

		public XMLNodeLight AddNode(string name, object innerText = null, bool returnChildNode = false)
		{
			return AddNode(name, innerText, returnChildNode);
		}

		public XMLNodeLight AddNode(XMLNodeLight node, bool returnChildNode = false)
		{
			if ((InnerText == null))
				InnerText = "";
			InnerText += node.ToString();
			return returnChildNode ? node : this;
		}

		public override string ToString() { return OuterXml; }
	}
}
