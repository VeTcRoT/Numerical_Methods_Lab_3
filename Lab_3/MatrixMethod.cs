using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    internal class MatrixMethod
    {
        public double[,] SystemMatrix { get; set; }
        public double[] FreeMembersColumn { get; set; }
        public MatrixMethod(double[,] systemMatrix, double[] freeMembersColumn)
        {
            SystemMatrix = systemMatrix;
            FreeMembersColumn = freeMembersColumn;
        }
        private double GetDeterminant()
        {
            double det = 0;
            for (int i = 0; i < 3; i++)
            {
                double temp_det = 1;
                for (int j = 0; j < 3; j++)
                {
                    temp_det *= SystemMatrix[(j + i) % 3, j];
                }
                det += temp_det;
            }

            for (int i = 0; i < 3; i++)
            {
                double temp_det = 1;
                for (int j = 0; j < 3; j++)
                {
                    temp_det *= SystemMatrix[(i - j + 3) % 3, j];
                }
                det -= temp_det;
            }

            return det;
        }
        private double[,] GetInversedMatrix()
        {
            double determinant = GetDeterminant();

            double[,] inversedMatrix = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    double[,] temp = new double[2, 2];
                    int row = 0, col = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        if (k != i)
                        {
                            col = 0;
                            for (int l = 0; l < 3; l++)
                            {
                                if (l != j)
                                {
                                    temp[row, col] = SystemMatrix[k, l];
                                    col++;
                                }
                            }
                            row++;
                        }
                    }
                    double temp_det = temp[0, 0] * temp[1, 1] - temp[0, 1] * temp[1, 0];
                    inversedMatrix[j, i] = Math.Pow(-1, i + j) * temp_det / determinant;
                }
            }

            return inversedMatrix;
        }
        public double[] GetResult()
        {
            if (GetDeterminant() == 0)
                return new double[0];

            double[] result = new double[3];

            double[,] inversedMatrix = GetInversedMatrix();

            for (int i = 0; i < 3; i++)
            {
                result[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    result[i] += inversedMatrix[i, j] * FreeMembersColumn[j];
                }
            }

            return result;
        }
    }
}
