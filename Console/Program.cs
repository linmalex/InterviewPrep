using System;
using System.Collections.Specialized;
using System.Collections;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var s = "This is a random string";

            //var x = System.Globalization.CultureInfo.CurrentUICulture;
            //var comparer = new Comparer(x);
            //ListDictionary ls = new ListDictionary(comparer);
            //var y = ls.Keys;

            DirectoryInfo x = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent;
            var y = Path.Combine(x.FullName, "UnitTests\\TestFiles\\stringsToReverse.csv");

            ListDictionary ls = new ListDictionary();
            File.ReadAllLines(y).Select(l => l.Split(',')).ToList().ForEach(l => ls.Add(l[0], l[1]));


        }
    }
}
