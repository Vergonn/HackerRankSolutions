using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        double[] x = new double[5] { 95, 85, 80, 70, 60 };
        double[] y = new double[5] { 85, 95, 70, 65, 70 };
        double studentScore = 80;

        double b = pearson(5, x, y) * (getSTD(y) / getSTD(x));
        double a = getMean(y) - b * getMean(x);

        Console.WriteLine(a + b * studentScore);
    }

    public static double pearson(int n, double[] xs, double[] ys)
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

    public static double getMean(double[] arr)
    {
        return arr.Sum() / arr.Length;
    }

    public static double getSTD(double[] arr)
    {
        double mean = getMean(arr);
        double sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += Math.Pow(arr[i] - mean, 2);
        }

        double variance = sum / arr.Length;

        return Math.Sqrt(variance);
    }
}
