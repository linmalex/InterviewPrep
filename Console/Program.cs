using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 0, 3, 12 };
            int n = arr[0];
            int z = arr[0];
            while (true)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (n == 0)
                    {
                        n = arr[i + 1];
                    }
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (z != 0)
                    {
                        z = arr[i + 1];
                    }
                }

            }
        }
    }
}
