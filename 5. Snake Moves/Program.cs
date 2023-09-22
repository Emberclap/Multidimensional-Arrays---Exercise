namespace _5._Snake_Moves
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
            var text = Console.ReadLine();
            
            int lastIndex = 0;
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                if (rows == 0 || rows % 2 == 0)
                {
                    for (int cols = 0; cols < matrix.GetLength(1); cols++)
                    {
                        matrix[rows, cols] = text[lastIndex].ToString();
                        lastIndex++;
                        if (lastIndex == text.Length)
                        {
                            lastIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int cols = matrix.GetLength(1) - 1; cols >= 0; cols--)
                    {
                        matrix[rows, cols] = text[lastIndex].ToString();
                        lastIndex++;
                        if (lastIndex == text.Length)
                        {
                            lastIndex = 0;
                        }
                    }
                }
                
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}