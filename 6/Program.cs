using System;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matA = new Matrix("A.txt");
            Console.WriteLine("Матрица A:");
            matA.Show();
            Console.WriteLine('\n');
            Matrix matB = new Matrix("B.txt");
            Console.WriteLine("Вектор B:");
            matB.Show();
            MethodSweep mS = new MethodSweep();
            Console.WriteLine("\nПрямая прогонка:");
            mS.DirectSweep(matA, matB);
            Console.WriteLine("\nОбратная прогонка:");
            Matrix matX = mS.InverseSweep(matB.GetN());
        }
    }
}
