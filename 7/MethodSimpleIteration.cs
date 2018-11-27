using System;
using System.Collections.Generic;

class MethodSimpleIteration
    {
        Matrix alp; //альфа
        Matrix bet; //бетта
        private void GetAlpha(Matrix A) //Найти альфа
        {
            alp = new Matrix(A.GetN(), A.GetM());
            for (int i = 0; i < alp.GetN(); i++)
                for (int j = 0; j < alp.GetM(); j++)
                    if (i == j) alp[i, j] = 0;
                    else alp[i, j] = -A[i, j] / A[i, i];
            Console.WriteLine("Матрица Alpha:");
            alp.Show();
        }
        private void GetBetta(Matrix A, Matrix B) //Найти бетта
        {
            bet = new Matrix(B.GetN(), B.GetM());
            for (int i = 0; i < B.GetN(); i++)bet[i, 0] = B[i, 0] / A[i, i];
            Console.WriteLine("Вектор Betta:");
            bet.Show();
        }
        private double NormaDivVec(Matrix mat1, Matrix mat2)
	 //Норма разности двух векторов
        {
            double max = Double.MinValue;
            if(mat1.GetM() == 1)
                for (int i = 0; i < mat1.GetN(); i++)
                    if (Math.Abs(mat2[i, 0] - mat1[i,0]) > max)
                        max = Math.Abs(mat2[i, 0] - mat1[i, 0]);                  
            return max;
        }
        public bool CheckAlpha() //Проверяем норму Альфа на соответствие  задачи
        {
            if (alp.Norma() < 1) return true;
            else return false;
        }
        public void Method(Matrix A, Matrix B)
        {
            GetAlpha(A);
            GetBetta(A, B);
            if (CheckAlpha())
            {
                double e = 0.0000001;
                List<Matrix> listX = new List<Matrix>();
                int n = A.GetN();
                listX.Add(new Matrix(n, 1));
                for (int i = 0; i < n; i++)
                    listX[0][i, 0] = 0; //Нулевой вектор x0, все равны 0
                listX.Add(new Matrix(n, 1));
                listX[1] = Matrix.MultiPly(alp, listX[0]);
                listX[1] = Matrix.Addition(listX[1], bet);
                Console.WriteLine("Вектор x1:");
                listX[1].Show();
                int idx = 1;
                while (NormaDivVec(listX[idx], listX[idx-1]) > e )
                {
                    Matrix newX = Matrix.MultiPly(alp, listX[idx]);
                    newX = Matrix.Addition(newX, bet);
                    listX.Add(newX);
                    idx++;
                    Console.WriteLine("Вектор x{0}:", idx);
                    newX.Show();
                }
            }
            else Console.WriteLine("Матрица должна быть диагонализированной (alpha должно быть < 1)");
        }
    }
