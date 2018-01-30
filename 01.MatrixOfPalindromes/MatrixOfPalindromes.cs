using System;
using System.Linq;

class MatrixOfPalindromes
{
    static void Main()
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        var size = Console.ReadLine()?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var rows = size[0];
        var columns = size[1];
        var matrix = new string[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                matrix[row, col] = new string(alphabet[row],1) + new string(alphabet[row + col],1) + new string(alphabet[row],1);

                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}