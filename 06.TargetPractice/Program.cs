using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            var rows = int.Parse(size[0]);
            var cols = int.Parse(size[1]);

            var wall = new char[rows, cols];

            var snake = Console.ReadLine().ToCharArray();

            var shot = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var impactRow = shot[0];
            var impactCol = shot[1];
            var impactRad = shot[2];

            var isEven = true;
            var counter = 0;

            var A = new Tuple<int, int>(impactRow, impactCol - impactRad);
            var B = new Tuple<int, int>(impactRow - impactRad, impactCol);
            var C = new Tuple<int, int>(impactRow, impactCol + impactRad);
            var D = new Tuple<int, int>(impactRow + impactRad, impactCol);

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
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.Write(wall[i,j]);
            //    }
            //    Console.WriteLine();
            //}

            
            





            Console.WriteLine();

        }
    }
}
