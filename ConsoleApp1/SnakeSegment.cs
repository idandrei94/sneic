using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SnakeSegment
    {
        private int x;
        private int y;

        public int X
        {
            get => x;
            set => y = value;
        }

        public int Y
        {
            get => y;
            set => y = value;
        }

        public SnakeSegment(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
