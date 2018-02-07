using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPractice
{
    class Program
    {
        static void Main()
        {
            var size = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();


            var snake = Console.ReadLine().ToCharArray();

            var shot = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var radius = shot[2];
            var impactRow = shot[0] + radius;
            var impactCol = shot[1] + radius;

            var rows = int.Parse(size[0]) + 2 * radius;
            var cols = int.Parse(size[1]) + 2 * radius;

            var wall = new char[rows, cols];

            var isEven = true;
            var counter = 0;

            for (int i = rows - 1 - radius; i >= radius; i--)
            {
                if (isEven)
                {
                    for (int j = cols - 1 - radius; j >= 0 + radius; j--)
                    {
                        wall[i, j] = snake[counter % snake.Length];
                        counter++;
                    }
                    isEven = false;
                }
                else
                {
                    for (int j = 0 + radius; j < cols - radius; j++)
                    {
                        wall[i, j] = snake[counter % snake.Length];
                        counter++;
                    }
                    isEven = true;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(wall[i, j]);
                }
                Console.WriteLine();
            }

            var startCol = impactCol;
            var elements = 0;

            for (int row = impactRow - radius; row <= impactRow; row++)
            {
                for (var col = startCol; col <= startCol + elements; col++)
                {
                    wall[row, col] = wall[0, 0];
                }
                elements += 2;
                startCol--;
            }
            elements = 2 * radius + 1;
            startCol++;

            for (int row = impactRow + 1; row <= impactRow + radius; row++)
            {

                startCol++;
                elements -= 2;

                for (var col = startCol; col < startCol + elements; col++)
                {

                    wall[row, col] = wall[0, 0];

                }
            }

            Console.WriteLine();

            for (int col = radius; col < cols - radius; col++)
            {
                for (int row = rows - radius; row >= radius; row--)
                {

                    if (wall[row, col] == wall[0, 0])
                    {





                    }



                }




            }
        }
    }
