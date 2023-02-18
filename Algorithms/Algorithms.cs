using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            int factorial = 1;
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"Factorial being calculated must be greater then zero.");
            }
            else if (n > 0)
            {
                try
                {
                    checked
                    {
                        IEnumerable<int> numList = Enumerable.Range(1, n);
                        factorial = numList.Aggregate((f, s) => f * s);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return factorial;
        }

        public static string FormatSeparators(params string[] items)
        {
            try
            {
                string lastSeperator = items.Count() > 1 ? " and " : "";
                return string.Join(", ", items.Take(items.Length - 1).ToArray()) + lastSeperator + items[items.Length - 1];
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
