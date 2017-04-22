using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class GameManager
    {
        private enum directions { UP, DOWN, RIGHT, LEFT };
        private directions dir = directions.RIGHT;
        private bool running = true;
        private bool move = false;

        private directions Dir { get => dir; set => dir = value; }
        public bool Running { get => running; set => running = value; }

        public void play()
        {
            Console.CursorVisible = false;
            Food food = null;
            Random rnd = new Random();
            int score = 0;
            Grid grid = new Grid(100, 25, 0, 0);
            grid.drawEdge();
            Snake snake = new Snake(50, 12, grid);
            Task.Run(() => {
                while (Running)
                {
                    var key = Console.ReadKey(true);
                    while (!move) ;
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (Dir != directions.DOWN)
                            {
                                Dir = directions.UP;
                                move = false;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (Dir != directions.UP)
                            {
                                Dir = directions.DOWN;
                                move = false;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (Dir != directions.RIGHT)
                            {
                                Dir = directions.LEFT;
                                move = false;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (Dir != directions.LEFT)
                            {
                                Dir = directions.RIGHT;
                                move = false;
                            }
                            break;
                    }
                }
            });
            while (Running)
            {
                if (food == null)
                {
                    int x, y;
                    do
                    {
                        x = rnd.Next(grid.Left + 1, grid.Left + grid.X);
                        y = rnd.Next(grid.Top + 1, grid.Top + grid.Y);
                    } while (snake.contains(x, y));
                    food = new Food(x, y);
                }else
                {
                    Console.SetCursorPosition(food.X + grid.Left, food.Y + grid.Top);
                    Console.Write("O");
                }
                switch (Dir)
                {
                    case directions.UP:
                        if (snake[0].Y <= grid.Top+1 || snake.contains(snake[0].X, snake[0].Y - 1) )
                        {
                            Running = false;
                        }
                        move = true;
                        if (food != null && food.X == snake[0].X && food.Y == snake[0].Y - 1)
                        {
                            snake.grow(snake[0].X, snake[0].Y - 1);
                            food = null;
                            score++;
                        }
                        else
                        {
                            snake.move(snake[0].X, snake[0].Y - 1);
                        }
                        break;
                    case directions.DOWN:
                        if (snake[0].Y >= grid.Top + grid.Y || snake.contains(snake[0].X, snake[0].Y + 1))
                        {
                            Running = false;
                        }
                        move = true;
                        if (food != null && food.X == snake[0].X && food.Y == snake[0].Y + 1)
                        {
                            snake.grow(snake[0].X, snake[0].Y + 1);
                            food = null;
                            score++;
                        }
                        else
                        {
                            snake.move(snake[0].X, snake[0].Y + 1);
                        }
                        break;
                    case directions.LEFT:
                        if (snake[0].X <= grid.Left+1 || snake.contains(snake[0].X - 1, snake[0].Y))
                        {
                            Running = false;
                        }
                        move = true;
                        if (food != null && food.X == snake[0].X - 1 && food.Y == snake[0].Y)
                        {
                            snake.grow(snake[0].X - 1, snake[0].Y);
                            food = null;
                            score++;
                        }
                        else
                        {
                            snake.move(snake[0].X - 1, snake[0].Y);
                        }
                        break;
                    case directions.RIGHT:
                        if (snake[0].X >= grid.Left + grid.X || snake.contains(snake[0].X + 1, snake[0].Y))
                        {
                            Running = false;
                        }
                        move = true;
                        if (food!= null && food.X == snake[0].X + 1 && food.Y == snake[0].Y)
                        {
                            snake.grow(snake[0].X + 1, snake[0].Y);
                            score++;
                            food = null;
                        }
                        else
                        {
                            snake.move(snake[0].X + 1, snake[0].Y);
                        }
                        break;
                }
                Console.SetCursorPosition(0, grid.Top + grid.Y+2);
                Console.WriteLine("Score: {0}", score);
                Thread.Sleep(60);
            }
            Console.SetCursorPosition(0, grid.Top + grid.Y + 2);
            Console.WriteLine("##### Game Over! Score: {0}", score);
            Console.WriteLine("Press any key to exit.");
        }
    }
}