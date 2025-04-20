using System;

class Program
{

    // нельзя забрать шашку (


    static char[,] board = new char[8, 8];

    static void Main()
    {
        InitBoard();

        while (true)
        {
            DrawBoard();
            Console.Write("Move (e.g., 2 1 3 2): ");
            string input = Console.ReadLine();
            string[] parts = input.Split();

            if (parts.Length != 4)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            int fromY = int.Parse(parts[0]);
            int fromX = int.Parse(parts[1]);
            int toY = int.Parse(parts[2]);
            int toX = int.Parse(parts[3]);

            MovePiece(fromY, fromX, toY, toX);
        }
    }

    static void InitBoard()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if ((x + y) % 2 == 1 && y < 3)
                    board[y, x] = 'O';
                else if ((x + y) % 2 == 1 && y > 4)
                    board[y, x] = 'X';
                else
                    board[y, x] = '.';
            }
        }
    }

    static void DrawBoard()
    {
        Console.Clear();
        Console.WriteLine("   0 1 2 3 4 5 6 7");
        for (int y = 0; y < 8; y++)
        {
            Console.Write(y + "  ");
            for (int x = 0; x < 8; x++)
            {
                Console.Write(board[y, x] + " ");
            }
            Console.WriteLine();
        }
    }

    static void MovePiece(int fromY, int fromX, int toY, int toX)
    {
        if (IsInside(fromY, fromX) && IsInside(toY, toX))
        {
            if (board[fromY, fromX] != '.' && board[toY, toX] == '.')
            {
                board[toY, toX] = board[fromY, fromX];
                board[fromY, fromX] = '.';
            }
            else
            {
                Console.WriteLine("Invalid move.");
            }
        }
        else
        {
            Console.WriteLine("Out of bounds.");
        }
    }

    static bool IsInside(int y, int x)
    {
        return y >= 0 && y < 8 && x >= 0 && x < 8;
    }
}