using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Grid
    {
        private int x;
        private int y;
        private int left;
        private int top;

        public int Left { get => left; }
        public int Top { get => top; }

        public int X { get => x; }
        public int Y { get => y; }
        public Grid(int x, int y, int left, int top)
        {
            this.x = x;
            this.y = y;
            this.left = left;
            this.top = top;
        }

        public void drawEdge()
        {
            Console.SetCursorPosition(left, top);
            Console.Write(" ");
            for (int i = 0; i < x; i++)
            {
                Console.Write("_");
            }
            for (int i = 0; i < y; i++)
            {
                Console.SetCursorPosition(left, Console.CursorTop + 1);
                Console.Write("|");
                for (int j = 0; j < x; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
            }
            Console.SetCursorPosition(left, Console.CursorTop+1);
            Console.Write("|");
            for (int i=0; i<x; i++)
            {
                Console.Write("_");
            }
            Console.Write("|");
        }
    }
}
