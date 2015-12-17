using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.MessageParser
{
    class GlobalBroadCastHandler : MessageParser
    {
        string[] message_components;
        string[] sub_components;

        public override bool handleMessageImpl(string message)
        {
            // if the starting character of the message string if not G this message
            // will not be processed by this handler
            if (message[0] != 'G')
            {
                return false;
            }
            // if a legitimate message to be handled
            else
            {
                message_components = message.Split(':');
                for (int i = 1; i < message_components.Length; i++)
                {
                    sub_components = message_components[i].Split(';');
                    if (sub_components[i][0] == 'P')
                    {
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
                    }
                    else
                    {
                        // if th data is related to the brick arrangement
                        string[] sections = sub_components[i].Split(';');
                        foreach (string s in sections)
                        {
                            // These are the data related to the bricks and their damage level
                            int x = Int32.Parse(s.Split(',')[0]);
                            int y = Int32.Parse(s.Split(',')[1]);
                            int damage_level = Int32.Parse(s.Split(',')[2]);
                            // if the damage is 100% the brick shall be removed from the grid
                        }
                    }
                }
                return true;
            }
        }
    }
}
