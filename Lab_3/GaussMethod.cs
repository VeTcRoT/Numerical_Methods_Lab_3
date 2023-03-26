using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class GaussMethod
    {
        public double[,] SystemMatrix { get; set; }
        public double[] FreeMembersColumn { get; set; }
        private int n = 3;
        public GaussMethod(double[,] systemMatrix, double[] freeMembersColumn)
        {
            SystemMatrix = systemMatrix;
            FreeMembersColumn = freeMembersColumn;
        }
        public double[] GetResult()
        {
            double[,] systemMatrixClone = (double[,])SystemMatrix.Clone();
            double[] freeMembersColumnClone = (double[])FreeMembersColumn.Clone();

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    double factor = systemMatrixClone[i, k] / systemMatrixClone[k, k];
                    for (int j = k; j < n; j++)
                    {
                        systemMatrixClone[i, j] -= factor * systemMatrixClone[k, j];
                    }
                    freeMembersColumnClone[i] -= factor * freeMembersColumnClone[k];
                }
            }

            double[] x = new double[n];
            x[n - 1] = freeMembersColumnClone[n - 1] / systemMatrixClone[n - 1, n - 1];
            for (int k = n - 2; k >= 0; k--)
            {
                double sum = freeMembersColumnClone[k];
                for (int j = k + 1; j < n; j++)
                {
                    sum -= systemMatrixClone[k, j] * x[j];
                }
                x[k] = sum / systemMatrixClone[k, k];
            }

            return x;
        }
    }
}
