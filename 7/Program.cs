using System;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matA = new Matrix("A.txt");
            Console.WriteLine("Матрица A:");
            matA.Show();
            Matrix matB = new Matrix("B.txt");
            Console.WriteLine("Вектор B:");
            matB.Show();
            MethodSimpleIteration mSI = new MethodSimpleIteration();
            mSI.Method(matA, matB);

        }
    }
}
