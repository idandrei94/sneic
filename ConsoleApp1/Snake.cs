using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Snake
    {
        private Grid grid;
        private char draw = 'X';
        List<SnakeSegment> snake = new List<SnakeSegment>();

        public SnakeSegment this[int i]
        {
            get => snake[i];
        }

        public int Length { get => snake.Count; }

        public Snake(int x, int y, Grid grid)
        {
            this.grid = grid;
            snake.Add(new SnakeSegment(x, y));
            Console.SetCursorPosition(grid.Left + x, grid.Top + y);
            Console.Write(draw);
        }

        public void move(int x, int y)
        {
            grow(x, y);
            Console.SetCursorPosition(snake[snake.Count - 1].X, snake[snake.Count - 1].Y);
            Console.Write(" ");
            snake.RemoveAt(snake.Count - 1);
        }

        public void grow(int x, int y)
        {
            Console.SetCursorPosition(grid.Left + x, grid.Top + y);
            Console.Write(draw);
            SnakeSegment newHead = new SnakeSegment(x, y);
            List<SnakeSegment> newSnake = new List<SnakeSegment> { newHead };
            foreach (var el in snake)
            {
                newSnake.Add(el);
            }
            snake = newSnake;
        }

        public bool contains(int x, int y)
        {
            foreach(var seg in snake)
            {
                if (seg.X == x && seg.Y == y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
