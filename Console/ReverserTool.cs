using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp
{
    public class ReverserTool
    {
        public string StringToReverse { get; set; }
        public string ReversedString { get; set; }
        public ReverserTool(string str)
        {
            StringToReverse = str;
        }

        public string TheirStringReverser()
        {
            char[] charArray = StringToReverse.ToCharArray();
            for (int i = 0, j = StringToReverse.Length - 1; i < j; i++, j--)
            {
                charArray[i] = StringToReverse[j];
                charArray[j] = StringToReverse[i];
            }
            string reversedstring = new string(charArray);
            return reversedstring;
        }
        public static string MyStringReverser(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                int currentPosition = str.Length - i - 1;
                sb.Append(str[currentPosition]);
            }
            return sb.ToString();
        }
        public void StringReverserStopWatch(ReverserTool sr, string methodName, out TimeSpan time)
        {
            var watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            typeof(ReverserTool).GetMethod(methodName).Invoke(sr, null);
            watch.Stop();
            time = watch.Elapsed;
        }
        public void StringReverseComparisons()
        {
            var stringToReverse = "sdlkfja;osidfulkjer";
            var sr = new ReverserTool(stringToReverse);

            int runCount = 10;

            TimeSpan theirTimeTotal = new TimeSpan();
            TimeSpan myTimeTotal = new TimeSpan();

            for (int i = 0; i < runCount; i++)
            {

                StringReverserStopWatch(sr, "MyStringReverser", out TimeSpan myTime);
                myTimeTotal += myTime;
                StringReverserStopWatch(sr, "TheirStringReverser", out TimeSpan theirTime);
                theirTimeTotal += theirTime;
            }

            TimeSpan myaverage = myTimeTotal / runCount;
            TimeSpan theirAverage = theirTimeTotal / runCount;
            MarkdownLog log = new MarkdownLog();
            KeyValuePair<string, string> mine = new KeyValuePair<string, string>("My Average Time", Math.Round(myaverage.TotalMilliseconds, 4).ToString());
            KeyValuePair<string, string> theirs = new KeyValuePair<string, string>("Their Average Time", Math.Round(theirAverage.TotalMilliseconds, 4).ToString());
            log.LogAsMarkdownTable(new KeyValuePair<string, string>[] { mine, theirs });
        }
    }
}
