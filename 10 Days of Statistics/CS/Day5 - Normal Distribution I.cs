using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        double mean = double.Parse(Console.ReadLine().Trim());
        int x = int.Parse(Console.ReadLine().Trim());

        Console.WriteLine(Math.Round(poisson(x, mean), 3));
    }

    static double poisson(int k, double lambda)
    {
        return (Math.Pow(lambda, k) * Math.Pow(Math.E, -1 * lambda)) / fact(k);
    }

    static int fact(int x)
    {
        if (x > 0)
        {
            return x * fact(x - 1);
        }
        else
        {
            return 1;
        }
    }
}
