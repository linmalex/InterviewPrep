using ConsoleApp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTests
{
    public class Tests
    {

        public Tests()
        {

        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PalindromeTest()
        {
            DirectoryInfo solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            var unitTestFilesDir = Path.Combine(solutionDirectory.FullName, @"UnitTests\TestFiles");
            var palindromesFile = Path.Combine(unitTestFilesDir, "palindromes.json");

            JObject jObj = JObject.Parse(File.ReadAllText(palindromesFile));
            IEnumerable<bool> trueItems = jObj["true"].Children().Select(c => PalindromeTool.MyPalindromeChecker(c.ToString()));
            IEnumerable<bool> falseItems = jObj["false"].Children().Select(c => PalindromeTool.MyPalindromeChecker(c.ToString()));

            Assert.False(trueItems.Contains(false));
            Assert.False(falseItems.Contains(true));
        }
    }
}