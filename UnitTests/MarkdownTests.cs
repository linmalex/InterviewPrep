using NUnit.Framework;
using ConsoleApp;
using System.Collections.Generic;
using Toolbox.Models;

namespace UnitTests
{
    public class MarkdownTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void MarkdownHeaderTest()
        {
            var log = new LogTool();
            string[] headers = new string[] { "Name", "Age", "Another One" };
            string[] headers2 = new string[] { "Name", "Age", "Another One", "Adding More", "To Keep it interesting" };
            List<string> markdownLines = new List<string>();
            List<string> markdownLines2 = new List<string>();
            log.ConstructMarkdownTableHeader(headers, markdownLines);
            log.ConstructMarkdownTableHeader(headers2, markdownLines2);
            Assert.True(markdownLines[0] == "| Name | Age | Another One |");
            Assert.True(markdownLines2[0] == "| Name | Age | Another One | Adding More | To Keep it interesting |");
            Assert.True(markdownLines[1] == "| --- | --- | --- |");
            Assert.True(markdownLines2[1] == "| --- | --- | --- | --- | --- |");
        }
    }
}