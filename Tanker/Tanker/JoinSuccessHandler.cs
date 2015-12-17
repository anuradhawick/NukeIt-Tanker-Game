using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.MessageParser
{
    class JoinSuccessHandler : MessageParser
    {
        int[,] game_grid;
        int[] location;
        string[] messageComponents;
        string player_name;
        int direction;

        public override bool handleMessageImpl(string message)
        {
            if (message[0] != 'S')
            {
                return false;
            }
            else
            {
                messageComponents = message.Split(':');
                player_name = messageComponents[1];
                location = new int[] { Int32.Parse((messageComponents[2].Split(','))[0]), Int32.Parse((messageComponents[2].Split(','))[1]) };
                direction = Int32.Parse(messageComponents[3]);
                //Handle the case and return true
                return true;
            }
        }
    }
}
