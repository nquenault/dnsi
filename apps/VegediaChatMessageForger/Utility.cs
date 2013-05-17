using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace VegediaChatMessageForger
{
    static class Utility
    {
        private static class Generator
        {
            private static readonly Random _random = new Random();
            public static int Rand(int max = 100, int min = 0) { return _random.Next(min, max + 1); }
        }
        public static int Rand(int max = 100, int min = 0) { return Generator.Rand(max, min); }

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

        public static string EncodeToCharCode(string value, bool doNotEncap = false)
        {
            string encodedString = "";

            foreach (char c in value.ToArray())
                encodedString += ((int)c).ToString() + ",";

            encodedString = encodedString.TrimEnd(new char[] {','});

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
    }
}
