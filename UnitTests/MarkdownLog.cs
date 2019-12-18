using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTests
{
    public class MarkdownLog
    {
        public string RunDate { get; set; }
        public string Header { get; set; }
        public List<FileInfo> TestLogs { get; set; }
        public string[] DataRows { get; set; }

        public MarkdownLog()
        {
            string logRootFolder = @"C:\Users\linma\source\repos\InterviewPrep\UnitTests\Logs";
            TestLogs = new List<FileInfo>()
            {
                new FileInfo(Path.Combine(logRootFolder,"StringReverserTestLog.md"))
            };
        }
        public List<string> LogAsMarkdownTable(TimeSpan myaverage, TimeSpan theirAverage)
        {

            List<string> markdownLines = new List<string>()
            {
                "",
                string.Format("## {0}", DateTime.Now),
                ""
            };
            markdownLines.AddRange(MarkdownTableHeader(new string[] { "Name", "Value" }));
            AddMarkdownTableData(markdownLines, myaverage, theirAverage);
            markdownLines.Add("");
            FileInfo logfile = TestLogs.Where(f => f.Name == "StringReverserTestLog.md").FirstOrDefault();
            using StreamWriter fileWriter = logfile.AppendText();
            foreach (string item in markdownLines)
            {
                fileWriter.WriteLine(item);
            }
            return markdownLines;

        }
        private void AddMarkdownTableData(List<string> markdownLines, TimeSpan myAverage, TimeSpan theirAverage)
        {
            markdownLines.Add(string.Format("| My average time | {0} |", Math.Round(myAverage.TotalMilliseconds, 4)));
            markdownLines.Add(string.Format("| Their average time | {0} |", Math.Round(theirAverage.TotalMilliseconds, 4)));
        }
        public string[] MarkdownTableHeader(string[] headerValues)
        {
            StringBuilder titleRowBuilder = new StringBuilder("| ");
            StringBuilder dividerRowBuilder = new StringBuilder("| ");
            foreach (var header in headerValues)
            {
                titleRowBuilder.Append(string.Format("{0} |", header));
                dividerRowBuilder.Append(" --- |");
            }
            return new string[] { titleRowBuilder.ToString(), dividerRowBuilder.ToString() };
        }
    }
}