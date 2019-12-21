using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox
{
    public class StringPair
    {
        public string Input { get; set; }
        public string Output { get; set; }

        public StringPair()
        {

        }

        public StringPair(string input, char delimiter)
        {
            string[] split = input.Split(delimiter);
            if (split.Length > 1)
            {
                Input = split[0];
                Output = split[1];
            }
        }
        public static List<StringPair> ParseStringsToTestPairs(string[] input, char delimiter)
        {
            List<StringPair> pairs = new List<StringPair>();
            foreach (var item in input)
            {
                pairs.Add(new StringPair(item, delimiter));
            }
            return pairs;
        }

        public string ReverseInputString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Input.Length; i++)
            {
                int currentPosition = Input.Length - i - 1;
                sb.Append(Input[currentPosition]);
            }
            return sb.ToString();
        }
    }
    //todo add test to validate Csv test files and make sure they have only one comma
}
