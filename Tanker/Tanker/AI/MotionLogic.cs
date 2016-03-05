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

        // Check if a cell is in the grid
        public static Boolean isValidCell(int x, int y)
        {
            if (x < 0)
            {
                return false;
            }
            if (y < 0)
            {
                return false;
            }
            if (x > 9)
            {
                return false;
            }
            if (y > 9)
            {
                return false;
            }
            return true;
        }
        public static void nextMove(MessageSender ms, MainGrid mg, Vector2 location)
        {
            Vector2 player = mg.Tanks[mg.Playername].Location;
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


        public static bool isCellOccupied(Graph g, Vector2 nextCell)
        {
            if (g.getNodes()[(int)nextCell.X, (int)nextCell.Y].Type == Components.Tank)
            {
                return true;
            }
            return false;
        }

        // ent1 and ent2 should be on same row or col
        public static bool isInBetween(AbstractEntity ent1, AbstractEntity ent2, AbstractEntity midPoint)
        {
            // in same column
            if (ent1.Location.X == ent2.Location.X && ent2.Location.X == midPoint.Location.X)
            {
                //ent1 above ent2
                if (ent1.Location.Y < ent2.Location.Y)
                {
                    if(ent1.Location.Y<midPoint.Location.Y && midPoint.Location.Y < ent2.Location.Y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // ent2 above ent1
                else
                {
                    if (ent2.Location.Y < midPoint.Location.Y && midPoint.Location.Y < ent1.Location.Y)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (ent1.Location.Y == ent2.Location.Y && ent2.Location.Y == midPoint.Location.Y)
            {
                //ent1 east of ent2
                if (ent1.Location.X > ent2.Location.X)
                {
                    if (ent1.Location.X > midPoint.Location.X && midPoint.Location.X > ent2.Location.X)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // ent1 west of ent2
                else
                {
                    if (ent2.Location.X > midPoint.Location.X && midPoint.Location.X > ent1.Location.X)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

    }
}
