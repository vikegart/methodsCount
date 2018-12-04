using System;
using System.Collections.Generic;

class UncertainFactor
{
    const int V = 1; //промежуток [0,V]
    public static void Get()
    {
        Console.WriteLine("y'' + x^2y' + x^3y = x^6 + (3-V)x^5 - 2Vx^3 + 6x - 2V");
        Console.WriteLine("y(0) = y({0}) = 0", V);
        double x = 0;
        int n = 5;
        double h = V / (n * 1.0 - 1);
        Console.WriteLine("h = {0}", h);
        List<double> fx = new List<double>();
        double x1 = 0;
        for (int i = 0; i < n; i++)
        {
            fx.Add(x1 * x1 * x1 * x1 * x1 * x1 - V * x1 * x1 * x1 * x1 * x1 + 3 * x1 * x1
* x1 * x1 - 2 * V * x1 * x1 * x1 + 6 * x1 - 2 * V);
            x1 += h;
        }
        x = 0;
        Matrix matr = new Matrix(n, n + 1);
        for (int j = 0; j < n; j++)
        {
            for (int k = 0; k < n; k++)
            {
                double funK = (k + 2) * Math.Pow(x, k) * ((k + 1) * (x - 1) + 2 * x) + (k
+ 2) * Math.Pow(x, k + 3) * (x - 1) + Math.Pow(x, k + 4) * (1 + x * (x - 1));
                matr[j, k] = funK;
            }
            matr[j, n] = fx[j];
            x += h;
        }
        Console.WriteLine("\nПолученная расширенная матрица:");
        matr.Show();
        MethodGaussa mG = new MethodGaussa();
        mG.DirectRun(matr);
        Matrix matAk = mG.InverseRun(matr);
        //Считаем y из ak
        x = 0;
        List<double> y = new List<double>();
        for (int i = 0; i < n; i++)
        {
            double yk = 0;
            for (int k = 0; k < n; k++)
            {
                yk += matAk[k, 0] * Math.Pow(x, k + 2) * (x - 1);
            }
            x += h;
            y.Add(yk);
        }
        x = 0;
        List<double> listYt = GetYt(n, x, h, V);
        Console.WriteLine("\ny:");
        for (int i = 0; i < n; i++)
            Console.Write("{0,-10}", Math.Round(y[i], 5));
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("e:");
        for (int i = 0; i < n; i++)
            Console.Write("{0,-10}", Math.Round(Math.Abs(listYt[i] - y[i])), 5);
        Console.WriteLine();
    }
    public static List<double> GetYt(int n, double x, double h, int V)
    {
        List<double> listYt = new List<double>();
        Console.WriteLine("x:");
        for (int i = 0; i < n; i++)
        {
            double newY = x * x * x - V * x * x;
            listYt.Add(newY);
            Console.Write("{0,-10}", Math.Round(x, 5));
            x += h;
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("y точные:");
        for (int i = 0; i < listYt.Count; i++)
            Console.Write("{0,-10}", Math.Round(listYt[i], 5));
        return listYt;
    }
}
