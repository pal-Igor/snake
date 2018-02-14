using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        public List<Figure> wallList { get; set; }
        public Walls(int mapWidth, int mapHeight)
        {
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 1, 0, '═');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 1, mapHeight - 2, '═');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 2, 0, '║');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 2, mapWidth - 1, '║');
            wallList = new List<Figure>();
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
