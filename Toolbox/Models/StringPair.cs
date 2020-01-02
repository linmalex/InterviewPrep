using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toolbox
{
    public class StringPair : ITestPair<StringPair, string>
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }

        public IEnumerable<StringPair> ParseFromStringPair(IEnumerable<StringPair> input)
        {
            throw new NotImplementedException();
        }

        public StringPair(string inputLine, char delim): this()
        {
            string[] splitInput = inputLine.Split(delim);
            if (splitInput.Length == 2)
            {
                Input = splitInput[0];
                ExpectedOutput = splitInput[1];
            }
        }
        public StringPair()
        {
        }
    }
}
