using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;



namespace ConsoleApp2
{
    class Program
    {
        struct Enemy
        {
            public Primitive _p;

            public int _counter;
        }
        static void Main(string[] args)
        {
            GraphicsWindow.Show();


            Enemy[] enemies = new Enemy[10];

            var p = Shapes.AddRectangle(100, 20);
            Shapes.Move(p, 0, GraphicsWindow.Height - 20);
            GraphicsWindow.MouseMove += () => { Shapes.Move(p, GraphicsWindow.MouseX - 50, GraphicsWindow.Height - 20); };

            GraphicsWindow.BrushColor ="Yellow";
            var c = Shapes.AddEllipse(20, 20);
           
            int x = GraphicsWindow.Width / 2;
            int y = GraphicsWindow.Height/2;
            int stepx = 2;
            int stepy = 3;

            int widthOfRect = GraphicsWindow.Width / 10;
            int numOfRects = 0;


            GraphicsWindow.BrushColor = "Green";
            GraphicsWindow.PenColor = "Grey";
            for (int i=0;i<GraphicsWindow.Width&&numOfRects<10;i+=widthOfRect)
            {

                var rec = Shapes.AddRectangle(widthOfRect-10, 20);
                Shapes.SetOpacity(rec, 100);
                Shapes.Move(rec, i+5, 40);
                enemies[numOfRects]._p = rec;
                enemies[numOfRects]._counter = 0;
                numOfRects++;
            }


            Mouse.HideCursor();

            Timer.Interval = 10;
            Timer.Tick += () => {
                Shapes.Move(c, x += stepx, y += stepy);

                for (int i = 0; i < numOfRects; i++)
                {
                    if (enemies[i]._counter<3)
                    {
                        if (x + 10 >= Shapes.GetLeft(enemies[i]._p) + 5
                            && x + 10 <= Shapes.GetLeft(enemies[i]._p) + widthOfRect - 5
                            && y <= Shapes.GetTop(enemies[i]._p) + 20)
                        {
                            stepy = -stepy;

                            Shapes.HideShape(enemies[i]._p);
                            enemies[i]._counter++;
                            Shapes.SetOpacity(enemies[i]._p, (3-enemies[i]._counter) * 100.0 / 3);
                            break;
                        }

                    }
                }
                

                if (x >= GraphicsWindow.Width - 20)
                {
                    stepx = -stepx;

                }
                if (x <= 0)
                {
                    stepx = -stepx;

                }
                if (y <= 0)
                {
                    stepy = -stepy;

                }
                var mx = GraphicsWindow.MouseX;
                var my = GraphicsWindow.Height - 40;


                if ((x >= mx - 50 && x <= mx + 50) && (y >= my))
                {
                    stepy = -stepy;
                }
                if (y > GraphicsWindow.Height)
                {
                    ///Sound.PlayAndWait("C:\\Users\\StartQ\\Desktop\\smALL\\ConsoleApp2\\sound.mp3");

                    Microsoft.SmallBasic.Library.Program.End();

                }
            };

        }
    }
}