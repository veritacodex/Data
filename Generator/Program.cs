using System;
using Generator.Helper;

namespace Generator;
static class Program
{
    static void Main()
    {
        // Parameters
        double S0 = 100.0;  // Initial stock price
        double mu = 0.1;    // Drift (10% annual return)
        double sigma = 0.2; // Volatility (20%)
        double T = 1.0;     // Time horizon (1 year)
        int N = 365;        // Number of time steps (daily steps for 1 year)

        // Generate path
        (double[] t, double[] S) = DataHelper.GenerateGeometricBrownianMotionPath(S0, mu, sigma, T, N);

        // Output the result
        Console.WriteLine("Time\tPrice");
        for (int i = 0; i < t.Length; i++)
        {
            Console.WriteLine($"{t[i]:F4}\t{S[i]:F4}");
        }
    }    
}
