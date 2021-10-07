using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        List<double> xs = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToDouble(x)).ToList();
        List<double> ys = Console.ReadLine().Trim().Split(' ').Select(x => Convert.ToDouble(x)).ToList();

        Console.WriteLine(pearson(n, xs, ys));
    }

    public static double pearson(int n, List<double> xs, List<double> ys)
    {
        double xMean = getMean(xs);
        double yMean = getMean(ys);

        double numerator = 0;
        for (int i = 0; i < n; i++)
        {
            numerator += (xs[i] - xMean) * (ys[i] - yMean);
        }

        return numerator / (n * getSTD(xs) * getSTD(ys));
    }

    public static double getMean(List<double> arr)
    {
        return arr.Sum() / arr.Count;
    }

    public static double getSTD(List<double> arr)
    {
        double mean = getMean(arr);
        double sum = 0;

        for (int i = 0; i < arr.Count; i++)
        {
            sum += Math.Pow(arr[i] - mean, 2);
        }

        double variance = sum / arr.Count;

        return Math.Sqrt(variance);
    }
}
