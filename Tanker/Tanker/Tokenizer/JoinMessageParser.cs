using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.Tokenizer
{
    public class JoinMessageParser : MessageParser
    {
        public JoinMessageParser(MainGrid active_grid)
            : base(active_grid)
        {

        }
        public override bool handleMessageImpl(string message)
        {
            switch (message)
            {
                case "PLAYERS_FULL#":
                    // Handle the case for players being full in the grid
                    Console.WriteLine("Players full");
                    active_grid.Message = "PLAYERS_FULL#";
                    return true;
                case "ALREADY_ADDED#":
                    // Handle the case for player already been added
                    Console.WriteLine("Already added to the game");
                    return true;
                case "GAME_ALREADY_STARTED#":
                    // Handle the request for the game being already added
                    Console.WriteLine("Game already started");
                    active_grid.Message = "GAME_ALREADY_STARTED#";
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
