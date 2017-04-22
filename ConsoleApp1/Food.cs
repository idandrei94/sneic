using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Food
    {
        private int x;
        private int y;

        public int X { get => x; }
        public int Y { get => y; }

        public Food(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
