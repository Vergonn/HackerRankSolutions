using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        double weight = Convert.ToInt32(Console.ReadLine().Trim());
        double boxes = Convert.ToInt32(Console.ReadLine().Trim());
        double meanWeight = Convert.ToInt32(Console.ReadLine().Trim());
        double deviation = Convert.ToInt32(Console.ReadLine().Trim());

        double samplesMean = boxes * meanWeight;
        double samplesDev = Math.Sqrt(boxes) * deviation;

        Console.WriteLine(Math.Round(cumulative(samplesMean, samplesDev, weight), 4));
    }

    static double cumulative(double mean, double std, double x)
    {
        double parameter = (x - mean) / (std * Math.Sqrt(2));
        return ((0.5f) * (1 + erf(parameter)));
    }

    static double erf(double z)
    {
        double t = 1.0f / (1.0f + 0.5f * Math.Abs(z));

        // use Horner's method
        double ans = 1 - t * Math.Exp(-z * z - 1.26551223f +
                                            t * (1.00002368f +
                                            t * (0.37409196f +
                                            t * (0.09678418f +
                                            t * (-0.18628806f +
                                            t * (0.27886807f +
                                            t * (-1.13520398f +
                                            t * (1.48851587f +
                                            t * (-0.82215223f +
                                            t * (0.17087277f))))))))));
        if (z >= 0) return ans;
        else return -ans;
    }
}
