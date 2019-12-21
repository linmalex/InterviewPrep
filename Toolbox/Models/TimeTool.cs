using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Toolbox
{
    public class TimeTool
    {
        public static (TimeSpan total, TimeSpan avg) GetAverageTime(IEnumerable<string> items, Func<string, bool> method)
        {
            TimeSpan totalTime = new TimeSpan();
            foreach (var item in items)
            {
                Stopwatch w = Stopwatch.StartNew();
                method(item);
                w.Stop();
                totalTime = totalTime.Add(w.Elapsed);
            }
            TimeSpan average = totalTime / items.Count();
            return (totalTime, average);
        }

    }
}
