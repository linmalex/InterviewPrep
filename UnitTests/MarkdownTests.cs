using NUnit.Framework;
using ConsoleApp;
using System.Collections.Generic;

namespace Tests
{
    public class MarkdownTests
    {
        [SetUp]
        public void Setup()
        {
        }
        //todo add markdown logs back in
        //[Test]
        //public void MarkdownHeaderTest()
        //{
        //    var log = new MarkdownLog();
        //    string[] headers = new string[] { "Name", "Age", "Another One" };
        //    string[] headers2 = new string[] { "Name", "Age", "Another One","Adding More","To Keep it interesting" };
        //    List<string> markdownLines = new List<string>();
        //    List<string> markdownLines2 = new List<string>();
        //    log.MarkdownTableHeader(headers, markdownLines);
        //    log.MarkdownTableHeader(headers2, markdownLines2);
        //    Assert.True(markdownLines[0] == "| Name | Age | Another One |");
        //    Assert.True(markdownLines2[0] == "| Name | Age | Another One | Adding More | To Keep it interesting |");
        //    Assert.True(markdownLines[1] == "| --- | --- | --- |");
        //    Assert.True(markdownLines2[1] == "| --- | --- | --- | --- | --- |");
        //}
    }
}