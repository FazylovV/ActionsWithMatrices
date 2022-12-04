using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix
    {
        public int Width { get; }
        public int Height { get; }
        private int[,] _Matrix;

        public Matrix(int[,] Matrix)
        {
            this.Width = Matrix.GetLength(1);
            this.Height = Matrix.GetLength(0);
            this._Matrix = new int[Height, Width];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    this._Matrix[i,j] = Matrix[i, j];
        }

        public int this[int i, int j]
        {
            get => _Matrix[i, j];
        }

        public static Matrix SumMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (!(matrix1.Width == matrix2.Width && matrix1.Height == matrix2.Height)) 
                throw new Exception("Matrices must not have different sizes");

            int[,] newMatrix = new int[matrix1.Height, matrix1.Width];
            for(int i = 0; i < matrix1.Height; i++)
                for(int j = 0; j < matrix2.Width; j++)
                    newMatrix[i, j] = matrix1[i, j] + matrix2[i, j];

            return new Matrix(newMatrix);
        }

        public static Matrix DiffMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (!(matrix1.Width == matrix2.Width && matrix1.Height == matrix2.Height))
                throw new Exception("Matrices must not have different sizes");

            int[,] newMatrix = new int[matrix1.Height, matrix1.Width];
            for(int i = 0; i < matrix1.Height; i++)
                for(int j = 0; j < matrix2.Width; j++)
                    newMatrix[i, j] = matrix1[i, j] - matrix2[i, j];

            return new Matrix(newMatrix);
        }

        public static Matrix TransposeMatrix(Matrix matrix)
        {
            int[,] newMatrix = new int[matrix.Width, matrix.Height];
            for (int i = 0; i < matrix.Height; i++)
                for (int j = 0; j < matrix.Width; j++)
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
