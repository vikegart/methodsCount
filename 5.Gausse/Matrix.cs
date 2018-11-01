using System;
using System.IO;

public class Matrix
{
    double[,] mat;
    int n; //Число строк
    int m; //Число столбцов
    public Matrix(int n, int m)
    {
        this.n = n;
        this.m = m;
        mat = new double[n, m];
    }
    public double this[int i, int j]
    {
        get
        {
            return mat[i, j];
        }
        set
        {
            mat[i, j] = value;
        }
    }
    public Matrix(string nameOfFile)
    {
        StreamReader fileIn = new StreamReader(nameOfFile);
        string line1 = fileIn.ReadLine();
        string[] mas1 = line1.Split(' ');
        n = int.Parse(mas1[0]);
        m = int.Parse(mas1[1]);
        mat = new double[n, m];
        for (int i = 0; i < n; i++)
        {
            string line;
            string[] mas;
            line = fileIn.ReadLine();
            Console.WriteLine(line);
            mas = line.Split(' ');
            for (int j = 0; j < m; j++)
                mat[i, j] = int.Parse(mas[j]);
        }

        if (mat[0, 0] == 0)
        {
            double max = mat[0, 0];
            int rowWithMax = 0;
            for (int i = 0; i < n; i++)
            {
                if (max < mat[i, 0])
                {
                    max = mat[i, 0];
                    rowWithMax = i;
                }
            }
            for (int j = 0; j < m; j++)
            {
                double buff = mat[rowWithMax, j];
                mat [rowWithMax, j] = mat [0, j];
                mat [0, j] = buff;
            }
        }

    }
    public void Show()
    {
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                Console.Write("{0,-5} ", Math.Round(mat[i, j], 3));
        Console.WriteLine();
        Console.WriteLine();
    }
    public void Div(int indx, double x)
    {
        for (int j = 0; j < m; j++)
            mat[indx, j] /= x;
    }
    public void Sub(int indx1, int indx2, double x) //indx1 - откуда вычитаем, indx2 - что вычитаем, x - на сколько умножаем
    {
        for (int j = 0; j < m; j++)
            mat[indx1, j] = mat[indx1, j] - x * mat[indx2, j];
    }
    public void DirectRunMG() //Прямой ход Метода Гауса
    {
        for (int i = 0; i < n - 1; i++)
        {
            Div(i, mat[i, i]);
            Sub(i + 1, i, mat[i + 1, i]);
        }
        Div(n - 1, mat[n - 1, n - 1]);
    }

    public int GetN()
    {
        return n;
    }
    public int GetM()
    {
        return m;
    }
    public Matrix ExpMatrix(Matrix b)
    {
        int n = this.GetN();
        Matrix expMat = new Matrix(n, n + 1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                expMat[i, j] = mat[i, j];
        }
        for (int i = 0; i < n; i++)
            expMat[i, n] = b[i, 0];
        return expMat;
    }

}