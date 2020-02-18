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
            ConsoleCharAt cChar1 = new ConsoleCharAt('0', new Coordinate(20, 15));
            ConsoleCharAt cChar2 = new ConsoleCharAt('0', new Coordinate(40, 15));
            ConsoleCharAt cChar3 = new ConsoleCharAt('0', new Coordinate(60, 15));
            Console.SetWindowSize(drawTool.getConsoleWidth(), drawTool.getConsoleHeight());
            drawTool.PutToBuffer(cChar1);
            drawTool.PutToBuffer(cChar2);
            drawTool.PutToBuffer(cChar3);
            drawTool.Display(drawTool.getBuffer());
            for (int i = 0; i < 10; i++)
            {
                drawTool.MoveInDirection(cChar1, 'd', 2, drawTool);
                drawTool.MoveInDirection(cChar2, 'u', 1, drawTool);
                Thread.Sleep(1000);
            }
            Console.Read();
        }
    }
}
