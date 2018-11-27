using System;
using System.Collections.Generic;

class Boundary
    {
        const int V = 2;
        public static void Get()
        {
            Console.WriteLine("y'' + x^2y' + x^3y = x^6 + (3-V)x^5 - 2Vx^3 + 6x - 2V");
            Console.WriteLine("y(0) = y({0}) = 0", V);
            double x = 0;
            int n = 9;
            double h = 0.25;
            List<double> listYt = GetYt(n, x, h, V);
            x = 0;
            List<double> a = new List<double>();
            List<double> b = new List<double>();
            List<double> c = new List<double>();
            List<double> d = new List<double>();
            for (int i = 0; i < n; i++)
            {
                a.Add(1 / h / h - x * x / 2 / h);
                b.Add(2 / h / h - x * x * x);
                c.Add(1 / h / h + x * x / 2 / h);
                d.Add(x * x * x * x * x * x + (3 - V) * x * x * x * x * x - 2 * V * x * x * x + 6 * x - 2 * V);//fk
                x += h;
            }
            List<double> P = new List<double>();
            List<double> Q = new List<double>();
            P.Add(0);
            Q.Add(0);
            for (int i = 1; i < n; i++)
            {
                P.Add(c[i] / (b[i] - a[i] * P[i - 1]));
                Q.Add((a[i] * Q[i - 1] - d[i]) / (b[i] - a[i] * P[i - 1]));
            }
            MethodSweep mS = new MethodSweep();
            Matrix Y = mS.InverseSweepBound(n, Q, P);
            Console.WriteLine("\ny:");
            Y.Show();
            Console.WriteLine("\ne:");
            for (int i = 0; i < n; i++)                         //-0.109  //-0832 = 0.722
                Console.Write("{0,-8}", Math.Round(Math.Abs(listYt[i] - Y[i, 0]), 3));
            Console.WriteLine();
        }
        public static List<double> GetYt(int n, double x, double h, int V)
        {
            //Заполним y точные
            List<double> listYt = new List<double>();
            Console.WriteLine("x:");
            for (int i = 0; i < n; i++)
            {
                double newY = x * x * x - V * x * x;
                listYt.Add(newY);
                Console.Write("{0,-8} ", x);
                x += h;
            }
            Console.WriteLine();
            Console.WriteLine("y точные");
            for (int i = 0; i < listYt.Count; i++)
                Console.Write("{0,-8}", Math.Round(listYt[i], 3));
            return listYt;
        }
    }
