using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public Snake(Point tail, int lenght, Direction direction)
        {
            Tail = tail;
            Lenght = lenght;
            Direction = direction;
            pList = new List<Point>();
            for (int i = 0; i < Lenght; i++)
            {
                Point p = new Point(Tail);
                p.Move(i, Direction);
                pList.Add(p);
            }
            Draw(pList);
        }

        public void Move()
        {
            Tail = pList.First();
            pList.Remove(Tail);
            
            Point head = GetNextPoint();
            pList.Add(head);

            Tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, Direction);
            return nextPoint;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                Direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                Direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                Direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                Direction = Direction.UP;
        }

        public Point Tail { get; set; }
        public int Lenght { get; set; }
        public Direction Direction { get; set; }
        public List<Point> pList { get; set; }
        public void Draw(List<Point> pList)
        {
            foreach (var p in pList)
            {
                p.Draw();
            }
        }
    }
}
