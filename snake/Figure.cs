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
    }
}
