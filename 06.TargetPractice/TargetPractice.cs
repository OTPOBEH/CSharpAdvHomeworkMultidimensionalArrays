using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main()
        {
            var size    = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            var rows    = int.Parse(size[0]);
            var cols    = int.Parse(size[1]);

            var wall    = new char[rows, cols];
            var snake   = Console.ReadLine()?.ToCharArray();
            var isEven  = true;
            var counter = 0;

            for (int i = rows - 1; i >= 0; i--)
            {
                if (isEven)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        wall[i, j] = snake[counter % snake.Length];
                        counter++;
                    }
                    isEven = false;
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                    {
                        wall[i, j] = snake[counter % snake.Length];
                        counter++;
                    }
                    isEven = true;
                }
            }

            var shot      = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var impactRow = shot[0];
            var impactCol = shot[1];
            var radius    = shot[2];

            var topRow    = impactRow - radius;
            var bottomRow = impactRow + radius;
            var startCol  = impactCol;
            counter = 0;

            for (int row = topRow; row <= impactRow; row++)
            {
                for (int col = startCol; row >= 0 && col <= startCol + counter; col++)
                {
                    if (col < 0 || col >= wall.GetLength(1)) continue;
                    wall[row, col] = ' ';
                }
                startCol--;
                counter += 2;
            }

            counter = 2 * radius - 1;
            startCol += 2;

            for (int row = impactRow + 1; row < wall.GetLength(0) && row <= bottomRow; row++)
            {
                for (int col = startCol; row < wall.GetLength(1) && col < startCol + counter; col++)
                {
                    if (col < 0 || col >= wall.GetLength(1)) continue;
                    wall[row, col] = ' ';
                }
                startCol++;
                counter -= 2;
            }

            var printArray = new List<char>[cols];

            for (int col = 0; col < cols; col++)
            {
                printArray[col] = new List<char>();
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (wall[row, col] != ' ')
                    {
                        printArray[col].Add(wall[row, col]);
                    }
                }

                while (printArray[col].Count != cols)
                {
                    printArray[col].Add(' ');
                }
            }

            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(printArray[col].ElementAt(row));
                }
                Console.WriteLine();
            }
        }
    }
}