using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MERG_BackEnd
{
    public static class StringExtension
    {
        public static Tuple<bool, int> ConvertToInt(this string text)
        {
            var succes = int.TryParse(text, out var number);
            if (succes)
            {
                return new Tuple<bool, int>(succes, number);
            }
            return new Tuple<bool, int>(succes, 0);
        }
        public static string Validate(this string text)
        {
            const string lettersRegex = @"^[a-zA-Ząčęėįšųū]+\s?[a-zA-Ząčęėįšųū]*$";
            if (!string.IsNullOrWhiteSpace(text))
            {
                var IsValid = Regex.IsMatch(text, lettersRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                return IsValid ? text : text.Remove(text.Length - 1);
            }
            return "";
        }
    }
}
