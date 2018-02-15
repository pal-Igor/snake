using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        public List<Point> pList { get; set; }
        public virtual void Draw()
        {
            foreach (var p in pList)
            {
                p.Draw();
            }
        }
        public bool IsHit(Snake snake)
        {
            foreach (var p in pList)
            {
                if (snake.IsHit(p))
                    return true;
            }
            return false;
        }
    }
}
