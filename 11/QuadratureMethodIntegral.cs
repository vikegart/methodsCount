using System;
using System.Collections.Generic;

class QuadratureMethodIntegral
    {
        const int V = 1;
        const double lamb = 1;
        public static void Get()
        {
            Console.WriteLine("Интеграл Фредгольма");
            Console.WriteLine("A(x,t) = xt + x^2t^2 + x^3t^3");
            Console.WriteLine("a = 0, b = {0}", V);
            Console.WriteLine("Lambda = {0}", lamb);
            int n = 4;
            Console.WriteLine("n = {0}", n);
            double h = V / (n * 1.0 - 1);
            Console.WriteLine("h = {0}", h);
            double x = 0;
            double t = 0;
            Console.WriteLine("\nf(x):");
            List<double> f = new List<double>();
            for (int i = 0; i < n; i++)
            {
                f.Add(V + x*x*23/15.0 + x*x*x*5/12.0 + x*6/8.0);
                x += h;
                Console.Write("{0,-10} ", Math.Round(f[i], 8));
            }
            Console.WriteLine();
            bool degenerateCore = false; //Ядро невырожденное
            Matrix matr;
            if (degenerateCore)
            {
                Console.WriteLine("Вырожденное ядро");
                matr = DegenerateCoreCase(0, h, n);
            }
            else
            {
                Matrix A = new Matrix(n, n);
                x = 0;
                t = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        A[i, j] = x * t + x * x * t * t + x * x * x * t * t * t;
                        t += h;
                    }
                    t = 0;
                    x += h;
                }
                Console.WriteLine("\n\nМатрица А(x,t):");
                A.Show();
                matr = new Matrix(n, n + 1);
                for (int k = 0; k < n; k++) //Заполняем таблицу коэффициентов для решения СЛАУ
                {
                    for (int j = 0; j < n; j++)
                    {
                        double betta = h;
                        if (j == n - 1)
                            betta = 0;
                        if (j == k)
                            matr[k, j] = 1 + lamb * betta * A[k, k];
                        else
                            matr[k, j] = lamb * betta * A[k, j];
                    }
                    matr[k, n] = f[k];
                }
            }
            Console.WriteLine("Матрица коэффициентов:");
            matr.Show();              
            List<double> yT;          
            MethodGaussa mG = new MethodGaussa();
            mG.DirectRun(matr); 
            Matrix matYk = mG.InverseRun(matr); 
            if (degenerateCore)
            {
                Console.WriteLine("\n\nGamma:");
                matYk.ShowVec();
                x = 0;
                Console.WriteLine();
                List<double> y = new List<double>();
                for (int i = 0; i < n; i++)
                {
                    double temp = 0; 
                    for (int j = 0; j < n; j++) //Сумма
                        temp += Math.Pow(x, j + 1) * matYk[j, 0];
                    y.Add(f[i] - lamb * temp);
                    x+=h;
                }
                Console.WriteLine("\ny:");
                for (int i = 0; i < n; i++)
                     Console.Write("{0,-10} ", Math.Round(y[i],8));
                yT = GetYt(x, h, n);
                Console.WriteLine("\n\ne:");
                for (int i = 0; i < n; i++)
                    Console.Write("{0,-10} ", Math.Round(Math.Abs(yT[i] - y[i]), 8));
            }
            else
            {
                yT = GetYt(x, h, n);
                Console.WriteLine("\n\ny:");
                matYk.ShowVec();
                Console.WriteLine("\n\ne:");
                for (int i = 0; i < n; i++)
                    Console.Write("{0,-10} ", Math.Round(Math.Abs(yT[i] - matYk[i, 0]), 5));
            }          
        }
        public static List<double> GetYt(double x, double h, int n)
        {
            List<double> yT = new List<double>();
            x = 0;
            Console.WriteLine("x:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,-10} ",Math.Round(x,5));
                yT.Add(x*x+V);
                x +=h;              
            }
            Console.WriteLine("\n\nу точные:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0,-10} ",Math.Round(yT[i],5));
            }
            return yT;
        }
        public static Matrix DegenerateCoreCase(double x, double h, int n) 
        {
            double A = 23 / 15.0;     //коэффициенты в f(x)
            double B = 5 / 12.0;     
            double C = 6 / 8.0;      
            double t = 0;           
            double[,] alpha = new double[n,n];
            List<double> fi = new List<double>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                        alpha[i, j] = Math.Pow(V, i + j + 3) / (i + j + 3);
                double fiI = A * Math.Pow(V,i+4)/(i+4) + C * Math.Pow(V, i + 3)/(i+3) +
 V* Math.Pow(V, i+2)/(i+2) + B* Math.Pow(V,i+5)/(i+5);//fi i-е 
                fi.Add(fiI);
            }
            Console.WriteLine("\nMatrix alpha:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0,-10} ", Math.Round(alpha[i,j],8));
                Console.WriteLine();
            }
            Console.WriteLine("\nfi:");
            for (int i = 0; i < n; i++)
                Console.Write("{0,-10} ", Math.Round(fi[i],8));
            Console.WriteLine("\n");
            Matrix matr = new Matrix(n, n + 1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if(i != j)
                        matr[i,j] = lamb * alpha[i,j];
                    else
                        matr[i, j] = 1 + lamb * alpha[i, j];
                matr[i,n] = fi[i];
            }
            return matr;
        }
    }
