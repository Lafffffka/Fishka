using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        int _w; int _h;
        Random r = new Random();
        public Game(int w, int h)
        {
            _w = w;
            _h = h;

        }
       public void DrawFruit()
        {
            int x = r.Next(1, _w - 1);
            int y = r.Next(1, _h);
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }
        public void DrawSneik()
        {

            int x = r.Next(1, _w - 1);
            int y = r.Next(1, _h);
            Console.SetCursorPosition(x, y);
            Console.Write("O");
        }
        public void DrawFeild()
        {

            for (int i = 0; i < _w; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, _h);
                Console.Write("#");
            }

            for (int c = 1; c < _h; c++)
            {
                Console.SetCursorPosition(0, c);
                Console.Write("#");
                Console.SetCursorPosition(_w - 1, c);
                Console.Write("#");
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            string[] mass = n.Split(' ');
            int w = Int32.Parse(mass[0]);
            int h = Int32.Parse(mass[1]);
            Console.SetCursorPosition(0, h + 1);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Game game = new Game(w, h);
            while (true)
            {
                Console.Clear();

                game.DrawFeild();
                game.DrawFruit();
                game.DrawSneik();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.Write("Sneak up");
                        break;
                    case ConsoleKey.DownArrow:

                        Console.Write("Sneak down");
                        break;
                    case ConsoleKey.LeftArrow:

                        Console.Write("Sneak left");
                        break;
                    case ConsoleKey.RightArrow:

                        Console.Write("Sneak right");
                        break;
                    
                }
                key = Console.ReadKey();
            }
        }
    }
}