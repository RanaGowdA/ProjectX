using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRelationshipManagement.Shared.Utilities
{
    public static class StringExtensionMethods
    {
        public static string FormatAsPhoneNumber(this string phoneNumber, int isdLength = 3)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length <= isdLength)
                return phoneNumber;

            if (phoneNumber.StartsWith("+"))
            {
                if (phoneNumber.StartsWith("+1"))
                {
                    var isdPartUs = phoneNumber.Substring(0, 2);
                    var numberPartUs = phoneNumber.Substring(2);

                    return $"({isdPartUs}) {numberPartUs}";
                }

                var isdPart = phoneNumber.Substring(0, isdLength);
                var numberPart = phoneNumber.Substring(isdLength);

                return $"({isdPart}) {numberPart}";
            }

            return phoneNumber;
        }

        public static string Shorten(this string text, int length = 20)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length <= length)
                return text;

            var isdPart = text.Substring(0, length);

            return $"{isdPart}...";
        }

        public static string ToPascalCase(this string text, int maxToUpper = 2)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var splitText = text.Trim()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var texts = new List<string>();

            foreach (var subText in splitText)
            {
                if (subText.Length > maxToUpper)
                {
                    var firstChar = subText.Substring(0, 1).ToUpper();
                    var remainingChars = subText.Substring(1);

                    texts.Add(firstChar + remainingChars);
                }
                else
                {
                    texts.Add(subText.ToUpper());
                }
            }

            return string.Join(' ', texts);
        }

        public static float ToFloat(this string text)
        {
            text = text.Trim();

            if (string.IsNullOrWhiteSpace(text))
                return 0.0f;

            if (float.TryParse(text, out float result))
                return result;

            return 0.0f;
        }

        public static int ToInt(this string text)
        {
            text = text.Trim();

            if (string.IsNullOrWhiteSpace(text))
                return 0;

            if (int.TryParse(text, out int result))
                return result;

            return 0;
        }

        public static long ToLong(this string text)
        {
            text = text.Trim();

            if (string.IsNullOrWhiteSpace(text))
                return 0;

            if (long.TryParse(text, out long result))
                return result;

            return 0;
        }

        public static bool IsNumeric(this string text)
        {
            var nonNumeric = text.FirstOrDefault(ch => !char.IsDigit(ch));
            if (nonNumeric == default(char))
                return true;

            return false;
        }

    }
}
