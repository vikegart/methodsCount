using System.Collections.Generic;

class MethodGaussa
{
    public void DirectRun(Matrix mat) //Прямой ход
    {
        mat.DirectRunMG();
    }
    public Matrix InverseRun(Matrix expMat) //expMat - обработанная прямым ходом расширенная матрица
    {
        Stack<double> stack = new Stack<double>();
        Matrix matX = new Matrix(expMat.GetN(), 1);
        for (int i = expMat.GetN() - 1; i >= 0; i--)// Ищем X[i]
        {
            matX[i, 0] = 0;
            for (int j = 0; j < expMat.GetN(); j++)
            {
                if (expMat[i, j] != 0)
                    matX[i, 0] += matX[j, 0] * expMat[i, j];
            }
            matX[i, 0] = expMat[i, expMat.GetN()] - matX[i, 0];
        }
        return matX;
    }
}
