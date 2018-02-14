using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            Point p = new Point(4, 5, '*');
            p.Draw();

            Console.ReadKey();
        }
    }
}
