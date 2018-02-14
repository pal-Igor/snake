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
            HorizontalLine upLine = new HorizontalLine(0, 119, 0, '═');
            HorizontalLine downLine = new HorizontalLine(0, 119, 28, '═');
            VerticalLine leftLine = new VerticalLine(0, 28, 0, '║');
            VerticalLine rightLine = new VerticalLine(0, 28, 119, '║');
            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            Point p = new Point(4, 5, '*');
            p.Draw();

            Console.ReadKey();
        }
    }
}
