namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {

                    var col = Console.ReadLine()
                    .Split().Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows,cols] = col[cols];
                }
            }
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                firstDiagonalSum += matrix[i,i];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                secondDiagonalSum += matrix[i,matrix.GetLength(1)-i-1];
            }
            
            Console.WriteLine($"{Math.Abs(firstDiagonalSum - secondDiagonalSum)}");
        }
    }
}