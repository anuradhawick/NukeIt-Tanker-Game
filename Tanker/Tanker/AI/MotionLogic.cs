using Microsoft.Xna.Framework;
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

        public void nextMove(MainGrid mg,Vector2 location)
        {
            Vector2 player = mg.getTank(mg.Playername).Location;
            // to move right
            if(player.X < location.X)
            {
                // 
            }
            // to move left
            else if(player.X > location.X)
            {
                //
            }
            // to move up
            else if(player.Y > location.Y)
            {
                //
            }
            // to move down
            else
            {
                //
            }
        }
    }
}
