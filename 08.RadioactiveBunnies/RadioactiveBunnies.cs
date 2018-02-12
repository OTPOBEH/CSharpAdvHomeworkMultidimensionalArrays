using System;
using System.Linq;

class RadioactiveBunnies
{
    static void Main(string[] args)
    {
        var size = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x.Trim())).ToArray();
        var rows = size[0];
        var cols = size[1];

        var lastKnownLoc = new int[2];

        var playerRow = 0;
        var playerCol = 0;
        var playerNotLocated = true;
        var lair = new char[rows][];

        var bunnies = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            lair[i] = Console.ReadLine().ToCharArray();
            if (playerNotLocated)
            {
                if (lair[i].Contains('P'))
                {
                    playerNotLocated = false;
                    playerRow = i;
                    playerCol = Array.IndexOf(lair[i], 'P');
                }
            }
        }

        var commands = Console.ReadLine().ToCharArray();

        var dead = false;
        var won = false;

        foreach (var command in commands)
        {
            lair[playerRow][playerCol] = '.';

            switch (command)
            {
                case 'L':
                    if (playerCol == 0) won = true;
                    else playerCol -= 1;
                    break;
                case 'R':
                    if (playerCol == cols - 1) won = true;
                    else playerCol += 1;
                    break;
                case 'U':
                    if (playerRow == 0) won = true;
                    else playerRow -= 1;
                    break;
                case 'D':
                    if (playerRow == rows - 1) won = true;
                    else playerRow += 1;
                    break;
            }

            if (won)
            {
                lastKnownLoc[0] = playerRow;
                lastKnownLoc[1] = playerCol;
            }
            else if (lair[playerRow][playerCol] == 'B')
            {
                dead = true;
                lastKnownLoc[0] = playerRow;
                lastKnownLoc[1] = playerCol;
            }
            else lair[playerRow][playerCol] = 'P';

            for (int row = 0; row < rows; row++)
            {
                bunnies[row] = Enumerable.Range(0, lair[row].Length).Where(i => lair[row][i] == 'B').ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < bunnies[row].Length; col++)
                {
                    var currentBunnieCol = bunnies[row][col];
                    if (currentBunnieCol > 0) lair[row][currentBunnieCol - 1] = 'B';
                    if (currentBunnieCol < lair[row].Length - 1) lair[row][currentBunnieCol + 1] = 'B';
                    if (row > 0) lair[row - 1][currentBunnieCol] = 'B';
                    if (row < rows - 1) lair[row + 1][currentBunnieCol] = 'B';
                }

                if (won == false && lair[playerRow][playerCol] == 'B')
                {
                    dead = true;
                    lastKnownLoc[0] = playerRow;
                    lastKnownLoc[1] = playerCol;
                }
            }

            if (dead || won) break;
        }

        for (int i = 0; i < rows; i++)
        {
            Console.WriteLine(String.Join("", lair[i]));
        }

        if (won) Console.Write("won: ");
        else Console.Write("dead: ");

        Console.WriteLine(String.Join(" ", lastKnownLoc));
    }
}