namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var col = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = col[cols];
                }
            }
            int squareStartRow = 0;
            int squareStartCol = 0;
            int maximalSum = 0;
            for (int rows = 0; (rows < matrix.GetLength(0) - 2); rows++)
            {
                for (int cols = 0; (cols < matrix.GetLength(1) - 2); cols++)
                {
                    int sum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows, cols + 2] +
                        matrix[rows + 1, cols] + matrix[rows + 1, cols + 1] + matrix[rows + 1, cols + 2] +
                        matrix[rows + 2, cols] + matrix[rows + 2, cols + 1] + matrix[rows + 2, cols + 2];
                    if (sum > maximalSum)
                    {
                        maximalSum = sum;
                        squareStartRow = rows;
                        squareStartCol = cols;
                    }
                }
            }
            Console.WriteLine($"Sum = {maximalSum}");
            Console.WriteLine($"{matrix[squareStartRow, squareStartCol]} {matrix[squareStartRow, squareStartCol + 1]} {matrix[squareStartRow, squareStartCol + 2]}");
            Console.WriteLine($"{matrix[squareStartRow + 1, squareStartCol]} {matrix[squareStartRow + 1, squareStartCol + 1]} {matrix[squareStartRow + 1, squareStartCol + 2]}");
            Console.WriteLine($"{matrix[squareStartRow + 2, squareStartCol]} {matrix[squareStartRow + 2, squareStartCol + 1]} {matrix[squareStartRow + 2, squareStartCol + 2]}");
            
            //for (int row = squareStartRow; row <= squareStartRow + 2; row++)
            //{
            //    for (int col = squareStartCol; col <= squareStartCol + 2; col++)
            //    {
            //        Console.Write($"{matrix[row, col]} ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}