/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace TextRPG
{
    class MiniGame
    {
        static string[] maze =
    {
        "■■■■■■■\t esc : 종료",
        "■          ■",
        "■■■■ ■■",
        "■     ■",
        "■■■■ ■■",
        "■    ■ ",
        "■■■■■■■"
    };

        static int playerX = 1; // 시작 위치 X
        static int playerY = 1; // 시작 위치 Y

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                PrintMaze();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // 플레이어 이동
                if (keyInfo.Key == ConsoleKey.UpArrow) Move(-1, 0);
                else if (keyInfo.Key == ConsoleKey.DownArrow) Move(1, 0);
                else if (keyInfo.Key == ConsoleKey.LeftArrow) Move(0, -1);
                else if (keyInfo.Key == ConsoleKey.RightArrow) Move(0, 1);
            }
        }

        static void PrintMaze()
        {
            for (int y = 0; y < maze.Length; y++)
            {
                for (int x = 0; x < maze[y].Length; x++)
                {
                    if (x == playerY && y == playerX)
                    {
                        Console.Write("●"); // 플레이어 위치
                    }
                    else
                    {
                        Console.Write(maze[y][x]);
                    }
                }
                Console.WriteLine();
            }
        }

        static void Move(int deltaY, int deltaX)
        {
            int newX = playerX + deltaY;
            int newY = playerY + deltaX;

            // 벽 체크
            if (maze[newX][newY] != '■')
            {
                playerX = newX;
                playerY = newY;
            }
        }
    }
}
*/