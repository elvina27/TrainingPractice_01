using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEP_Task_05
{
    internal class Program
    {
        static bool want;
        static void Labirint(int[,] labris)
        {

            for (int i = 0; i < labris.GetLength(0); i++)
            {
                string line = "";
                for (int j = 0; j < labris.GetLength(1); j++)
                {
                    switch (labris[i, j])
                    {
                        case 1:
                            line += "█";
                            break;

                        case 3:
                            line += "♥";
                            break;

                        case 5:
                            line += "☺";
                            break;

                        case 7:
                            line += want ? "*": " ";
                            break;

                        default:
                            line += " ";
                            break;
                    }
                }
                Console.SetCursorPosition(0, i);
                Console.Write(line);
            }
        }

        static void Shag(int[,] labris, int x, int y, bool shag, ref int lives)
        {
            if (shag)
            {
                Labirint(labris);

                if (labris[y, x] == 5) 
                {
                    lives--; 
                    Console.SetCursorPosition(42, 10);
                    Console.Write("Остаток жизненных сил:");
                    Console.SetCursorPosition(48, 12);
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(new string('♥', lives));
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(new string('_', 10 - lives));
                    Console.Write("]");
                }
                else 
                {
                    Console.SetCursorPosition(42, 10);
                    Console.Write("Остаток жизненных сил:");
                    Console.SetCursorPosition(48, 12);
                    Console.Write("[");
                    Console.Write(new string('♥', lives));
                    Console.Write(new string('_', 10 - lives));
                    Console.Write("]");
                }

                Labirint(labris);
                Console.SetCursorPosition(x, y);
                Console.Write("☻");
                Console.SetCursorPosition(37, 6);
                Console.Write("Управляйте человечком с помощью: ");
                Console.SetCursorPosition(30, 7);
                Console.Write("w - Вверх   s - Вниз   d - Вправо    a - Влево");
                Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);
            }
        }
        static void Exit(int[,] labris, int x, int y, ref bool GameOver)
        {
            Random rand = new Random();
            if (labris[y, x] == 3)
            {
                GameOver = true;
                Console.SetCursorPosition(43, 15);
                Console.Write("Вы вышли из лабиринта!");
                Console.SetCursorPosition(48, 16);
                Console.Write("Поздравляю!");
                Console.SetCursorPosition(0, 20);
            }
        }

        static void SpawnEnemies(int[,] labris, ref int createdEnemies)
        {
            Random rand = new Random();
            
            int enemySymbol = 5; 

            int x = rand.Next(1, labris.GetLength(1)); 
            int y = rand.Next(1, labris.GetLength(0)); 

            if ((labris[y, x] == 0 || labris[y, x] == 7) && createdEnemies < 5) 
            {
                labris[y, x] = enemySymbol;
                createdEnemies++;
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            string[] lines = File.ReadAllLines("labirint2.txt");
            int[,] labris = new int[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    labris[i, j] = int.Parse(lines[i][j].ToString());
                }
            }           

            Labirint(labris);
            Console.SetCursorPosition(37, 3);
            Console.Write("Добро пожаловать в игру Лабиринт!");

            Console.SetCursorPosition(38, 6);
            Console.Write("Управляйте человечком с помощью: ");

            Console.SetCursorPosition(30, 7);
            Console.Write("w - Вверх   s - Вниз   d - Вправо    a - Влево");

            Console.SetCursorPosition(42, 10);
            Console.Write("Остаток жизненных сил:");

            var x = 1;
            var y = 1;
            Console.SetCursorPosition(x, y);
            Console.Write("☻");
            var GameOver = false;
            int createdEnemies = 0;
            int lives = 10;
            while (!GameOver)
            {

                SpawnEnemies(labris, ref createdEnemies);


                switch (Console.ReadKey().KeyChar)
                {
                    case ('w'):
                        if (labris[--y, x] == 1)
                        {
                            ++y;
                            Shag(labris, x, y, false, ref lives);
                        }
                        else
                        {
                            Shag(labris, x, y, true, ref lives);
                            Exit(labris, x, y, ref GameOver);
                        }
                        break;

                    case ('s'):
                        if (labris[++y, x] == 1)
                        {
                            --y;
                            Shag(labris, x, y, false, ref lives);
                        }
                        else
                        {
                            Shag(labris, x, y, true, ref lives);
                            Exit(labris, x, y, ref GameOver);
                        }
                        break;

                    case ('a'):
                        if (labris[y, --x] == 1)
                        {
                            ++x;
                            Shag(labris, x, y, false, ref lives);
                        }
                        else
                        {
                            Shag(labris, x, y, true, ref lives);
                            Exit(labris, x, y, ref GameOver);
                        }
                        break;

                    case ('d'):
                        if (labris[y, ++x] == 1)
                        {
                            --x;
                            Shag(labris, x, y, false, ref lives);
                        }
                        else
                        {
                            Shag(labris, x, y, true, ref lives);
                            Exit(labris, x, y, ref GameOver);
                        }
                        break;

                    case ('m'):
                        want = !want;
                        Labirint(labris);
                        Console.SetCursorPosition(x, y);
                        Console.Write("☻");
                        Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2); 
                        break;

                    default:
                        Labirint(labris);
                        Console.SetCursorPosition(x, y);
                        Console.Write("☻");
                        Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 2);

                        break;
                }
            }

                Console.ReadKey();
        }
    }
}
