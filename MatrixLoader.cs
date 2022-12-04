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
                    throw new Exception("Matrices not exist");

                foreach(string number in numsInString)
                {
                    if (int.TryParse(number, out int num)) listOfNumsInString.Add(num);
                    else listOfNumsInString.Add(0);
                }
                MatrixList.Add(listOfNumsInString.ToArray());
            }

            int[][] MatrixArray = MatrixList.ToArray();
            return new Matrix(MatrixArray);
        }

        public static void SaveMatrix(Matrix matrix, string nameOfFile)
        {
            int[][] numsInMatrix = matrix._Matrix;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numsInMatrix.Length; i++)
            {
                for (int j = 0; j < numsInMatrix[i].Length; j++)
                {
                    sb.Append($"{matrix._Matrix[i][j]} ");
                }
                sb.AppendLine();
            }

            File.WriteAllText(nameOfFile, sb.ToString());
        }
    }
}
