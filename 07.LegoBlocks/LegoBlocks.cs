using System;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        var rows = int.Parse(Console.ReadLine());

        var firstMatrix = new int[rows][];
        var secondMatrix = new int[rows][];

        var cellsTotal = 0;

        for (int row = 0; row < rows; row++)
        {
            firstMatrix[row] = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .ToArray();
        }

        for (int row = 0; row < rows; row++)
        {
            secondMatrix[row] = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x.Trim()))
                .ToArray();
            Array.Reverse(secondMatrix[row]);
        }

        var matchPositive = true;
        var totalColumns = firstMatrix[0].Length + secondMatrix[0].Length;
        cellsTotal = totalColumns;

        for (int row = 1; row < rows; row++)
        {
            var totalColumnsCurrent = firstMatrix[row].Length + secondMatrix[row].Length;
            cellsTotal += totalColumnsCurrent;
            if (totalColumnsCurrent != totalColumns) matchPositive = false;
        }

        if (matchPositive)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("[" + string.Join(", ", firstMatrix[i]) + ", " + string.Join(", ", secondMatrix[i]) + "]");
            }
        }
        else
        {
            Console.WriteLine($"The total number of cells is: {cellsTotal}");
        }
    }
}