namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int coals = 0;
            int rowIndex = 0;
            int colIndex = 0;
            for (int rows = 0; rows < fieldSize; rows++)
            {
                char[] col = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int cols = 0; cols < field.GetLength(1); cols++)
                {
                    field[rows, cols] = col[cols];
                    if (col[cols] == 'c')
                    {
                        coals++;
                    }
                    else if (col[cols] == 's')
                    {
                        rowIndex = rows;
                        colIndex = cols;
                    }
                }
            }
            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up":
                        if (IsValid(rowIndex - 1, colIndex, field))
                        {
                            rowIndex = rowIndex - 1;
                            colIndex = colIndex;
                            if (CoalChecker(rowIndex, colIndex, field, coals))
                            {
                                coals--;
                            }
                        }
                        break;
                    case "down":
                        if (IsValid(rowIndex + 1, colIndex, field))
                        {
                            rowIndex = rowIndex + 1;
                            colIndex = colIndex;
                            if (CoalChecker(rowIndex, colIndex, field, coals))
                            {
                                coals--;
                            }
                        }
                        break;
                    case "left":
                        if (IsValid(rowIndex, colIndex - 1, field))
                        {
                            rowIndex = rowIndex;
                            colIndex = colIndex - 1;
                            if (CoalChecker(rowIndex, colIndex, field, coals))
                            {
                                coals--;
                            }
                        }
                        break;
                    case "right":
                        if (IsValid(rowIndex, colIndex + 1, field))
                        {
                            rowIndex = rowIndex;
                            colIndex = colIndex + 1;
                            if (CoalChecker(rowIndex, colIndex, field, coals))
                            {
                                coals--;
                            }
                        }
                        break;
                }

                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                }
                if (field[rowIndex, colIndex] == 'e')
                {
                    Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                    return;
                }
            }
            if (coals > 0)
            {
                Console.WriteLine($"{coals} coals left. ({rowIndex}, {colIndex})");
            }
            static bool CoalChecker(int rowIndex, int colIndex, char[,] field, int coals)
            {
                if (field[rowIndex, colIndex] == 'c')
                {
                    field[rowIndex, colIndex] = '*';
                    return true;
                }
                return false;
            }
            static bool IsValid(int rowIndex, int colIndex, char[,] field)
            {
                if (rowIndex >= 0 && rowIndex < field.GetLength(0) && colIndex >= 0 && colIndex < field.GetLength(1))
                {
                    return true;
                }
                else { return false; }
            }
        }
    }
}