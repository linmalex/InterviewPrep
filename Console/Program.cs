using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            int runCount = 10;

            TimeSpan theirTimeTotal = new TimeSpan();
            TimeSpan myTimeTotal = new TimeSpan();
            var palindromes = @"C:\Users\linma\source\repos\InterviewPrep\UnitTests\palindromes.txt";
            var notpalindromes = @"C:\Users\linma\source\repos\InterviewPrep\UnitTests\notpalindromes.txt";
            string[] palindromeArray = File.ReadAllLines(palindromes);
            string[] notPalindromeArray = File.ReadAllLines(notpalindromes);
            for (int i = 0; i < runCount; i++)
            {
                Stopwatch w = Stopwatch.StartNew();
                foreach (var item in palindromeArray)
                {
                    var palindrome = Program.MyPalindromeChecker(item);
                }
                w.Stop();
                myTimeTotal = myTimeTotal.Add(w.Elapsed);

                w.Restart();
                foreach (var item in palindromeArray)
                {
                    var palindrome = Program.TheirPalindromeChecker(item);
                }
                w.Stop();
                theirTimeTotal = theirTimeTotal.Add(w.Elapsed);
            }

            TimeSpan myaverage = myTimeTotal / runCount;
            TimeSpan theirAverage = theirTimeTotal / runCount;
            var better = myaverage > theirAverage;
        }

        public static bool MyPalindromeChecker(string str)
        {
            Regex r = new Regex(@"[^a-z^A-Z]");
            str = r.Replace(str, "");
            str = str.ToLower();
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] == str[str.Length - i - 1])
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool TheirPalindromeChecker(string str)
        {
            Regex r = new Regex(@"[^a-z^A-Z]");
            str = r.Replace(str, "");
            str = str.ToLower(); 
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }
                return true;
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
