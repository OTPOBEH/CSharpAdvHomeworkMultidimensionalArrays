using System;
using System.Linq;

class SquaresInMatrix
{
    static void Main()
    {
        var size = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var rows = size[0];
        var columns = size[1];

        var matrix = new string[rows][];

        for (int i = 0; i < rows; i++)
        {
            matrix[i] = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
        }

        var squares = 0;
        for (int row = 0; row < rows - 1; row++)
        {
            for (int column = 0; column < columns - 1; column++)
            {
                if (matrix[row][column] == matrix[row][column + 1] && matrix[row][column] == matrix[row + 1][column] && matrix[row][column] == matrix[row + 1][column + 1])
                {
                    squares++;
                }
            }
        }

        Console.WriteLine(squares);
    }
}