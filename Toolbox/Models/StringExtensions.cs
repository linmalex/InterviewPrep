using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Toolbox.Models
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            Regex r = new Regex(@"[^a-z^A-Z]");
            str = r.Replace(str, "");
            str = str.ToLower();
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] == str[str.Length - i - 1])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static string ReverseString(this string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                int currentPosition = str.Length - i - 1;
                sb.Append(str[currentPosition]);
            }
            return sb.ToString();
        }
    }
    public static class TheirStringExtensions
    {
        public static bool IsPalindrome(this string str)
        {
            Regex r = new Regex(@"[^a-z^A-Z]");
            str = r.Replace(str, "");
            str = str.ToLower();
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }
            return true;
        }
        public static string TheirStringReverser(this string str)
        {
            char[] charArray = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                charArray[i] = str[j];
                charArray[j] = str[i];
            }
            string reversedstring = new string(charArray);
            return reversedstring;
        }
    }
}
