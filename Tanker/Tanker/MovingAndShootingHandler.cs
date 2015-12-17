using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.MessageParser
{
    class MovingAndShootingHandler : MessageParser
    {
        public override bool handleMessageImpl(string message)
        {
            switch (message)
            {
                case "OBSTACLE":
                    break;
                case "CELL_OCCUPIED":
                    break;
                case "DEAD":
                    break;
                case "TOO_QUICK":
                    break;
                case "INVALID_CELL":
                    break;
                case "GAME_HAS_FINISHED":
                    break;
                case "GAME_HAS_NOT_STARTED_YET":
                    break;
                case "NOT_A_VALID_CONTESTANT":
                    break;
            }

            return false;
        }
    }
}
