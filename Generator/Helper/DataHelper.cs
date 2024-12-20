using System;

namespace Generator.Helper;

public static class DataHelper
{
    /// <summary>
    /// Helper to generate a Geometric Brownian Motion Path for stocks
    /// </summary>
    /// <param name="S0">Initial stock price</param>
    /// <param name="mu">Drift (annual return %)</param>
    /// <param name="sigma">Volatility (%)</param>
    /// <param name="T">Time horizon in years</param>
    /// <param name="N">Number of time steps per year</param>
    /// <returns></returns>
    public static (double[], double[]) GenerateGeometricBrownianMotionPath(double S0, double mu, double sigma, double T, int N)
    {
        double dt = T / N;
        double[] t = new double[N];
        double[] S = new double[N];

        Random rand = new(DateTime.Now.Millisecond);
        t[0] = 0;
        S[0] = S0;

        double W = 0.0; // Initial Wiener process value
        
        for (int i = 1; i < N; i++)
        {
            double dW = Math.Sqrt(dt) * NextGaussian(rand);
            W += dW;
            t[i] = t[i - 1] + dt;
            S[i] = S0 * Math.Exp((mu - 0.5 * sigma * sigma) * t[i] + sigma * W);
        }

        return (t, S);
    }

    static double NextGaussian(Random rand)
    {
        // Use Box-Muller transform
        double u1 = 1.0 - rand.NextDouble(); // Avoid log(0)
        double u2 = 1.0 - rand.NextDouble();
        return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
    }
}
