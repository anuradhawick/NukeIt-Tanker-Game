using Microsoft.Xna.Framework;
using NukeIt_Tanker.CommManager;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanker.AI
{
    class MotionLogic
    {
        private MotionLogic()
        {

        }

        public static void nextMove(MessageSender ms, MainGrid mg, Vector2 location)
        {
            Vector2 player = mg.getTank(mg.Playername).Location;
            // to move right
            if (player.X < location.X)
            {
                ms.right();
            }
            // to move left
            else if (player.X > location.X)
            {
                ms.left();
            }
            // to move up
            else if (player.Y > location.Y)
            {
                ms.up();
            }
            // to move down
            else
            {
                ms.down();
            }
        }
    }
}
