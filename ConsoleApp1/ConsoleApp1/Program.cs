using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Game
    {
        Field _f;
        int _frute_X;
        int _frute_Y;
        int _snake_X;
        int _snake_Y;
        int _w;
        int _h;

        Random random = new Random();


        public Game(int w, int h)
        {
            _f = new Field();
            _w = w;
            _h = h;
            _frute_X = random.Next(1, w - 2);
            _frute_Y = random.Next(1, h - 2);
            _snake_X = random.Next(1, w - 2);
            _snake_Y = random.Next(1, h - 2);
            _f = new Field();
        }
        public void Draw()
        {
            DrawFruit();
            DrawSnake();
            _f.Draw(_w, _h);
        }
        public void Snakeleft()
        {

            if (_snake_X > 1)
            {
                --_snake_X;
            }

        }
        public void Snakeright()
        {


            if (_snake_X < _w - 2)
            {
                ++_snake_X;
            }

        }
        public void Snakedown()
        {

            if (_snake_Y < _h - 1)
            {
                ++_snake_Y;
            }

        }
        public void Snakeup()
        {


            if (_snake_Y > 1)
            {
                --_snake_Y;
            }
        }
        public void DrawFruit()
        {
            Console.SetCursorPosition(_frute_X, _frute_Y);
            Console.Write("F");
        }
        public void DrawSnake()
        {
            Console.SetCursorPosition(_snake_X, _snake_Y);
            Console.Write("S");
        }

        public bool IsFruitEated()
        {
            return _frute_X == _snake_X && _snake_Y == _frute_Y;

        }
        public void SetNewFriutPosition()
        {
            _frute_X = random.Next(1, _w - 2);
            _frute_Y = random.Next(1, _h - 2);
        }


    }
    class Program
    {



        static void Main(string[] args)
        {
            int score = 0;
            string n = Console.ReadLine();
            string[] mass = n.Split(' ');
            int w = Int32.Parse(mass[0]);
            int h = Int32.Parse(mass[1]);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Game game = new Game(w, h);

            while (true)
            {
                if (game.IsFruitEated())
                {
                    score++;
                    game.SetNewFriutPosition();
                }
                Console.Clear();

                game.Draw();


                Console.SetCursorPosition(0, h + 1);
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey();

                }
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        game.Snakeup();
                        break;
                    case ConsoleKey.DownArrow:
                        game.Snakedown();
                        break;
                    case ConsoleKey.LeftArrow:
                        game.Snakeleft();
                        break;
                    case ConsoleKey.RightArrow:
                        game.Snakeright();
                        break;
                }


                System.Threading.Thread.Sleep(199);
            }

        }
    }
    class Field
    {
        public void Draw(int w, int h)
        {

            for (int i = 0; i < w; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, h);
                Console.Write("#");

            }
            for (int c = 1; c < h; c++)
            {
                Console.SetCursorPosition(0, c);
                Console.Write("#");
                Console.SetCursorPosition(w - 1, c);
                Console.Write("#");
            }

        }
    }
}