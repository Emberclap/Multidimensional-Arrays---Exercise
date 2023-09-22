using System.ComponentModel.Design;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] matrix = new double[rows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            }
            
            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                
                if (matrix[row].Length == matrix[row + 1].Length)
                {

                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = matrix[row][col] * 2;
                        matrix[row + 1][col] = matrix[row+1][col] * 2;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }

                }
                
            }
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "End")
            {
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);
                if (matrix.Length > row && row >= 0 && col >= 0 && col < matrix[row].Length)
                {
                    if (commands[0] == "Add")
                    {
                        matrix[row][col] += value;
                    
                    }
                    else if (commands[0] == "Subtract")
                    {
                        matrix[row][col] -= value;
                    
                    }
                }
                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (double[] row in matrix)
            {
                for (int col = 0; col < row.Length; col++)
                {
                    Console.Write(row[col] + " ");
                }
                Console.WriteLine();
            }
        }
      
    }
}