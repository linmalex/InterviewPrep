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
        public string TestFilesDirectory
        {
            get
            {
                var solutionDirector = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
                return Path.Combine(solutionDirector.FullName, "UnitTests\\TestFiles");
            }
        }

        public Tests()
        {

        }
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void StringReverseTest()
        {
            string stringsFile = Path.Combine(TestFilesDirectory, "stringsToReverse.csv");
            FileInfo file = new FileInfo(stringsFile);
            Assert.True(file.Exists);
            var stringPairs = File.ReadAllLines(stringsFile).Select(x => x.Split(','));
            foreach (string[] pair in stringPairs)
            {
                Assert.True(pair[1] == ReverserTool.MyStringReverser(pair[0]));
            }
        }

        [Test]
        public void PalindromeTest()
        {
            var palindromesFile = Path.Combine(TestFilesDirectory, "palindromes.json");

            FileInfo file = new FileInfo(palindromesFile);
            Assert.True(file.Exists);

            JObject jObj = JObject.Parse(File.ReadAllText(palindromesFile));
            IEnumerable<bool> trueItems = jObj["true"].Children().Select(c => PalindromeTool.MyPalindromeChecker(c.ToString()));
            IEnumerable<bool> falseItems = jObj["false"].Children().Select(c => PalindromeTool.MyPalindromeChecker(c.ToString()));

            Assert.False(trueItems.Contains(false));
            Assert.False(falseItems.Contains(true));
        }

        [Test]
        public void SentenceReverseTest()
        {
            var sentencesFile = Path.Combine(TestFilesDirectory, "sentences.txt");

            var file = new FileInfo(sentencesFile);
            Assert.True(file.Exists);

            string[] sentences = File.ReadAllLines(sentencesFile);
            Assert.True(sentences.Length > 0);

            IEnumerable<string[]> splitSentences = sentences.Select(x => x.Split('|'));
            IEnumerable<string> sentenceToSplit = splitSentences.Select(x => ReverserTool.MyStringReverser(x[0]));
            foreach (string[] item in splitSentences)
            {
                var reversed = ReverserTool.MyStringReverser(item[0]);
                var matches = reversed == item[1];
                Assert.True(ReverserTool.MyStringReverser(item[0]) == item[1]);
            }
        }
    }
}