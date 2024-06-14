using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mining
{
    internal class GameLogic
    {
        public int  minimal_x = 0;
        public int  minimal_y = 0;
        public int  maximal_x = Console.WindowWidth-1;
        public int  maximal_y = Console.WindowHeight-1;
        public int  [,]? map;


        public void check_for_movement(Player player) {

            int old_X = player.position_x; 
            int old_Y = player.position_y;

            update_movement(player);

            draw_player(player,old_X,old_Y);
            
        }

        public void update_movement(Player player) {
                
             
             var keyInfo = Console.ReadKey(intercept: true);

            switch (keyInfo.Key)
             {
                case ConsoleKey.UpArrow:
                    if (player.position_y <= minimal_y )
                    {
                        break;
                    }
                    else
                    {
                        if (map[player.position_x, player.position_y - 1] == 0) {
                            player.position_y -= 1;
                        }
                        
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (player.position_y >= maximal_y)
                    {
                        break;
                    }
                    else
                    {
                        if (map[player.position_x, player.position_y + 1] == 0)
                        {
                            player.position_y += 1;
                        }
                        
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (player.position_x <= minimal_x)
                    {
                        break;
                    }
                    else
                    {
                        if (map[player.position_x - 1, player.position_y] == 0)
                        {
                            player.position_x -= 1;
                        }
                        
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (player.position_x >= maximal_x)
                    {
                        break;
                    }
                    else
                    {
                        if (map[player.position_x + 1, player.position_y] == 0)
                        {
                            player.position_x += 1;
                        }
                        
                    }
                    break;
                case ConsoleKey.Spacebar:
                    break;
                default:
                    break;
            }

        }

        public void draw_player(Player player, int old_X, int old_Y) {

            Console.ResetColor();
            Console.SetCursorPosition(old_X, old_Y);
            map[old_X, old_Y] = 0;
            Console.Write(' ');


            Console.SetCursorPosition(player.position_x, player.position_y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            map[player.position_x, player.position_y] = 1;
            Console.Write('P');
            Console.ResetColor();
            Console.SetCursorPosition(0,0);

        }
    }
}
