using System.ComponentModel;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var col = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);                ;

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = col[cols];
                }
            }
            string[] command = Console.ReadLine()
                .Split();
            while (command[0] != "END")
            {
                if (command[0] != "swap" || command.Length < 5 || command.Length > 5)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    if (IsValid(matrix, command))
                    {
                         int row1 = int.Parse(command[1]);
                         int col1 = int.Parse(command[2]);
                         int row2 = int.Parse(command[3]);
                         int col2 = int.Parse(command[4]);
                         string temp = matrix[row1, col1];
                         matrix[row1, col1] = matrix[row2, col2];
                         matrix[row2, col2] = temp;
                         for (int row = 0; row < matrix.GetLength(0); row++)
                         {
                             for (int col = 0; col < matrix.GetLength(1); col++)
                             {
                                 Console.Write($"{matrix[row, col]} ");
                             }
                             Console.WriteLine();
                         }
                    }
                }
                command = Console.ReadLine()
                .Split();
            }
            
        }

        private static bool IsValid(string[,] matrix, string[] command)
        {
            bool isValid = true;
            for (int i = 1; i < command.Length; i++)
            {
                int currentIndex = int.Parse(command[i]);
                if (currentIndex < 0 || currentIndex > matrix.GetLength(0) || currentIndex > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }
    }
}