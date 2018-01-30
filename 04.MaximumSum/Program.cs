using System;
using System.Linq;

class MaximalSum
{
    static void Main()
    {
        var size = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var rows = size[0];
        var columns = size[1];

        var matrix = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            matrix[i] = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        var maxSum = int.MinValue;

        var firstRowResult = string.Empty;
        var secondRowResult = string.Empty;
        var thirdRowResult = string.Empty;

        for (int row = 0; row < rows - 2; row++)
        {
            for (int column = 0; column < columns - 2; column++)
            {
                var firstRowSum = matrix[row][column] + matrix[row][column + 1] + matrix[row][column + 2];
                var secondRowSum = matrix[row + 1][column] + matrix[row + 1][column + 1] + matrix[row + 1][column + 2];
                var thirdRowSum = matrix[row + 2][column] + matrix[row + 2][column + 1] + matrix[row + 2][column + 2];
                var currentSum = firstRowSum + secondRowSum + thirdRowSum;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    firstRowResult = matrix[row][column] + " " + matrix[row][column + 1] + " " + matrix[row][column + 2];
                    secondRowResult = matrix[row + 1][column] + " " + matrix[row + 1][column + 1] + " " + matrix[row + 1][column + 2];
                    thirdRowResult = matrix[row + 2][column] + " " + matrix[row + 2][column + 1] + " " + matrix[row + 2][column + 2];
                }

            }
        }
        Console.WriteLine($"Sum = {maxSum}");

        Console.WriteLine(firstRowResult);
        Console.WriteLine(secondRowResult);
        Console.WriteLine(thirdRowResult);
    }
}