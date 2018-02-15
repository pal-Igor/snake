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
            Console.BackgroundColor = ConsoleColor.Blue;
            Draw(pList);
            Console.BackgroundColor = ConsoleColor.Black;
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
        private void Draw(Point p, ConsoleColor cc, ConsoleColor cc1)
        {
            Console.BackgroundColor = cc;
            p.Draw();
            Console.BackgroundColor = cc1;
        }
        private void Draw(Point p, ConsoleColor cc, ConsoleColor cc1, ConsoleColor fc)
        {
            Console.ForegroundColor = fc;
            Console.BackgroundColor = cc;
            p.Draw();
            Console.BackgroundColor = cc1;
        }
        public void Move()
        {
            Tail = pList.First();
            pList.Remove(Tail);

            Point head = GetNextPoint();
            pList.Add(head);
            head.Sym = '~';
            Tail.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            head.Draw();
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public Point GetNextPoint()
        {
            Point headPoint = pList[pList.Count - 1];
            Point vertPoint = pList[pList.Count - 2];
            Point tailPoint = pList[0];
            if (Direction == Direction.DOWN || Direction == Direction.UP)
            {
                vertPoint.Sym = ' ';
                Draw(vertPoint, ConsoleColor.Blue, ConsoleColor.Black);
            }
            else if (Direction == Direction.LEFT || Direction == Direction.RIGHT)
            {
                vertPoint.Sym = ' ';
                Draw(vertPoint, ConsoleColor.Blue, ConsoleColor.Black);
            }

            if (Direction == Direction.LEFT)
            {
                tailPoint.Sym = '>';
                Draw(tailPoint, ConsoleColor.DarkBlue, ConsoleColor.Black, ConsoleColor.White);
            }
            else if (Direction == Direction.RIGHT)
            {
                tailPoint.Sym = '<';
                Draw(tailPoint, ConsoleColor.DarkBlue, ConsoleColor.Black, ConsoleColor.White);
            }
            else if (Direction == Direction.DOWN)
            {
                tailPoint.Sym = '^';
                Draw(tailPoint, ConsoleColor.DarkBlue, ConsoleColor.Black, ConsoleColor.White);
            }
            else
            {
                tailPoint.Sym = 'V';
                Draw(tailPoint, ConsoleColor.DarkBlue, ConsoleColor.Black, ConsoleColor.White);
            }

            headPoint.Sym = ':';
            Draw(headPoint, ConsoleColor.DarkBlue, ConsoleColor.Black, ConsoleColor.White);

            Point tongue = pList.Last();
            Point nextPoint = new Point(tongue);
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
        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Sym = head.Sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count -2; i++)
            {
                if (head.IsHit(pList[i]))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
