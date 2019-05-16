using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace ConsoleApp33
{
    class Program          
    {
        static void Main(string[] args)
          {
            int x = 0, y = 0,step=2, step1=2;

            GraphicsWindow.Show();
            var p = Shapes.AddRectangle(100, 20);
            Shapes.Move(p, 0, GraphicsWindow.Height - 20);
            var sc = Shapes.AddEllipse(20, 20);
            Timer.Interval=10;
            var mx = GraphicsWindow.MouseX;
            var my = GraphicsWindow.MouseY;
            Timer.Tick += () => {
                
                Shapes.Move(sc, x+=step, y+=step1);
                if(x>=GraphicsWindow.Width-20)
                {
                    step = -2;
                }
                if(x<=0)
                {
                    step = 2;
                }
                if((x>=mx-50||x<=mx+50)&&(y>=my-10))
                {
                    step1 = -2;
                }
                if(y<=0)
                {
                    step1= 2;
                }
            };
            GraphicsWindow.MouseMove += () => { Shapes.Move(p, GraphicsWindow.MouseX-50, GraphicsWindow.Height-20); };
        }
    }
}
