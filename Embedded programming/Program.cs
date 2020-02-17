using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Embedded_programming
{
    class Program
    {
        static void Main()
        {
            ConsoleDrawingTool drawTool = new ConsoleDrawingTool();
            Coordinate coord = new Coordinate(40, 15);
            ConsoleCharAt cChar = new ConsoleCharAt('0', coord);
            Console.SetWindowSize(80, 25);
            drawTool.DrawChar(cChar);
            for (int i = 0; i < 10; i++)
            {
                drawTool.MoveBy(cChar, 2, drawTool);
                Thread.Sleep(1000);
            }
            Console.Read();
        }
    }
}
