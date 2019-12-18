using Console;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringReverseComparisons()
        {
            var stringToReverse = "sdlkfja;osidfulkjer";
            var sr = new StringReverser(stringToReverse);
            TestToolbox toolbox = new TestToolbox();
            toolbox.StringReverserStopWatch(sr, "MyStringReverser", out TimeSpan myTime);
            toolbox.StringReverserStopWatch(sr, "TheirStringReverser", out TimeSpan theirTime);
            Assert.IsTrue(myTime < theirTime);
        }

    }

    public class TestToolbox
    {
        public Stopwatch Watch { get; set; }


        public TestToolbox()
        {
            Watch = new Stopwatch();
        }
        public void StringReverserStopWatch(StringReverser sr, string methodName, out TimeSpan time)
        {
            Watch.Reset();
            Watch.Start();
            typeof(StringReverser).GetMethod(methodName).Invoke(sr, null);
            Watch.Stop();
            time = Watch.Elapsed;
        }
    }
}