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
        static void Main(string[] args)
        {
            GraphicsWindow.Show();


            Primitive[] enemies = new Primitive[10];
            var p = Shapes.AddRectangle(100, 20);
            Shapes.Move(p, 0, GraphicsWindow.Height - 20);
            GraphicsWindow.MouseMove += () => { Shapes.Move(p, GraphicsWindow.MouseX - 50, GraphicsWindow.Height - 20); };

            GraphicsWindow.BrushColor ="Yellow";
            var c = Shapes.AddEllipse(20, 20);
           
            int x = 0;
            int y = 0;
            int stepx = 2;
            int stepy = 2;

            int widthOfRect = GraphicsWindow.Width / 10;
            int numOfRects = 0;


            GraphicsWindow.BrushColor = "Green";
            GraphicsWindow.PenColor = "Grey";
            for (int i=0;i<GraphicsWindow.Width&&numOfRects<10;i+=widthOfRect)
            {

                var rec = Shapes.AddRectangle(widthOfRect, 20);
                Shapes.Move(rec, i, 0);
                enemies[numOfRects] = rec;
                numOfRects++;
            }


            Mouse.HideCursor();

            Timer.Interval = 10;
            Timer.Tick += () => {
                Shapes.Move(c, x += stepx, y += stepy);

                for(int i=0; i<numOfRects; i++)
                {
                    if((x>=Shapes.GetLeft(enemies[numOfRects])&&x<= Shapes.GetLeft(enemies[numOfRects])+widthOfRect)&&y<= Shapes.GetTop(enemies[numOfRects])+20)
                    {
                        stepy = -stepy;
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