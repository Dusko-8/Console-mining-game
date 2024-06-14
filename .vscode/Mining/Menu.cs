using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining
{
    internal class Menu
    {
        public int things_in_center = 2;
        //    __  __  _____  _   _  ______  _____           _____            __  __  ______ 
        //   |  \/  ||_   _|| \ | ||  ____||  __ \         / ____|    /\    |  \/  ||  ____|
        //   | \  / |  | |  |  \| || |__   | |__) |       | |  __    /  \   | \  / || |__
        //   | |\/| |  | |  | . ` ||  __|  |  _  /        | | |_ |  / /\ \  | |\/| ||  __|  
        //   | |  | | _| |_ | |\  || |____ | | \ \        | |__| | / ____ \ | |  | || |____
        //   |_|  |_||_____||_| \_||______||_|  \_\        \_____|/_/    \_\|_|  |_||______|


        public void generateMenu() {
            string[] stringArray = new string[2];
            stringArray[0] = "PLAY";
            stringArray[1] = "EXIT";
            int[,] centers = new int[stringArray.Length, 2];
            create_title();

            Console.SetCursorPosition(5, 5);
            centers = finde_center(stringArray);

            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.SetCursorPosition(centers[i,0], centers[i, 1]);
                UseBigLatters(stringArray[i]);
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            HandleMenuSelection(keyInfo);

            Console.Clear();
            Console.ResetColor();
        }

        static void HandleMenuSelection(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            
        }

        public void create_title() {
            int startingX = 20;
            int startingY = 0;
            string[] title = new string[6];
            title[0] = " __  __  _____  _   _  ______  _____           _____            __  __  ______ ";
            title[1] = "|  \\/  ||_   _|| \\ | ||  ____||  __ \\         / ____|    /\\    |  \\/  ||  ____|";
            title[2] = "| \\  / |  | |  |  \\| || |__   | |__) |       | |  __    /  \\   | \\  / || |__   ";
            title[3] = "| |\\/| |  | |  | . ` ||  __|  |  _  /        | | |_ |  / /\\ \\  | |\\/| ||  __|  ";
            title[4] = "| |  | | _| |_ | |\\  || |____ | | \\ \\        | |__| | / ____ \\ | |  | || |____ ";
            title[5] = "|_|  |_||_____||_| \\_||______||_|  \\_\\        \\_____|/_/    \\_\\|_|  |_||______|";


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;

            for (int i = 0; i < 6;i++) {
                Console.SetCursorPosition(startingX , startingY);
                Console.Write(title[i]);
                startingY++;
            }
            Console.ResetColor();
            return;

        }
        public int[,] finde_center(string[] str)
        {
            // Get the last row and column based on the console window size
            int lastRow = Console.WindowHeight - 1;
            int lastCol = Console.WindowWidth - 1;
            int lngth = str.Length;

            // Initialize a 2D array to hold the center positions
            int[,] ret = new int[lngth, 2];

            for (int i = 0; i < lngth; i++)
            {
                // Calculate the middle column for each string
                int midCol = (lastCol - (str[i].Length*3)) / 2;

                // Calculate the middle row, evenly spacing each string
                int midRow = (lastRow / 2) - (lngth / 2) + i*3;

                // Assign the calculated positions to the array
                ret[i, 0] = midCol;
                ret[i, 1] = midRow;
            }

            return ret;
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
                    case 'E':
                        Console.Write("╚══");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("╠══");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("╔══");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX + 1, cursorY + 2);
                        break;
                    case 'X':
                        Console.Write("╔╩╗");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("╚╦╝");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX + 1, cursorY + 1);
                        break;
                    case 'I':
                        Console.Write(" ╩ ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write(" ║ ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write(" ▀ ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX + 1, cursorY + 2);
                        break;
                    case 'T':
                        Console.Write(" ╩ ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write(" ║ ");
                        cursorX = Console.CursorLeft;
                        cursorY = Console.CursorTop;
                        Console.SetCursorPosition(cursorX - 3, cursorY - 1);
                        Console.Write("═╦═");
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
