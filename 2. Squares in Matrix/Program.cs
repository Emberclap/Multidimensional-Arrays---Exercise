namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                var col = Console.ReadLine()
                .Split();
                
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = col[cols];
                }
            }
            int squareStartRow = 0;
            int squareStartCol = 0;
            int counter = 0;
            for (int rows = 0; (rows < matrix.GetLength(0) - 1); rows++)
            {
                for (int cols = 0; (cols < matrix.GetLength(1) - 1); cols++)
                {
                    if (matrix[rows, cols] == matrix[rows, cols + 1] && 
                        matrix[rows + 1, cols] == matrix[rows + 1, cols + 1] &&
                        matrix[rows, cols] == matrix[rows + 1, cols])
                    {
                        squareStartRow = rows;
                        squareStartCol = cols;
                        counter++;
                    }
                }
            }
            
                Console.WriteLine($"{counter}");
            
            
        }
    }
}