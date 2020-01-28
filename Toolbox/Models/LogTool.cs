using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toolbox.Models
{
    public class LogTool
    {
        public string RunDate { get; set; }
        public string Header { get; set; }
        public List<FileInfo> TestLogs { get; set; }
        public string[] DataRows { get; set; }

        public LogTool()
        {
            string logRootFolder = @"C:\Users\linma\source\repos\InterviewPrep\UnitTests\Logs";
            TestLogs = new List<FileInfo>()
            {
                new FileInfo(Path.Combine(logRootFolder,"StringReverserTestLog.md"))
            };
        }
        public List<string> LogAsMarkdownTable(KeyValuePair<string, string>[] values)
        {

            List<string> markdownLines = new List<string>()
            {
                "",
                string.Format("## {0}", DateTime.Now),
                ""
            };

            var dataKeys = values.Select(v => v.Key).ToArray();
            ConstructMarkdownTableHeader(dataKeys, markdownLines);
            ConstructMarkdownTableRow(values.Select(v => v.Value).ToArray(), markdownLines);
            markdownLines.Add("");
            FileInfo logfile = TestLogs.Where(f => f.Name == "StringReverserTestLog.md").FirstOrDefault();
            using StreamWriter fileWriter = logfile.AppendText();
            foreach (string item in markdownLines)
            {
                fileWriter.WriteLine(item);
            }
            return markdownLines;

        }
        public void ConstructMarkdownTableHeader(string[] headerValues, List<string> markdownLines)
        {
            if (markdownLines == null)
            {
                markdownLines = new List<string>();
            }
            StringBuilder titleRowBuilder = new StringBuilder("|");
            StringBuilder dividerRowBuilder = new StringBuilder("|");
            foreach (var header in headerValues)
            {
                titleRowBuilder.Append(string.Format(" {0} |", header));
                dividerRowBuilder.Append(" --- |");
            }
            markdownLines.Add(titleRowBuilder.ToString());
            markdownLines.Add(dividerRowBuilder.ToString());
        }
        private void ConstructMarkdownTableRow(string[] dataValues, List<string> markdownLines)
        {
            StringBuilder sb = new StringBuilder("| ");
            foreach (string item in dataValues)
            {
                sb.Append(string.Format(" {0} |", item));
            }
            markdownLines.Add(sb.ToString());
        }
    }
}
