using System;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            int factorial = 1;
            while (n > 1)
            {
                factorial *= n;
                n--;
            }
            return factorial;
        }

        public static string FormatSeparators(params string[] items)
        {
            int l = items.Length;
            int c = 0;
            string result = "";
            foreach (var item in items)
            {
                c++;
                if (c == l) { result += " and " + item; } // last Item
                else if (c == l-1) { result += item; }    // second to last Item
                else { result += item + ", "; }           // everything else
            }
            return result;
        }
    }
}