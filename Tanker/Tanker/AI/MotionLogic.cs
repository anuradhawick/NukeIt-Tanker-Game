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

        public static bool shootable(MainGrid grid, Tank tank)
        {

            Tank ourPlayer = grid.getTank(grid.Playername);
            if (ourPlayer.Location.X == tank.Location.X)
            {
                if ((ourPlayer.Location.Y > tank.Location.Y & ourPlayer.Direction == 0) || (ourPlayer.Location.Y < tank.Location.Y & ourPlayer.Direction == 2))
                {
                    foreach (StoneWall stone in grid.StoneWalls.Values.ToList<StoneWall>())
                    {
                        if ((ourPlayer.Location.X < stone.Location.X && stone.Location.X < tank.Location.X) || (tank.Location.X < stone.Location.X && stone.Location.X < ourPlayer.Location.X))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (ourPlayer.Location.Y == tank.Location.Y)
            {
                if ((ourPlayer.Location.X > tank.Location.X & ourPlayer.Direction == 3) || (ourPlayer.Location.X < tank.Location.X & ourPlayer.Direction == 1))
                {
                    foreach (StoneWall stone in grid.StoneWalls.Values.ToList<StoneWall>())
                    {
                        if ((ourPlayer.Location.Y < stone.Location.Y && stone.Location.Y < tank.Location.Y) || (tank.Location.Y < stone.Location.Y && stone.Location.Y < ourPlayer.Location.Y))
                        {
                            return false;
                        }
                    }
                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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

        public static bool isDirectShootable(MainGrid mg, Graph g)
        {
            Tank ourPlayer = mg.Tanks[mg.Playername];
            switch (ourPlayer.Direction)
            {
                case 0:
                    // North
                    foreach (Tank tk in mg.Tanks.Values.ToList<Tank>())
                    {
                        if (tk.Player_name == mg.Playername) continue;
                        if (tk.Location.X == ourPlayer.Location.X && tk.Location.Y < ourPlayer.Location.Y)
                        {
                            return true;
                        }
                    }
                    return false;
                case 1:
                    // East
                    foreach (Tank tk in mg.Tanks.Values.ToList<Tank>())
                    {
                        if (tk.Player_name == mg.Playername) continue;
                        if (tk.Location.X > ourPlayer.Location.X && tk.Location.Y == ourPlayer.Location.Y)
                        {
                            return true;
                        }
                    }
                    return false;
                case 2:
                    // South
                    foreach (Tank tk in mg.Tanks.Values.ToList<Tank>())
                    {
                        if (tk.Player_name == mg.Playername) continue;
                        if (tk.Location.X == ourPlayer.Location.X && tk.Location.Y > ourPlayer.Location.Y)
                        {
                            return true;
                        }
                    }
                    return false;
                case 3:
                    // West
                    foreach (Tank tk in mg.Tanks.Values.ToList<Tank>())
                    {
                        if (tk.Player_name == mg.Playername) continue;
                        if (tk.Location.X < ourPlayer.Location.X && tk.Location.Y == ourPlayer.Location.Y)
                        {
                            return true;
                        }
                    }
                    return false;
            }
            return false;
        }
    }
}
