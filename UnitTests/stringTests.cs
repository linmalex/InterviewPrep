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
using Toolbox.Models;

namespace UnitTests
{

    public class Tests
    {
        public List<StringPair> PairsForTesting { get; set; }
        public List<(string name, FileInfo fileInfo)> TestFiles { get; set; }
        public Tests()
        {
            var slnDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            
            var testFilesDir = new DirectoryInfo(Path.Combine(slnDir.FullName, "Toolbox\\StringFiles"));

            TestFiles = new List<(string name, FileInfo fileInfo)>();
            
            foreach (var item in testFilesDir.GetFiles())
            {
                (string fileName, FileInfo fileInfo) fileX = (Path.GetFileNameWithoutExtension(item.FullName), item);
                TestFiles.Add(fileX);
            }
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringPairReverseTest()
        {
            ///-----------------------Verify file exists
            var testFileName = "stringsToReverse";
            Assert.True(TestFiles.Select(f => f.name).Contains(testFileName));
            
            ///-----------------------
            FileInfo testFileInfo = TestFiles.Where(fi => fi.name == testFileName).FirstOrDefault().fileInfo; //get appropriate file info
            var stringPairs = File.ReadAllLines(testFileInfo.FullName); //read file as array of strings
            var parsedStringPairs = StringPair.ParseStringSetToTestPairs(stringPairs, ',');
            parsedStringPairs.ForEach(p => Assert.True(p.Input != p.ExpectedOutput)); //verify that the original input doesn't match the expected output
            parsedStringPairs.ForEach(p => Assert.True(p.Input.ReverseString() == p.ExpectedOutput)); //verify that the reversed input does match the expected output
        }
        [Test]
        public void IsPalindromeTest()
        {
            ///-----------------------Verify file exists
            
            var testFileName = "palindromes";
            Assert.True(TestFiles.Select(f => f.name).Contains(testFileName));

            ///----------------------- parse json file to groups
            FileInfo testFileInfo = TestFiles.Where(fi => fi.name == testFileName).FirstOrDefault().fileInfo; //get appropriate file info
            JObject jObj = JObject.Parse(File.ReadAllText(testFileInfo.FullName));
            List<string> expectedTrueItems = jObj["true"].Children().Select(c => c.ToString()).ToList();
            List<string> expectedFalseItems = jObj["false"].Children().Select(c=>c.ToString()).ToList();
            
            ///-------------------------test
            expectedFalseItems.ForEach(s => Assert.False(s.IsPalindrome()));
            expectedTrueItems.ForEach(s => Assert.True(s.IsPalindrome()));
        }
    }
}
