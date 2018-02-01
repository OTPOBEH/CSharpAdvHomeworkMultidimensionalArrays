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

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                matrix[row, col] = ++current;
            }
        }

        for (int i = 0; i < commands; i++)
        {
            var command = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var position = int.Parse(command[0]);
            var direction = command[1];
            var times = int.Parse(command[2]);

            if (direction == "left" || direction == "right")
            {
                RowTurning(matrix, position, times, direction);
            }
            else
            {
                ColTurning(matrix, position, times, direction);
            }




        }




    }
    static void RowTurning(int[,] matrix, int position, int times, string direction)
    {
        var newRow = new int[matrix.GetLength(1)];
        
        switch (direction)
        {
            case "right":                           // (index + turns) % length

               


                break;
            case "left":                            // index - Length % turns



                break;


        }
    }

    static void ColTurning(int[,] matrix, int position, int times, string direction)
    {



    }

}