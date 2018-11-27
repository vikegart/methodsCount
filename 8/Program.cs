using System;
using System.Collections.Generic;

namespace _8
{
    class Program
    {

        static List<double> GetMasYMetodEilera(double y, int n, double h, int V)//Стандартный МЭ
        {
            List<double> listY = new List<double>();
            listY.Add(y); //Добавляем y0 
            double x = 1;//Начальное
            for (int i = 0; i < n - 1; i++)
            {
                double newY = listY[i] + h * (3 * V * x * x + 2 * x + 1 + (V * x * x * x + x * x + x) - listY[i]);
                x += h;
                listY.Add(newY);
            }
            return listY;
        }
        static List<double> GetMasYUpgradeMetodEilera(double y, int n, double h, int V)//Усовершенствованный МЭ
        {
            List<double> listY = new List<double>();
            double x = 1;//Начальное
            listY.Add(y); //Добавляем y0 
            for (int i = 0; i < n * 2 - 1; i++)
            {
                x += h / 2;
                double newYmid = listY[i] + h / 2 * (3 * V * x * x + 2 * x + 1 + (V * x * x * x + x * x + x) - listY[i]);
                listY.Add(newYmid);
            }
            return listY;
        }
        static List<double> GetMasYPredictorCorrector(double y, int n, double h, int V)//Метод предиктора-корректора
        {
            List<double> listY = new List<double>();
            double x = 1;//Начальное
            listY.Add(y); //Добавляем y0 
            for (int i = 0; i < n - 1; i++)
            {
                x += h;
                double newY = listY[i] + h * ((3 * V * x * x + 2 * x + 1 + (V * x * x * x + x * x + x) - listY[i]) + (3 * V * (x + h) * (x + h) + 2 * (x + h) + 1 + (V * (x + h) * (x + h) * (x + h) + (x + h) * (x + h) + (x + h)) - listY[i])) / 2;
                listY.Add(newY);
            }
            return listY;
        }
        static List<double> GetYt(int n, double h, int V)
        {
            double x = 1;
            List<double> listYt = new List<double>();
            Console.WriteLine("x:");
            for (int i = 0; i < n; i++)
            {
                double newY = V * x * x * x + x * x + x;
                listYt.Add(newY);
                Console.Write("{0,-7} ", x);
                x += h;
            }
            return listYt;
        }
        static List<double> GetYtUpgrade(int n, double h, int V) //Заполним y точные
        {
            double x = 1;
            List<double> listYt = new List<double>();
            Console.WriteLine("x:");
            for (int i = 0; i < n * 2; i++)
            {
                double newY = V * x * x * x + x * x + x;
                listYt.Add(newY);
                Console.Write("{0,-7} ", x);
                x += h / 2;
            }
            return listYt;
        }
        static void Main(string[] args)
        {
            const int V = 1;
            double x = 1; //x0
            double h = 0.001; //Шаг
            int n = 10; //Число узлов
            double y = V + 2; //y(x0) = V+2, где x0 = 1
            Console.WriteLine("y'(x) = {0}*x^2 + 2*x + ({0}*x^3 + x^2 + x) - y(x)", 3 * V);
            Console.WriteLine("y({0}) = {1}", x, y);
            Console.WriteLine("h = {0}\n", h);
            //List<double> listYt = GetYt(n, h, V); //Получаем y точные для n членов  для первых двух методов        
            List<double> listYt = GetYtUpgrade(n, h, V); //Получаем y Точные для n * 2 членов для усоверш. Эйлера
            //List<double> listY = GetMasYMetodEilera(y, n, h, V); //Метод эйлера
            //List<double> listY = GetMasYPredictorCorrector(y, n, h, V); //Предиктор-Корректор       
            List<double> listY = GetMasYUpgradeMetodEilera(y, n, h, V); //Усовреш. Метод Эйлера           
            Console.WriteLine("\n\ny:"); //Выводим y полученные
            for (int i = 0; i < listY.Count; i++)
                Console.Write("{0,-7} ", Math.Round(listY[i], 5));
            Console.WriteLine("\n\ny точные: "); //Выводим y точные
            for (int i = 0; i < listYt.Count; i++)
                Console.Write("{0,-7} ", Math.Round(listYt[i], 5));
            Console.WriteLine("\n\ne:"); //Выводим погрешность
            for (int i = 0; i < listY.Count; i++)
            {
                double e = Math.Abs(listYt[i] - listY[i]);
                Console.Write("{0,-7} ", Math.Round(e, 5));
            }
            Console.WriteLine();
        }
    }
}
