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
                //Vector2 tmp = new Vector2(mg.Tanks[mg.Playername].Location.X + 1, mg.Tanks[mg.Playername].Location.Y);
                //mg.updateTank(mg.Playername, tmp, false, 0, 0, 50, 50);
            }
            // to move left
            else if (player.X > location.X)
            {
                ms.left();
                //Vector2 tmp = new Vector2(mg.Tanks[mg.Playername].Location.X - 1, mg.Tanks[mg.Playername].Location.Y);
                //mg.updateTank(mg.Playername, tmp, false, 0, 0, 50, 50);
            }
            // to move up
            else if (player.Y > location.Y)
            {
                ms.up();
                //Vector2 tmp = new Vector2(mg.Tanks[mg.Playername].Location.X, mg.Tanks[mg.Playername].Location.Y - 1);
                //mg.updateTank(mg.Playername, tmp, false, 0, 0, 50, 50);
            }
            // to move down
            else if (player.Y < location.Y)
            {
                ms.down();
                //Vector2 tmp = new Vector2(mg.Tanks[mg.Playername].Location.X, mg.Tanks[mg.Playername].Location.Y + 1);
                //mg.updateTank(mg.Playername, tmp, false, 0, 0, 50, 50);
            }
        }
    }
}
