using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab_3
{
    public class CramerMethod
    {
        public double[,] SystemMatrix { get; set; }
        public double[] FreeMembersColumn { get; set; }
        public CramerMethod(double[,] systemMatrix, double[] freeMembersColumn)
        {
            SystemMatrix = systemMatrix;
            FreeMembersColumn = freeMembersColumn;
        }
        private double GetDeterminant(double[,] matrix)
        {
            double result = 0;

            for (int i = 0; i < 3; i++)
                result += matrix[0, i] * matrix[1, i + 1] * matrix[2, i + 2];


            for (int i = 0; i < 3; i++)
                result -= matrix[0, i + 2] * matrix[1, i + 1] * matrix[2, i];


            return result;
        }

        private double[,] GetBuildedMatrix(int iteration = -1)
        {
            double[,] matrix = new double[3, 5];

            for (int i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                int pos = 0;
                for (int j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    if (j == iteration)
                    {
                        matrix[i, j] = FreeMembersColumn[i];
                        continue;
                    }
                        
                    if (j == matrix.GetUpperBound(1) - 1)
                        matrix[i, j] = matrix[i, pos++];

                    else if (j > matrix.GetUpperBound(1) - 1)
                        matrix[i, j] = matrix[i, pos];

                    else
                        matrix[i, j] = SystemMatrix[i, j];

                }
            }

            return matrix;
        }

        public double[] GetResult()
        {
            if (GetDeterminant(GetBuildedMatrix()) == 0)
                return new double[0];

            double[] result = new double[3];

            for (int i = 0; i < 3; i++)
                result[i] = GetDeterminant(GetBuildedMatrix(i)) / GetDeterminant(GetBuildedMatrix());

            return result;
        }
    }
}
