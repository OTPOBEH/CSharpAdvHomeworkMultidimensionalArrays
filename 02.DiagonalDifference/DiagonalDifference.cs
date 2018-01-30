using System;
using System.Linq;

class DiagonalDifference
{
    static void Main()
    {
        var size = int.Parse(Console.ReadLine());

        var matrix = new int[size][];

        for (int i = 0; i < size; i++)
        {
            matrix[i] = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        var sum1 = 0;
        var sum2 = 0;

        for (int i = 0; i < size; i++)
        {
            sum1 += matrix[i][i];
            sum2 += matrix[i][size - 1 - i];
        }

        var resut = Math.Abs(sum1 - sum2);
        Console.WriteLine(resut);
    }
}