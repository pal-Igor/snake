using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(120, 30);
            Walls walls = new Walls(120, 30);
            walls.Draw();

            int ScrW = Console.WindowWidth; //Размер окна консоли
            int ScrH = Console.WindowHeight -2;

            Point p = new Point(ScrW / 2, ScrH / 2, 'O');
            Snake snake = new Snake(p, 8, Direction.RIGHT);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                snake.Move();
                Thread.Sleep(100);
            }
        }
    }
}
