using Console;
using System;
using System.Diagnostics;

namespace UnitTests
{
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