using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.MessageParser
{
    class JoinMessageParser : MessageParser
    {
        public override bool handleMessageImpl(string message)
        {
            switch (message)
            {
                case "PLAYERS_FULL":
                    // Handle the case for players being full in the grid
                    Console.WriteLine("Players full");
                    return true;
                case "ALREADY_ADDED":
                    // Handle the case for player already been added
                    Console.WriteLine("Already added to the game");
                    return true;
                case "GAME_ALREADY_STARTED":
                    // Handle the request for the game being already added
                    Console.WriteLine("Game already started");
                    return true;
            }
            return false;
        }

        public void handlePlayersFull()
        {

        }

        public void handleAlreadyAdded()
        {

        }

        public void handleAlreadyStarted()
        {

        }
    }
}
