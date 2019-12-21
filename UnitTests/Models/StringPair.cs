using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Models
{
    class StringPair
    {
        public string Input { get; set; }
        public string Output { get; set; }

        public List<string[]> TryParse(string[] input, char delimiter)
        {
            List<string[]> output = new List<string[]>();
            foreach (var item in input)
            {
                string[] split = item.Split(delimiter);
                if (split.Length>1)
                {
                    output.Add(split);
                }
            }
            return output;
        }
    }
}
