using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class MatrixLoader
    {
        public static Matrix ReadMatrix(string nameOfFile)
        {
            string[] stringsOfMatrix = File.ReadAllLines(nameOfFile);
            if (stringsOfMatrix.Length == 0)
                throw new Exception("File is empty");

            List<int[]> MatrixList = new List<int[]>();
            int width = stringsOfMatrix[0].Split(" ").Length;

            foreach (string s in stringsOfMatrix)
            {
                List<int> listOfNumsInString = new List<int>();
                s.TrimEnd();
                string[] numsInString = s.Split(" ");
                if(width != numsInString.Length)
                {
                    throw new Exception("Matrices not exist");
                }

                foreach (string number in numsInString)
                {
                    if (int.TryParse(number, out int num))
                    {
                        listOfNumsInString.Add(num);
                    }

                    else
                    {
                        listOfNumsInString.Add(0);
                    }
                }
                MatrixList.Add(listOfNumsInString.ToArray());
            }

            int[][] MatrixArray = MatrixList.ToArray();
            int[,] MatrixArrayDemensionTwo = new int[MatrixArray.Length, MatrixArray[0].Length];

            for (int i = 0; i < MatrixArray.Length; i++)
            {
                for (int j = 0; j < MatrixArray[0].Length; j++)
                {
                    MatrixArrayDemensionTwo[i, j] = MatrixArray[i][j];
                }
            }

            return new Matrix(MatrixArrayDemensionTwo);
        }

        public static void SaveMatrix(Matrix matrix, string nameOfFile)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.Height; i++)
            {
                for (int j = 0; j < matrix.Width; j++)
                {
                    sb.Append($"{matrix[i, j]} ");
                }
                sb.AppendLine();
            }

            File.WriteAllText(nameOfFile, sb.ToString());
        }
    }
}
