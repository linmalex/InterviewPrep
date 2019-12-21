using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox
{
    public class TheirStringPair : StringPair
    {
        public TheirStringPair(string input, char delimiter) : base(input, delimiter)
        {

        }
        public new static List<TheirStringPair> ParseStringsToTestPairs(string[] input, char delimiter)
        {
            List<TheirStringPair> pairs = new List<TheirStringPair>();
            foreach (var item in input)
            {
                pairs.Add(new TheirStringPair(item, delimiter));
            }
            return pairs;
        }

    }
}
