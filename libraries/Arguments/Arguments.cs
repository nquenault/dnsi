using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Utility
{
	public class Arguments
	{
		private Dictionary<string, object> m_Values = new Dictionary<string, object>();
		private Dictionary<string, string> m_CaseKeys = new Dictionary<string, string>();

		public Dictionary<string, object> ToDictionary(bool OriginalKeysCase = true)
		{
			if (!OriginalKeysCase)
				return m_Values;
			else
			{
				Dictionary<string, object> valuesWithCase = new Dictionary<string, object>();
				m_Values.Keys.ToList().ForEach(regKey => valuesWithCase.Add(m_CaseKeys[regKey], m_Values[regKey]));
				return valuesWithCase;
			}
		}

		public List<KeyValuePair<string, object>> ToList(bool OriginalKeysCase = false)
		{
			if (!OriginalKeysCase)
				return m_Values.ToList();
			else
			{
				List<KeyValuePair<string, object>> valuesWithCase = new List<KeyValuePair<string, object>>();
				m_Values.Keys.ToList().ForEach(regKey => valuesWithCase.Add(new KeyValuePair<string, object>(m_CaseKeys[regKey], m_Values[regKey])));
				return valuesWithCase;
			}
		}

		public Arguments() { }
		public Arguments(string key, object value) { AddValue(key, value); }
		public Arguments(Dictionary<string, object> values) { AddValues(values); }
		public Arguments(string valuesToParse) { AddValuesToParse(valuesToParse); }

		public Arguments Reset()
		{
			m_Values.Clear();
			m_CaseKeys.Clear();

			return this;
		}

		public Arguments SetValues(Dictionary<string, object> dictionary)
		{
			return Reset().AddValues(dictionary);
		}

		public Arguments ReplaceVarname(string oldVarname, string newVarname)
		{
			string regKey = oldVarname.Clone().ToString().ToLower();
			string newRegKey = newVarname.Clone().ToString().ToLower();

			if (m_CaseKeys.ContainsKey(regKey))
			{
				object value = m_Values[regKey];

				m_Values.Remove(regKey);
				m_CaseKeys.Remove(regKey);

				if (m_CaseKeys.ContainsKey(newRegKey))
					m_CaseKeys[newRegKey] = newVarname;
				else
					m_CaseKeys.Add(newRegKey, newVarname);

				if (m_Values.ContainsKey(newRegKey))
					m_Values[newRegKey] = value;
				else
					m_Values.Add(newRegKey, value);
			}

			return this;
		}

		public Arguments DuplicateVarname(string varname, string newVarname)
		{
			string regKey = varname.Clone().ToString().ToLower();
			string newRegKey = newVarname.Clone().ToString().ToLower();

			if (m_CaseKeys.ContainsKey(regKey))
			{
				if (m_Values.ContainsKey(newRegKey))
					m_Values[newRegKey] = m_Values[regKey];
				else
					m_Values.Add(newRegKey, m_Values[regKey]);

				if (m_CaseKeys.ContainsKey(newRegKey))
					m_CaseKeys[newRegKey] = newVarname;
				else
					m_CaseKeys.Add(newRegKey, newVarname);
			}

			return this;
		}

		public Arguments AddValue(string key, object value, bool updateIfExists = true)
		{
			string regKey = key.Clone().ToString().ToLower();

			if (!m_Values.ContainsKey(regKey))
			{
				m_Values.Add(regKey, value);
				m_CaseKeys.Add(regKey, key);
			}
			else if (updateIfExists)
				m_Values[regKey] = value;

			return this;
		}

		public Arguments AddValues(Dictionary<string, object> values, bool updateIfExists = true)
		{
			if ((values == null))
				values = new Dictionary<string, object>();

			values.Keys.ToList().ForEach(key => AddValue(key, values[key], updateIfExists));

			return this;
		}

		public Arguments AddValueToParse(string values, bool updateIfExists = true)
		{
			return AddValuesToParse(values, updateIfExists);
		}

		public Arguments AddValuesToParse(string values, bool updateIfExists = true)
		{
			return AddValues(ParseCommandArgsLine(CommandArgLine: values), updateIfExists);
		}

		public bool HasValue(string key)
		{
			string regKey = key.Clone().ToString().ToLower();

			return m_Values.ContainsKey(regKey);
		}

		public object GetValue(string key, object defaultValue = null)
		{
			return GetValue<object>(key, defaultValue);
		}

		public T GetValue<T>(string key, object defaultValue = null)
		{
			string regKey = key.Clone().ToString().ToLower();

			if (m_Values.ContainsKey(regKey))
			{
				try {
					return (T)m_Values[regKey];
				} catch {
					try {
						return (T)defaultValue;
					} catch {
						return (T)((object)null);
					}
				}
			} else {
				try {
					return (T)defaultValue;
				} catch {
					return (T)((object)null);
				}
			}
		}

		public Nullable<T> GetNullable<T>(string key, object defaultValue = null) where T : struct
		{
			Nullable<T> result = new Nullable<T>();

			if (HasValue(key))
				result = GetValue<T>(key, defaultValue);

			return result;
		}

		private Dictionary<string, object> ParseCommandArgsLine(string ArgumentsCharsSeparator = "; ,|@+*!&", string ArgumentsCharsIntroductor = "-/~", string ArgumentsCharsValuesSeparator = ": =", string DecodeHexadecimalPreStringChars = "%", string CommandArgLine = null)
		{
			Dictionary<string, object> response = new Dictionary<string, object>();
			string ArgName = "";
			string ArgValue = "";
			bool bWriteArgName = true;
			bool quoteOn = false;
			string buffer = null;

			if (string.IsNullOrEmpty(CommandArgLine))
			{
				//Throw New Exception("CommandArgLine is null or empty")
				return response;
			}

			Action<string, string> addToResponse = (string aVarname, string aValue) =>
			{
				if (string.IsNullOrEmpty(DecodeHexadecimalPreStringChars))
				{
					response.Add(aVarname, aValue);
				}
				else
				{
					//response.Add(
					//    aVarname.ResolveHexEntities(DecodeHexadecimalPreStringChars),
					//    aValue.ResolveHexEntities(DecodeHexadecimalPreStringChars)
					//)
					response.Add(aVarname, aValue);
				}
			};

			for (var i = 1; i <= CommandArgLine.Length; i++)
			{
				buffer = CommandArgLine.Substring(i, 1);

				if (buffer == "\"")
				{
					quoteOn = !quoteOn;

					if (i == CommandArgLine.Length && !string.IsNullOrEmpty(ArgName))
						addToResponse(ArgName, ArgValue);

					continue;
				}

				if (!quoteOn && (ArgumentsCharsIntroductor.Contains(buffer) | ArgumentsCharsSeparator.Contains(buffer)))
				{
					if (!bWriteArgName && !string.IsNullOrEmpty(ArgName))
					{
						addToResponse(ArgName, ArgValue);

						ArgName = "";
						ArgValue = "";

						bWriteArgName = true;
						continue;
					}
					if (bWriteArgName && !string.IsNullOrEmpty(ArgName))
					{
						bWriteArgName = false;
						continue;
					}
					continue;
				}

				if (!quoteOn && ArgumentsCharsValuesSeparator.Contains(buffer) && bWriteArgName)
				{
					bWriteArgName = false;
					continue;
				}

				if (bWriteArgName)
					ArgName += buffer;
				else
					ArgValue += buffer;

				if (i == CommandArgLine.Length && !string.IsNullOrEmpty(ArgName))
					addToResponse(ArgName, ArgValue);
			}

			return response;
		}

		public Arguments Clone()
		{
			return new Arguments(ToDictionary(true));
		}
	}
}