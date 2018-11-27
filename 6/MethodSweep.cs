using System;
using System.Collections.Generic;

class MethodSweep
    {
        List<double> a;
        List<double> b;
        List<double> c;
        List<double> d;
        List<double> P;
        List<double> Q;
        public void DirectSweep(Matrix matA, Matrix matB)
        {
            //Заполнение списковы a,b,c,d
            a = new List<double>(matA.GetN());
            b = new List<double>(matA.GetN());
            c = new List<double>(matA.GetN());
            d = new List<double>(matA.GetN());
            a.Add(0);
            for (int i = 1; i < matA.GetN(); i++)
                a.Add(matA[i, i - 1]);
            for (int i = 0; i < matA.GetN(); i++)
                b.Add(-matA[i, i]);
            for (int i = 0; i < matA.GetN() - 1; i++)
                c.Add(matA[i, i + 1]);
            c.Add(0);
            for (int i = 0; i < matB.GetN(); i++)
                d.Add(matB[i, 0]);
            Console.WriteLine("a  b  c  d");
            for (int i = 0; i < matA.GetN(); i++)
            {
                Console.Write("{0,-2} {1,-2} {2,-2} {3,-2}", a[i],b[i],c[i],d[i]);
                Console.WriteLine();
            }
            //Заполнение P,Q
            P = new List<double>(matA.GetN() + 1);
            Q = new List<double>(matA.GetN() + 1);
            P.Add(0); //P[0]
            Q.Add(0); //Q[0]
            P.Add(c[0] / b[0]); //P[1]
            Q.Add(-d[0] / b[0]); //Q[1]
            for (int i = 2; i < matA.GetN() + 1; i++)
            {
                P.Add(c[i - 1] / (b[i - 1] - a[i - 1] * P[i - 1]));
                Q.Add((a[i - 1] * Q[i - 1] - d[i - 1])/(b[i-1] - a[i-1]*P[i -1]));
            }
            Console.WriteLine("\nP                    Q");
            for (int i = 0; i < matA.GetN() + 1; i++)
            {
                Console.Write("{0,-20} {1,-20}", P[i], Q[i]);
                Console.WriteLine();
            }
        }
        public Matrix InverseSweep(int n) //Обратная прогонка, возвращаем вектор X
        {
            int length = n + 2;
            Matrix matX = new Matrix(n + 2, 1);
            matX[0, 0] = 0;// x0 = 0                     
            matX[n, 0] = Q[n];
            for (int i = n - 1; i > -1; i--)
            {
                matX[i, 0] = P[i] * matX[i + 1, 0] + Q[i];
            }
            Console.WriteLine("\nВектор X:");
            for (int i = 1; i < length - 1; i++)
               Console.WriteLine(matX[i, 0]);
          return matX;
        }  
   }
