using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Numerics;

namespace Mining
{
    // 0 - Nothing
    // 1 - Player
    // 2 - Text
    // 3 - Stone
    // 4 - Iron
    // 5 - Coal
    // 6 - Diamond
    // 7 - Ruby
    internal class Map 
    {
        public int rare_materials { get; set; }
        public int deapth_of_soil = 15;
        public int[,] map = new int[Console.WindowWidth, Console.WindowHeight];



        public Map(int rare_materials, Player player) {
            generate_soil();


            //iron 5* Yellow
            generate_ore(6,ConsoleColor.Yellow, 4);

            //Coal 4* Black
            generate_ore(7, ConsoleColor.Black, 5);

            //Diamond 2* Blue
            generate_ore(3, ConsoleColor.Blue, 6);

            //Ruby   1*  Red
            generate_ore(1, ConsoleColor.Red, 7);

            generate_player(player);
            


            // Reset the cursor position to avoid overwriting in the same row
            Console.SetCursorPosition(0,0);
            Console.ResetColor(); // Reset colors to default if needed
        }

        public void generate_soil() {

            int lastRow = Console.WindowHeight - 1;
            int lastCol = Console.WindowWidth - 1;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            
            // Fill the entire row with the character
            for (int j = lastRow; j > lastRow - this.deapth_of_soil; j--)
            {
                Console.SetCursorPosition(0,j);
                Thread.Sleep(50);

                for (int i = 0; i < lastCol; i++)
                {
                    map[i,j] = 3;
                    Console.Write('▓');
                }
            }

            Console.ResetColor();
        }

        public void render_soil() {
            int lastRow = Console.WindowHeight - 1;
            int lastCol = Console.WindowWidth - 1;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            // Fill the entire row with the character
            for (int j = lastRow; j > lastRow - this.deapth_of_soil; j--)
            {
                Console.SetCursorPosition(0, j);
                Thread.Sleep(50);
                
                for (int i = 0; i < lastCol; i++)
                {
                    
                    
                }
            }

            Console.ResetColor();
        }

        public void render_soil_row(int playerY)
        {
            int lastRow = Console.WindowHeight - 1;
            int lastCol = Console.WindowWidth - 1;

            

            for (int i = 0; i < lastCol; i++)
            {
                if (map[i, playerY] == 3)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(i, playerY);
                    Console.Write('▓');

                }else if(map[i, playerY] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(i, playerY);
                    Console.Write(' ');
                }
                else if (map[i, playerY] == 4)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(i, playerY);
                    Console.Write('░');
                }
                else if (map[i, playerY] == 5)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(i, playerY);
                    Console.Write('░');
                }
                else if (map[i, playerY] == 6)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.SetCursorPosition(i, playerY);
                    Console.Write('░');
                }
                else if (map[i, playerY] == 7)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(i, playerY);
                    Console.Write('░');
                }

            }
            

            Console.ResetColor();
        }

        public void generate_player(Player player) {
            player.position_x = (Console.WindowWidth - 1) / 2;
            player.position_y = Console.WindowHeight - deapth_of_soil - 1;
            
            map[player.position_x, player.position_y] = 1;

            Console.SetCursorPosition(player.position_x, player.position_y);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write('P');
            Console.ResetColor();
        }

        public void generate_ore(int number_of_ore_deposites , ConsoleColor color , int ore_representation) {

            Console.ForegroundColor = color;
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Random random = new Random();
            int position_minX = 1;
            int position_minY = Console.WindowHeight - deapth_of_soil + 1;
            int position_maxX = Console.WindowWidth - 1;
            int position_maxY = Console.WindowHeight - 2;

            int[] ore_circle = new int[16];
            

            int ore_X;
            int ore_Y;

            int num_of_ors;

            for (int i = 0; i < number_of_ore_deposites; i++) {
                do
                {
                    ore_X = random.Next(position_minX, position_maxX);
                    ore_Y = random.Next(position_minY, position_maxY);

                } while (map[ore_X, ore_Y] == 0);

                num_of_ors = GenerateNormalRandomInt(random, 4.0, 2, 0, 8);

                ore_circle = fill_circle_ore(ore_circle, ore_X, ore_Y);

                Console.SetCursorPosition(ore_X, ore_Y);
                Thread.Sleep(50);
                Console.Write('░');
                map[ore_X, ore_Y] = ore_representation;

                int end = num_of_ors * 2;
                int posX,posY;


                for (int j = 0; j < end; j+= 2) {
                    int add = j + 1;
                    posX = ore_circle[j];
                    posY = ore_circle[add];
                    Console.SetCursorPosition(posX, posY);
                    map[posX, posY] = ore_representation;
                    Thread.Sleep(25);
                    Console.Write('░');

                }

                Console.SetCursorPosition(ore_X, ore_Y);

            }


            Console.ResetColor();
            return;

        }

        public int[] fill_circle_ore(int[] ore_circle, int ore_X, int ore_Y) {
            ore_circle[0] = ore_X + 1;
            ore_circle[1] = ore_Y;

            ore_circle[2] = ore_X + 1;
            ore_circle[3] = ore_Y + 1;

            ore_circle[4] = ore_X + 1;
            ore_circle[5] = ore_Y - 1;

            ore_circle[6] = ore_X - 1;
            ore_circle[7] = ore_Y + 1;

            ore_circle[8] = ore_X;
            ore_circle[9] = ore_Y + 1;

            ore_circle[10] = ore_X - 1;
            ore_circle[11] = ore_Y - 1;

            ore_circle[12] = ore_X - 1;
            ore_circle[13] = ore_Y;

            ore_circle[14] = ore_X;
            ore_circle[15] = ore_Y + 1;
            return ore_circle;
        }

        static int GenerateNormalRandomInt(Random random, double mean, double stddev, int minValue, int maxValue)
        {
            // Use Box-Muller transform to generate a normally distributed random number
            double u1 = 1.0 - random.NextDouble(); // Uniform(0,1] random doubles
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); // Random normal(0,1)
            double randNormal = mean + stddev * randStdNormal; // Random normal(mean,stdDev)

            // Round to the nearest integer
            int randNormalInt = (int)Math.Round(randNormal);

            // Clamp to the specified range
            randNormalInt = Math.Max(minValue, Math.Min(maxValue, randNormalInt));

            return randNormalInt;
        }

    }
}
