using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mining
{
    // 0 - Nothing
    // 1 - Player
    // 2 - Text
    // 3 - Stone
    internal class Map 
    {
        public int rare_materials { get; set; }
        public int deapth_of_soil = 15;
        public int[,] map = new int[Console.WindowWidth, Console.WindowHeight];



        public Map(int rare_materials, Player player) {
            generate_soil(this.deapth_of_soil);
            generate_player(player);


            // Reset the cursor position to avoid overwriting in the same row
            Console.SetCursorPosition(0,0);
            Console.ResetColor(); // Reset colors to default if needed
        }

        public void generate_soil(int deapth_of_soil) {

            int lastRow = Console.WindowHeight - 1;
            int lastCol = Console.WindowWidth - 1;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            
            // Fill the entire row with the character
            for (int j = lastRow; j > lastRow - deapth_of_soil; j--)
            {
                Console.SetCursorPosition(0,j);

                for (int i = 0; i < lastCol; i++)
                {
                   
                    map[i,j] = 3;
                    Console.Write('▓');
                }
            }

            Console.ResetColor();
        }

        public void generate_player(Player player) {
            player.position_x = (Console.WindowWidth - 1) / 2;
            player.position_y = Console.WindowHeight - deapth_of_soil - 1;
            
            map[player.position_x, player.position_y] = 1;
            //map[player.position_x, player.position_y] = 1;

            Console.SetCursorPosition(player.position_x, player.position_y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write('P');
            Console.ResetColor();
        }

    }
}
