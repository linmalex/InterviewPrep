using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Console;

namespace ConsoleApp
{
    public class PalindromeTool
    {
        public void ComparePalindromeAlgorithms()
        {
            DirectoryInfo solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            var unitTestFilesDir = Path.Combine(solutionDirectory.FullName, @"UnitTests\TestFiles");
            var palindromesFile = Path.Combine(unitTestFilesDir, "palindromes.json");

            JObject jObj = JObject.Parse(File.ReadAllText(palindromesFile));
            IEnumerable<string> trueItems = jObj["true"].Children().Select(c => c.ToString());
            IEnumerable<string> falseItems = jObj["false"].Children().Select(c => c.ToString());

            var myAverage = Toolbox.GetAverageTime(trueItems, MyPalindromeChecker).avg;
            var theirAverage = Toolbox.GetAverageTime(trueItems, TheirPalindromeChecker).avg;
        }
        public static bool MyPalindromeChecker(string str)
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
        public static bool TheirPalindromeChecker(string str)
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
    }
}
