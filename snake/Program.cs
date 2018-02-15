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
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_NOZORDER = 0x0004;
        const UInt32 SWP_NOREDRAW = 0x0008;
        const UInt32 SWP_NOACTIVATE = 0x0010;
        const UInt32 SWP_FRAMECHANGED = 0x0020;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        const UInt32 SWP_HIDEWINDOW = 0x0080;
        const UInt32 SWP_NOCOPYBITS = 0x0100;
        const UInt32 SWP_NOOWNERZORDER = 0x0200;
        const UInt32 SWP_NOSENDCHANGING = 0x0400;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static void Main(string[] args)
        {
            IntPtr ConsoleHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            const UInt32 WINDOW_FLAGS = SWP_SHOWWINDOW;

            // Здесь 0,0 - позиция окна (x, y)     700 - ширина       600 - высота
            SetWindowPos(ConsoleHandle, HWND_NOTOPMOST, 300, 0, 700, 700, WINDOW_FLAGS);


            Console.Title = "Snaaaaake by Man_With_A_Big_Letter!";
            Console.CursorVisible = false;
            //Console.SetWindowSize(70, 35);
            //Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.Clear();
            int score = 0;
            Walls walls = new Walls(Console.WindowWidth, Console.WindowHeight);

            walls.Draw();

            int ScrW = Console.WindowWidth; //Размер окна консоли
            int ScrH = Console.WindowHeight - 2;

            Point p = new Point(ScrW / 2, ScrH / 2, ' ');
            Snake snake = new Snake(p, 8, Direction.RIGHT);

            FoodCreator foodCreator = new FoodCreator(ScrW, ScrH, '#');
            Point food = foodCreator.CreateFood();

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            food.Draw();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;


            while (true)
            {
                if (snake.IsHitTail() || walls.IsHit(snake))
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    food.Draw();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    score++;
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
            GameOver(score);
            Console.ReadKey();
        }
        private static void GameOver(int score)
        {
            Console.CursorVisible = true;
            Console.Clear();

            int ScrW = Console.WindowWidth; //Размер окна консоли
            int ScrH = Console.WindowHeight - 2;

            Console.SetCursorPosition(5, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n                                    Game over :(");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n                                 Your score was: {0} !", score);

            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(932, 150);
            Thread.Sleep(150);
            Console.Beep(1047, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(699, 150);
            Thread.Sleep(150);
            Console.Beep(740, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
        }
    }
}
