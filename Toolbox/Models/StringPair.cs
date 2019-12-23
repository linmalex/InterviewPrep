using System;
using System.Collections.Generic;
using System.Text;

namespace Toolbox
{
    public abstract class TestPair<T>
    {
        public T Input { get; set; }
        public T ExpectedOutput { get; set; }

        public TestPair()
        {

        }


    }
    public class StringPair
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        #region constructors
        public StringPair(string input, char delimiter)
        {
            string[] split = input.Split(delimiter);
            if (split.Length > 1)
            {
                Input = split[0];
                ExpectedOutput = split[1];
            }
        }
        #endregion

        #region methods
        public static List<StringPair> ParseSet(string[] input, char delimiter)
        {
            List<StringPair> pairs = new List<StringPair>();
            foreach (var item in input)
            {
                pairs.Add(new StringPair(item, delimiter));
            }
            return pairs;
        }

        //public override List<StringPair> ParseSet(string[] set, char delimiter)
        //{
        //    List<StringPair> pairs = new List<StringPair>();
        //    foreach (var item in set)
        //    {
        //        pairs.Add(new StringPair(item, delimiter));
        //    }
        //    return pairs;
        //}

        #endregion
    }
}
