namespace Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = MatrixLoader.ReadMatrix("matrix1.txt");
            Matrix matrix2 = MatrixLoader.ReadMatrix("matrix2.txt");
            MatrixLoader.SaveMatrix(Matrix.TransposeMatrix(matrix1), "TransposeMatrix.txt");
            MatrixLoader.SaveMatrix(matrix1 + matrix2, "SumMatrices.txt");
            MatrixLoader.SaveMatrix(matrix1 - matrix2, "DiffMatrices.txt");
        }
    }
}