using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RubiksMatrix
{
    static void Main()
    {
        var size = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        var commands = int.Parse(Console.ReadLine());

        var rows = size[0];
        var columns = size[1];
        var current = 0;
        var matrix = new int[rows, columns];
        var originalMatrix = new int[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                matrix[row, col] = ++current;
                originalMatrix[row, col] = current;
            }
        }

        for (int i = 0; i < commands; i++)
        {
            var command = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var position = int.Parse(command[0]);
            var direction = command[1];
            var turns = int.Parse(command[2]);

            if (direction == "left" || direction == "right")
            {
                TurnRow(matrix, position, turns, direction);
            }
            else
            {
                TurnCol(matrix, position, turns, direction);
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                if (matrix[i,j] != originalMatrix[i,j])
                {

                    var coordinates = FindCoordinates(matrix, matrix[i, j]);
                    var row = coordinates.Item1;
                    var col = coordinates.Item2;



                }




            }
        }


    }
    static void TurnRow(int[,] matrix, int position, int turns, string direction)
    {
        var index = 0;

        switch (direction)
        {
            case "right":
                index = (0 + turns) % matrix.GetLength(1);
                break;

            case "left":
                index = (matrix.GetLength(1) - 1) - turns % matrix.GetLength(1);
                break;
        }

        var newRow = new int[matrix.GetLength(1)];

        //Получаване на новия ред на матрицата:
        const int intSize = 4; //на толковa байта отговаря един int
        Buffer.BlockCopy(matrix, (position * newRow.Length + index) * intSize, newRow, 0, (newRow.Length - index) * intSize);
        Buffer.BlockCopy(matrix, position * newRow.Length * intSize, newRow, (index + 1) * intSize, index * intSize);

        //Копиране на новия ред обратно в матрицата:
        Buffer.BlockCopy(newRow, 0, matrix, position * newRow.Length * intSize, newRow.Length * intSize);
    }

    static void TurnCol(int[,] matrix, int position, int turns, string direction)
    {
        var index = 0;

        switch (direction)
        {
            case "down":
                index = (0 + turns) % matrix.GetLength(1);
                break;

            case "up":
                index = (matrix.GetLength(1) - 1) - turns % matrix.GetLength(1);
                break;
        }

        var oldCol = new int[matrix.GetLength(0)];
        var newCol = new int[matrix.GetLength(0)];

        for (int i = 0; i < oldCol.Length; i++)
        {
            oldCol[i] = matrix[i, position];
        }
        const int intSize = 4; //на толковa байта отговаря един int
        Buffer.BlockCopy(oldCol, 0, newCol, (index + 1) * intSize, index * intSize);
        Buffer.BlockCopy(oldCol, (index) * intSize, newCol, 0, (newCol.Length - index) * intSize);

        for (int i = 0; i < newCol.Length; i++)
        {
            matrix[i, position] = newCol[i];
        }
    }

    static Tuple<int, int , bool> FindCoordinates(int[,] matrix, int quiery)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {

                if (matrix[i, j] != originalMatrix[i, j])
                {




                }




            }
        }







    }



}