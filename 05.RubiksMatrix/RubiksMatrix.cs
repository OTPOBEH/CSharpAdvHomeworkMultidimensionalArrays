using System;
using System.Linq;

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

                if (matrix[i, j] == originalMatrix[i, j])
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    var result = SwapSolver(i, j, matrix, originalMatrix);
                    Console.WriteLine(result);
                }
        }
    }
    static void TurnRow(int[,] matrix, int position, int turns, string direction)
    {
        // Хоризонтално завъртане.
        // Пример:
        // начален масив: 1 2 3 4 5
        // Команда: Две премествания на дясно.
        // Ако срежем масива преди индекс 3 (1 2 3 | 4 5) и разменим местата на двете парчета ще получим:
        // резултат масив: 4 5 1 2 3

        //Сега изчисляваме къде трябва да срежем масива, за да разменим местата на двете парчета:

        var index = 0;

        switch (direction)
        {
            case "right":
                index = matrix.GetLength(1) - turns % matrix.GetLength(1); // търсеният индекс при команда "дясно"
                break;

            case "left":
                index = turns % matrix.GetLength(1);// търсеният индекс при команда "ляво"
                break;
        }

        //Получаване новия ред на матрицата чрез копиране на матрица байт по байт(всеки int е 4 байта) с Buffer.BlockCopy:
        var newRow = new int[matrix.GetLength(1)];
        const int intSize = 4;
        Buffer.BlockCopy(matrix, (position * newRow.Length + index) * intSize, newRow, 0, (newRow.Length - index) * intSize); // Вторият отрязък отива отпред.
        Buffer.BlockCopy(matrix, position * newRow.Length * intSize, newRow, (newRow.Length - index) * intSize, index * intSize); // Първият отрязък отива отзад.

        //Копиране на новия ред обратно в матрицата:
        Buffer.BlockCopy(newRow, 0, matrix, position * newRow.Length * intSize, newRow.Length * intSize);
    }

    static void TurnCol(int[,] matrix, int position, int turns, string direction)
    {
        //За обяснение на алгоритъма виж метод TurnRow по-горе...
        var index = 0;

        switch (direction)
        {
            case "down":
                index = matrix.GetLength(0) - turns % matrix.GetLength(0);
                break;

            case "up":
                index = turns % matrix.GetLength(0);
                break;
        }

        var oldCol = new int[matrix.GetLength(0)]; // Създаваме временен масив със състоянието на колоната преди промените

        for (int i = 0; i < oldCol.Length; i++)
        {
            oldCol[i] = matrix[i, position];
        }

        //Получаване новия ред на матрицата:
        var newCol = new int[matrix.GetLength(0)];
        const int intSize = 4; //на толковa байта отговаря един int
        Buffer.BlockCopy(oldCol, (index) * intSize, newCol, 0, (newCol.Length - index) * intSize); //това е копиране байт по байт
        Buffer.BlockCopy(oldCol, 0, newCol, (newCol.Length - index) * intSize, index * intSize);

        //Копиране на новия ред обратно в матрицата:
        for (int i = 0; i < newCol.Length; i++)
        {
            matrix[i, position] = newCol[i];
        }
    }

    static string SwapSolver(int i, int j, int[,] matrix, int[,] originalMatrix)
    {
        var result = string.Empty;
        var firstPass = true;
        for (int k = i; k < matrix.GetLength(0); k++)
        {
            var m = 0;
            if (firstPass) m = j;   //При първа итерация започваме долния цикъл директно от елемента, който проверяваме, защото считаме, че предишните елементи са подредени.

            for ( ;m < matrix.GetLength(1); m++)
            {
                if (originalMatrix[i, j] == matrix[k, m])
                {
                    var temp = matrix[i, j];
                    matrix[i, j] = originalMatrix[i, j];
                    matrix[k, m] = temp;
                    result = $"Swap ({i}, {j}) with ({k}, {m})";
                    break;
                }
            }
            firstPass = false;
        }
        return result;
    }
}