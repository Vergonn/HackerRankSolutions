using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int samples = 100;
        double mean = 500;
        double std = 80;
        double z_score = 1.96; // equivalent to 95% confidence interval

        double marginOfError = z_score * std / Math.Sqrt(samples);

        Console.WriteLine(mean - marginOfError);
        Console.WriteLine(mean + marginOfError);
    }
}
