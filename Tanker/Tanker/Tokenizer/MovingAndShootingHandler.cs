using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.Tokenizer
{
    class MovingAndShootingHandler : MessageParser
    {
        public MovingAndShootingHandler(MainGrid active_grid)
            : base(active_grid)
        {

        }
        public override bool handleMessageImpl(string message)
        {
            switch (message)
            {
                case "OBSTACLE#":
                    Console.WriteLine("Obstacle parsed");
                    return true;
                case "CELL_OCCUPIED#":
                    Console.WriteLine("Cell occupied parsed");
                    return true;
                case "DEAD#":
                    Console.WriteLine("death parsed");
                    return true;
                case "TOO_QUICK#":
                    Console.WriteLine("too quick parsed");
                    return true;
                case "INVALID_CELL#":
                    Console.WriteLine("invalid cell parsed");
                    return true;
                case "GAME_HAS_FINISHED#":
                    Console.WriteLine("game finished parsed");
                    return true;
                case "GAME_HAS_NOT_STARTED_YET#":
                    Console.WriteLine("not started yet parsed");
                    return true;
                case "NOT_A_VALID_CONTESTANT#":
                    Console.WriteLine("invalid contestant parsed");
                    return true;
            }

            return false;
        }
    }
}
