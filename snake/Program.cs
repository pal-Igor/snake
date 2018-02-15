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
            Console.Title = "Snaaaaake!";
            Console.CursorVisible = false;
            Console.SetWindowSize(70, 35);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.Clear();
            Walls walls = new Walls(Console.WindowWidth, Console.WindowHeight);

            walls.Draw();

            int ScrW = Console.WindowWidth; //Размер окна консоли
            int ScrH = Console.WindowHeight -2;

            Point p = new Point(ScrW / 2, ScrH / 2, ' ');
            Snake snake = new Snake(p, 8, Direction.RIGHT);

            FoodCreator foodCreator = new FoodCreator(ScrW, ScrH, '#');
            Point food = foodCreator.CreateFood();

            Console.BackgroundColor = ConsoleColor.Red;
            food.Draw();
            Console.BackgroundColor = ConsoleColor.Black;
            

            while (true)
            {
                if (snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}
