using System;
using System.Diagnostics;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static TimeSpan StopWatch(StringReverser sr, string methodName)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            typeof(StringReverser).GetMethod(methodName).Invoke(sr, null);
            stopWatch.Stop();
            return stopWatch.Elapsed;
        }

    }
}
