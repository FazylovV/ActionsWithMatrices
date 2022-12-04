using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix
    {
        public int _Width { get; }
        public int _Height { get; }
        public int[][] _Matrix { get; }
        
        public Matrix(int[][] Matrix)
        {
            this._Matrix = Matrix;
            this._Width = Matrix[0].Length;
            this._Height = Matrix.Length;
        }

        public static Matrix SumMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (!(matrix1._Width == matrix2._Width && matrix1._Height == matrix2._Height)) 
                throw new Exception("Matrices must not have different sizes");

            int[][] newMatrix = new int[matrix1._Height][];
            for(int i = 0; i < matrix1._Height; i++)
            {
                newMatrix[i] = new int[matrix1._Width];
                for(int j = 0; j < matrix2._Width; j++)
                    newMatrix[i][j] = matrix1._Matrix[i][j] + matrix2._Matrix[i][j];
            }

            return new Matrix(newMatrix);
        }

        public static Matrix DiffMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (!(matrix1._Width == matrix2._Width && matrix1._Height == matrix2._Height))
                throw new Exception("Matrices must not have different sizes");

            int[][] newMatrix = new int[matrix1._Height][];
            for(int i = 0; i < matrix1._Height; i++)
            {
                newMatrix[i] = new int[matrix1._Width];
                for(int j = 0; j < matrix2._Width; j++)
                    newMatrix[i][j] = matrix1._Matrix[i][j] - matrix2._Matrix[i][j];
            }

            return new Matrix(newMatrix);
        }

        public static Matrix TransposeMatrix(Matrix matrix)
        {
            int[][] newMatrix = new int[matrix._Width][];
            for (int i = 0; i < matrix._Height; i++)
            {
                for (int j = 0; j < matrix._Width; j++)
                {
                    if (i == 0) newMatrix[j] = new int[matrix._Height];
                    newMatrix[j][i] = matrix._Matrix[i][j];
                }
            }

            return new Matrix(newMatrix);
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            return SumMatrices(matrix1, matrix2);
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            return DiffMatrices(matrix1, matrix2);
        }
    }
}
