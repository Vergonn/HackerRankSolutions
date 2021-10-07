using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(String[] args)
    {
        List<float> vals = Console.ReadLine().Trim().Split(' ').ToList().Select(arr => float.Parse(arr.ToString())).ToList();
        float d = float.Parse(Console.ReadLine().Trim());

        float p = vals[0] / vals[1];
        float s = (float)(Math.Pow(1 - p, d - 1) * p);
        Console.WriteLine(Math.Round(s, 3));
    }

    static float fact(float n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * fact(n - 1);
        }
    }

    static float comb(float n, float x)
    {
        return fact(n) / (fact(x) * fact(n - x));
    }
}
