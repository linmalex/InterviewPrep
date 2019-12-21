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
using Toolbox;
using System.Collections.Specialized;

namespace UnitTests
{

    public class Tests
    {
        public DirectoryInfo TestFilesDirectory { get; set; }
        public List<StringPair> PairsForTesting { get; set; }
        public FileInfo[] Files { get; set; }

        public List<string> FileNames { get; set; }
        public Tests()
        {
            var slnDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            TestFilesDirectory = new DirectoryInfo(Path.Combine(slnDir.FullName, "Toolbox\\StringFiles"));
            FileInfo[] testFiles1 = TestFilesDirectory.GetFiles("*", SearchOption.AllDirectories);
            Files = TestFilesDirectory.GetFiles();
            FileNames = new List<string>();
            foreach (var item in Files)
            {
                 FileNames.Add(Path.GetFileNameWithoutExtension(item.FullName));
            }
        }
        //public void SetPairsForTesting(string testFileName)
        //{
        //    string stringsFile = Path.Combine(TestFilesDirectory, "stringsToReverse.csv");
        //    FileInfo file = new FileInfo(stringsFile);
        //}
        [SetUp]
        public void Setup()
        {
            //TestFilesExist(CurrentTestFileName);
        }
        [Test]
        public void StringPairReverseTest()
        {
            var CurrentTestFileName = "stringsToReverse.csv";
            ///-----------------------

            string stringsFile = Path.Combine(TestFilesDirectory.FullName, CurrentTestFileName);
            string[] stringPairs = File.ReadAllLines(stringsFile);
            List<StringPair> pairs = StringPair.ParseStringsToTestPairs(stringPairs, ',');
            foreach (var item in pairs)
            {
                Assert.True(item.ReverseInputString() == item.Output);
            }
        }
        [Test]
        public void PalindromeTest()
        {
            var palindromesFile = Path.Combine(TestFilesDirectory.FullName, "palindromes.json");

            JObject jObj = JObject.Parse(File.ReadAllText(palindromesFile));
            IEnumerable<bool> trueItems = jObj["true"].Children().Select(c => PalindromeTool.MyPalindromeChecker(c.ToString()));
            IEnumerable<bool> falseItems = jObj["false"].Children().Select(c => PalindromeTool.MyPalindromeChecker(c.ToString()));

            Assert.False(trueItems.Contains(false));
            Assert.False(falseItems.Contains(true));
        }
        [Test]
        public void TheirStringPairReverseTest()
        {
            var CurrentTestFileName = "stringsToReverse.csv";
            ///-----------------------

            string stringsFile = Path.Combine(TestFilesDirectory.FullName, CurrentTestFileName);
            string[] stringPairs = File.ReadAllLines(stringsFile);
            List<TheirStringPair> pairs = TheirStringPair.ParseStringsToTestPairs(stringPairs, ',');
            foreach (var item in pairs)
            {
                Assert.True(item.ReverseInputString() == item.Output);
            }
        }

        public void TestFilesExist(string fileName)
        {
            string stringsFile = Path.Combine(TestFilesDirectory.FullName, fileName);
            FileInfo file = new FileInfo(stringsFile);
            Assert.True(file.Exists);
        }
    }
}
