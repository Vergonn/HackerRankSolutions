using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        double A = 0.88;
        double B = 1.55;

        double dailyCostA = 160 + 40 * (A + (A * A));
        double dailyCostB = 128 + 40 * (B + (B * B));

        Console.WriteLine(Math.Round(dailyCostA, 3));
        Console.WriteLine(Math.Round(dailyCostB, 3));
    }
}
