using System;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matA = new Matrix("A.txt");
            Console.WriteLine("Матрица A:");
            matA.Show();
            Matrix matB = new Matrix("B.txt");
            Console.WriteLine("Матрица B:");
            matB.Show();
            Console.WriteLine();
            Console.WriteLine("Расширенная матрица");
            Matrix expMat = matA.ExpMatrix(matB);
            expMat.Show();
            MethodGaussa methodGaussa = new MethodGaussa();
            Console.WriteLine("Прямой ход метода Гаусса:");
            methodGaussa.DirectRun(expMat);
            expMat.Show();
            Console.WriteLine("\n Обратный ход метода Гаусса:");
            Matrix matX = methodGaussa.InverseRun(expMat);
            Console.WriteLine("Матрица X:");
            matX.Show();
            Console.WriteLine();
        }
    }

}
