using Console;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTests
{
    public class Tests
    {
        public TestToolbox Toolbox { get; set; }

        public Tests()
        {

        }
        [SetUp]
        public void Setup()
        {
            Toolbox = new TestToolbox();
        }

        [Test]
        public void StringReverseComparisons()
        {
            var stringToReverse = "sdlkfja;osidfulkjer";
            var sr = new StringReverser(stringToReverse);

            int runCount = 10;

            TimeSpan theirTimeTotal = new TimeSpan();
            TimeSpan myTimeTotal = new TimeSpan();

            for (int i = 0; i < runCount; i++)
            {

                Toolbox.StringReverserStopWatch(sr, "MyStringReverser", out TimeSpan myTime);
                myTimeTotal += myTime;
                Toolbox.StringReverserStopWatch(sr, "TheirStringReverser", out TimeSpan theirTime);
                theirTimeTotal += theirTime;
            }

            TimeSpan myaverage = myTimeTotal / runCount;
            TimeSpan theirAverage = theirTimeTotal / runCount;
            MarkdownLog log = new MarkdownLog();

            log.LogAsMarkdownTable(myaverage, theirAverage);
        }
    }
}