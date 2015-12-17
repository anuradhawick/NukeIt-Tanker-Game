using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.MessageParser
{
    class GameInidiationHandler : MessageParser
    {
        string player_name;
        List<int[]> bricks;
        List<int[]> stone;
        List<int[]> water;
        string[] message_components;
        string[] temp;
        public override bool handleMessageImpl(string message)
        {
            if (message[0] != 'I')
            {
                return false;
            }
            else
            {
                message_components = message.Split(':');
                // Decoding player name
                player_name = message_components[1];
                // Decoding brick locations
                temp = message_components[2].Split(';');
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    bricks.Add(cordinate);
                }
                // Decoding stone locations
                temp = message_components[3].Split(';');
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    stone.Add(cordinate);
                }
                // Decoding water locations
                temp = message_components[4].Split(';');
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    water.Add(cordinate);
                }

                // Do the required mechanism here
                return true;
            }
        }
    }
}
