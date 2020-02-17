using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embedded_programming
{
    class ConsoleDrawingTool
    {
        public ConsoleDrawingTool()
        {
            //Constructor
        }

        public void DrawChar(ConsoleCharAt cChar)
        {
            switch (cChar.symbol)                   //This will be useful when we'll have more symbols
            {
                case '0':
                    DrawZeroAt(cChar.coord);
                    break;
                default:
                    return;
            }
        }

        private void DrawZeroAt(Coordinate coord)
        {
            int x = coord.x;
            int y = coord.y;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("▄▄▄▄▄▄▄" + "\n");
            for (int i = 1; i < 5; i++)
            {
                Console.SetCursorPosition(x - 1, y - i);
                Console.WriteLine("█       █" + "\n");
            }
            Console.SetCursorPosition(x, y - 5);
            Console.WriteLine("▀▀▀▀▀▀▀" + "\n");
        }

        public void Move(ConsoleCharAt cChar, ConsoleDrawingTool dwt)
        {
            Coordinate charCoord = new Coordinate(cChar.coord.x, cChar.coord.y);
            int x = charCoord.x;
            int y = charCoord.y;
            cChar.coord = new Coordinate(x + 1, y);
            Console.Clear();
            dwt.DrawChar(cChar);
        }

        public void MoveBy(ConsoleCharAt cChar, int offset, ConsoleDrawingTool dwt)
        {
            Coordinate charCoord = new Coordinate(cChar.coord.x, cChar.coord.y);
            int x = charCoord.x;
            int y = charCoord.y;
            cChar.coord = new Coordinate(x + offset, y);
            Console.Clear();
            dwt.DrawChar(cChar);
        }
    }
}
