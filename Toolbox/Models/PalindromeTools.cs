using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Toolbox.Models
{
    public class PalindromeTools
    {
        public static (string, (TimeSpan, TimeSpan)) FindBetterPalindromAlgoritm()
        {
            DirectoryInfo solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            var unitTestFilesDir = Path.Combine(solutionDirectory.FullName, @"UnitTests\TestFiles");
            var palindromesFile = Path.Combine(unitTestFilesDir, "palindromes.json");

            JObject jObj = JObject.Parse(File.ReadAllText(palindromesFile));
            IEnumerable<string> trueItems = jObj["true"].Children().Select(c => c.ToString());
            IEnumerable<string> falseItems = jObj["false"].Children().Select(c => c.ToString());

            var mine = TimeTool.GetTimeMetrics(trueItems, StringExtensions.IsPalindrome);
            var theirs = TimeTool.GetTimeMetrics(trueItems, TheirStringExtensions.IsPalindrome);

            return mine.avg > theirs.avg ? ("mine", mine) : ("theirs", theirs);
        }
    }
}
