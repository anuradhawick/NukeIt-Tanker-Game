using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.Tokenizer
{
    class GlobalBroadCastHandler : MessageParser
    {
        string[] message_components;
        string[] sub_components;

        public GlobalBroadCastHandler(MainGrid active_grid)
            : base(active_grid)
        {

        }
        public override bool handleMessageImpl(string message)
        {
            // if the starting character of the message string if not G this message
            // will not be processed by this handler
            if (message[0] != 'G')
            {
                return false;
            }
            // if a legitimate message to be handled
            else if (message[1] == ':')
            {
               
                message = message.Substring(0, message.Length - 1);
                message_components = message.Split(':');
                for (int i = 1; i < message_components.Length; i++)
                {
                    if (message_components[i][0] == 'P')
                    {
                        sub_components = message_components[i].Split(';');
                        // If the data set are related to the players
                        // Parsing the location
                        string player_name = sub_components[0];
                        int[] location = { Int32.Parse(sub_components[1].Split(',')[0]), Int32.Parse(sub_components[1].Split(',')[1]) };
                        string direction = sub_components[2];
                        string whether_shot = sub_components[3];
                        int health = Int32.Parse(sub_components[4]);
                        int coins = Int32.Parse(sub_components[5]);
                        int points = Int32.Parse(sub_components[6]);
                        //Update the main grid
                        Console.WriteLine("Player " + player_name);
                        Console.WriteLine("Health " + health);
                        Console.WriteLine("Coins " + coins);
                        Console.WriteLine("Points " + points);
                        Console.WriteLine("Shot " + whether_shot);
                        Console.WriteLine("Location " + location[0] + "," + location[1]);
                        Console.WriteLine("Direction " + direction);
                        active_grid.updateTank(player_name, new Microsoft.Xna.Framework.Vector2(location[0], location[1]), Int32.Parse(whether_shot) == 1 ? true : false, Int32.Parse(direction), points, health);
                    }
                    else
                    {
                        // if the data is related to the brick arrangement
                        string[] sections = message_components[i].Split(';');
                        foreach (string s in sections)
                        {
                            // These are the data related to the bricks and their damage level
                            int x = Int32.Parse(s.Split(',')[0]);
                            int y = Int32.Parse(s.Split(',')[1]);
                            int damage_level = Int32.Parse(s.Split(',')[2]);
                            // if the damage is 100% the brick shall be removed from the grid
                            //Console.WriteLine("Brick:");
                            //Console.WriteLine("Location " + x + "," + y);
                            //Console.WriteLine("Damage " + damage_level);
                            active_grid.updateBrick(new Microsoft.Xna.Framework.Vector2(x, y), damage_level);
                        }
                    }
                }
                return true;
            }
            else {
                return false;
            }
        }
    }
}
