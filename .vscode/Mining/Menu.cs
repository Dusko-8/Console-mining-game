using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining
{
    internal class Menu
    {
        public void generateMenu() {
            string[] stringArray = new string[5];
            string Word = "PLAY";

            Console.SetCursorPosition(5, 5);

            UseBigLatters("PLAY");

            Console.ResetColor();
        }
        public void finde_center(string str) { 
        
        }
        public void UseBigLatters(string str) {
            int i = 0;
            while (true)
            {
                

                int cursorX = Console.CursorLeft;
                int cursorY = Console.CursorTop;

                char ch = str[i]; 
                switch (ch)
                {
                    case 'A':
                        Console.Write("╩ ╩");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX-3, cursorY-1);
                        Console.Write("╠═╣");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX-3, cursorY-1);
                        Console.Write("╔═╗");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX+1, cursorY+2);
                        break;
                    case 'P':
                        Console.Write("╩  ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("╠═╝");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("╔═╗");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX + 1, cursorY + 2);
                        break;
                    case 'L':
                        Console.Write("╩══");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("║  ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("║  ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX + 1, cursorY + 2);
                        break;
                    case 'Y':
                        Console.Write(" ╩ ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("╚╦╝");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("║ ║");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX + 1, cursorY + 2);
                        break;

                }

                

                

                i++;
                if (i > str.Length-1)
                {
                    
                    Console.SetCursorPosition(0, 0);
                    break;
                }
            }
            

        }
    }
}
