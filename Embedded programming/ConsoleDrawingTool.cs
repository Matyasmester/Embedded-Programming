using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embedded_programming
{
    class ConsoleDrawingTool
    {
        private protected const int ConsoleHeight = 25;
        private protected const int ConsoleWidth = 80;

        private protected ConsoleCharAt[,] buffer = new ConsoleCharAt[ConsoleWidth,ConsoleHeight];

        public ConsoleDrawingTool()
        {
            //Constructor
        }

        public void PutToBuffer(ConsoleCharAt cChar)
        {
            int x = cChar.coord.x;
            int y = cChar.coord.y;
            buffer[x,y] = cChar;
        }

        public void RemoveFromBuffer(ConsoleCharAt cChar)
        {
            int x = cChar.coord.x;
            int y = cChar.coord.y;
            if (buffer[x,y] == cChar)
            {
                buffer[x, y] = null;
            }
            Console.Clear();
        }

        public void Display(ConsoleCharAt[,] cCharArr)
        {
            foreach (ConsoleCharAt cChar in cCharArr)
            {
                if (cChar != null)
                {
                    int x = cChar.coord.x;
                    int y = cChar.coord.y;
                    DrawZeroAt(new Coordinate(x, y));
                }
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
            dwt.RemoveFromBuffer(cChar);
            dwt.PutToBuffer(cChar);
            dwt.Display(buffer);
        }

        public void MoveBy(ConsoleCharAt cChar, int offset, ConsoleDrawingTool dwt)
        {
            int x = cChar.coord.x;
            int y = cChar.coord.y;
            cChar.coord = new Coordinate(x + offset, y);
            dwt.RemoveFromBuffer(cChar);
            dwt.PutToBuffer(cChar);
            dwt.Display(buffer);
        }

        public void MoveInDirection(ConsoleCharAt cChar, char mode, int offset, ConsoleDrawingTool dwt)
        {
            int x = cChar.coord.x;
            int y = cChar.coord.y;
            switch (mode)
            {
                case 'r':
                    MoveBy(cChar, offset, dwt);
                    break;
                case 'l':
                    
                    cChar.coord = new Coordinate(x - offset, y);
                    dwt.RemoveFromBuffer(cChar);
                    dwt.PutToBuffer(cChar);
                    dwt.Display(buffer);
                    break;
                case 'u':
                    cChar.coord = new Coordinate(x, y - offset);
                    dwt.RemoveFromBuffer(cChar);
                    dwt.PutToBuffer(cChar);
                    dwt.Display(buffer);
                    break;
                case 'd':
                    cChar.coord = new Coordinate(x, y + offset);
                    dwt.RemoveFromBuffer(cChar);
                    dwt.PutToBuffer(cChar);
                    dwt.Display(buffer);
                    break;
            }
        }

        public int getConsoleHeight()
        {
            return ConsoleHeight;
        }

        public int getConsoleWidth()
        {
            return ConsoleWidth;
        }

        public ConsoleCharAt[,] getBuffer()
        {
            return buffer;
        }
    }
}
