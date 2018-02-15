using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        Random rand = new Random();

        public FoodCreator(int mapWidht, int mapHeight, char sym)
        {
            MapWidht = mapWidht;
            MapHeight = mapHeight;
            Sym = sym;
        }

        public int MapWidht { get; set; }
        public int MapHeight { get; set; }
        public char Sym { get; set; }

        public Point CreateFood()
        {
            int x = rand.Next(2, MapWidht - 2);
            int y = rand.Next(2, MapHeight - 2);
            return new Point(x, y, Sym);
        }
    }
}
