using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                if (y == 0 && x == yUp)
                {
                    sym = '╔';
                    Point p = new Point(x, y, sym);
                    pList.Add(p);
                }
                else if (y == 0 && x != 0)
                {
                    sym = '╗';
                    Point p = new Point(x, y, sym);
                    pList.Add(p);
                }
                else if (y == yDown && x != 0)
                {
                    sym = '╝';
                    Point p = new Point(x, y, sym);
                    pList.Add(p);
                }
                else if (x == 0 && y == yDown)
                {
                    sym = '╚';
                    Point p = new Point(x, y, sym);
                    pList.Add(p);
                }
                else
                {
                    sym = '║';
                    Point p = new Point(x, y, sym);
                    pList.Add(p);
                }
            }
        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            base.Draw();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
