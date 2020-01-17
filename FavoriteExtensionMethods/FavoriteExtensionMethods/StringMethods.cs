using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace FavoriteExtensionMethods
{
    public static class StringMethods
    {
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        public static bool IsInteger(this string s)
        {
            int output;
            return Int32.TryParse(s, out output);
        }

        public static string OnlyNumber(this string s)
        {
            return string.IsNullOrWhiteSpace(s) ? "" : Regex.Replace(s, "[^0-9]+", string.Empty);
        }

        public static string RemoveAccents(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();

            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }

            return sbReturn.ToString();
        }

        public static string RemoveSpecialCharacters(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            return Regex.Replace(text, "[^0-9a-zA-Z\\s]+", "");
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source == null ? false : source.IndexOf(toCheck, comp) >= 0;
        }

        public static string FirstCharToUpper(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static bool HasValue(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }
    }
}
