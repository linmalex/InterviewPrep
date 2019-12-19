using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class StringReverser
    {
        public string StringToReverse { get; set; }
        public string ReversedString { get; set; }
        public StringReverser(string str)
        {
            StringToReverse = str;
        }

        public string TheirStringReverser()
        {
            char[] charArray = StringToReverse.ToCharArray();
            for (int i = 0, j = StringToReverse.Length - 1; i < j; i++, j--)
            {
                charArray[i] = StringToReverse[j];
                charArray[j] = StringToReverse[i];
            }
            string reversedstring = new string(charArray);
            return reversedstring;
        }
        public string MyStringReverser()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < StringToReverse.Length; i++)
            {

                int currentPosition = StringToReverse.Length - i - 1;
                sb.Append(StringToReverse[currentPosition]);
            }
            return sb.ToString();
        }
    }
}
