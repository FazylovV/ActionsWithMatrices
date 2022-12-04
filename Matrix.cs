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
        private int[,] _Matrix;

        public Matrix(int[,] Matrix)
        {
            this._Width = Matrix.GetLength(1);
            this._Height = Matrix.GetLength(0);
            this._Matrix = new int[_Height, _Width];
            for (int i = 0; i < _Height; i++)
                for (int j = 0; j < _Width; j++)
                    this._Matrix[i,j] = Matrix[i, j];
        }

        public int this[int i, int j]
        {
            get => _Matrix[i, j];
        }

        public static Matrix SumMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (!(matrix1._Width == matrix2._Width && matrix1._Height == matrix2._Height)) 
                throw new Exception("Matrices must not have different sizes");

            int[,] newMatrix = new int[matrix1._Height, matrix1._Width];
            for(int i = 0; i < matrix1._Height; i++)
                for(int j = 0; j < matrix2._Width; j++)
                    newMatrix[i, j] = matrix1[i, j] + matrix2[i, j];

            return new Matrix(newMatrix);
        }

        public static Matrix DiffMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (!(matrix1._Width == matrix2._Width && matrix1._Height == matrix2._Height))
                throw new Exception("Matrices must not have different sizes");

            int[,] newMatrix = new int[matrix1._Height, matrix1._Width];
            for(int i = 0; i < matrix1._Height; i++)
                for(int j = 0; j < matrix2._Width; j++)
                    newMatrix[i, j] = matrix1[i, j] - matrix2[i, j];

            return new Matrix(newMatrix);
        }

        public static Matrix TransposeMatrix(Matrix matrix)
        {
            int[,] newMatrix = new int[matrix._Width, matrix._Height];
            for (int i = 0; i < matrix._Height; i++)
                for (int j = 0; j < matrix._Width; j++)
                    newMatrix[j, i] = matrix[i, j];

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
