using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using Tanker.AI.GraphTools;

namespace Tanker.AI.CalculationTools
{
    public class ShootingLogic
    {

        public static Tank getNearestEnemy(MainGrid mg, Graph g)
        {
            // Get the player location
            Vector2 playerLocation = mg.getTank(mg.Playername).Location;
            // get the nearest coin pile                          
            int dist = 1000;
            int tempDist;
            Tank nearestEnemy = new Tank();
            foreach (Tank tank in mg.Tanks.Values.ToList<Tank>())
            {
                tempDist = g.getPathByEntity(tank).Count;
                if (tank.Player_name == mg.Playername)
                    continue;
                if (tempDist < dist)
                {
                    dist = tempDist;
                    nearestEnemy = tank;
                }
            }
            return nearestEnemy;
        }

        // Check if the current position is vulnerable for an attack
        public static bool shouldEscape(MainGrid grid, Graph g)
        {
            Tank ourPlayer = grid.getTank(grid.Playername);
            foreach (Tank tank in grid.Tanks.Values.ToList<Tank>())
            {
                if (ourPlayer.Location.X == tank.Location.X)
                {
                    if ((ourPlayer.Location.Y > tank.Location.Y & tank.Direction == 2) || (ourPlayer.Location.Y < tank.Location.Y & tank.Direction == 0))
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
                    if ((ourPlayer.Location.X > tank.Location.X & tank.Direction == 1) || (ourPlayer.Location.X < tank.Location.X & tank.Direction == 3))
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
            return false;

        }

        // Get the location of the place with no vulnerability
        public static Vector2 getNearestSafePlace(MainGrid mg, Graph g)
        {
            List<Node> safePlaces = getSafePlaces(mg, g);
            Node nearestNode = null;
            int tempDist = 10000;
            foreach (Node n in safePlaces)
            {
                if (tempDist > g.getPathByNode(n).Count)
                {
                    tempDist = g.getPathByNode(n).Count;
                    nearestNode = n;
                }
            }
            return new Vector2(nearestNode.getX(), nearestNode.getY());
        }

        private static List<Node> getSafePlaces(MainGrid mg, Graph g)
        {
            List<Node> safePlaces = new List<Node>();
            Vector2 myLocation = mg.Tanks[mg.Playername].Location;
            Node[,] nodes = g.getNodes();
            Tank ourPlayer = mg.Tanks[mg.Playername];
            Node n;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    n = nodes[i, j];
                    if (n.Type == Components.Empty)
                    {
                        foreach (Tank tk in mg.Tanks.Values.ToList<Tank>())
                        {
                            if (tk.Player_name == mg.Playername) continue;
                            else
                            {
                                switch (tk.Direction)
                                {
                                    case 0:
                                        // North
                                        // Same X cordinate and our Y is lower
                                        if (ourPlayer.Location.X == tk.Location.X && ourPlayer.Location.Y < tk.Location.Y)
                                        {
                                            // At Risk
                                        }
                                        else
                                        {
                                            // Safe
                                            safePlaces.Add(nodes[i, j]);
                                        }
                                        break;
                                    case 1:
                                        // East
                                        // Same Y cordinate and our X is greater
                                        if (ourPlayer.Location.Y == tk.Location.Y && ourPlayer.Location.X > tk.Location.X)
                                        {
                                            // At Risk
                                        }
                                        else
                                        {
                                            // Safe
                                            safePlaces.Add(nodes[i, j]);
                                        }
                                        break;
                                    case 2:
                                        // South
                                        // Same X cordinate and our Y is greater
                                        if (ourPlayer.Location.X == tk.Location.X && ourPlayer.Location.Y > tk.Location.Y)
                                        {
                                            // At Risk
                                        }
                                        else
                                        {
                                            // Safe
                                            safePlaces.Add(nodes[i, j]);
                                        }
                                        break;
                                    case 3:
                                        // West
                                        // Same Y cordinate and our X is lower
                                        if (ourPlayer.Location.Y == tk.Location.Y && ourPlayer.Location.X < tk.Location.X)
                                        {
                                            // At Risk
                                        }
                                        else
                                        {
                                            // Safe
                                            safePlaces.Add(nodes[i, j]);
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            return safePlaces;
        }

        public static bool shootable(MainGrid grid, AbstractEntity ent)
        {

            Tank ourPlayer = grid.getTank(grid.Playername);

            if (ourPlayer.Location.X == ent.Location.X)
            {
                // Our player facing north or south
                if ((ourPlayer.Location.Y > ent.Location.Y & ourPlayer.Direction == 0) || (ourPlayer.Location.Y < ent.Location.Y & ourPlayer.Direction == 2))
                {
                    foreach (StoneWall stone in grid.StoneWalls.Values.ToList<StoneWall>())
                    {
                        // intercepting stones
                        if (MotionLogic.isInBetween(ent, ourPlayer, stone))
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
            else if (ourPlayer.Location.Y == ent.Location.Y)
            {
                // our player facing east or west
                if ((ourPlayer.Location.X > ent.Location.X & ourPlayer.Direction == 3) || (ourPlayer.Location.X < ent.Location.X & ourPlayer.Direction == 1))
                {
                    foreach (StoneWall stone in grid.StoneWalls.Values.ToList<StoneWall>())
                    {
                        // intercepting stones
                        if (MotionLogic.isInBetween(ent, ourPlayer, stone))
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

        public static bool isDirectShootable(MainGrid mg)
        {
            foreach (Tank tk in mg.Tanks.Values.ToList<Tank>())
            {
                if (tk.Player_name == mg.Playername) continue;
                else if (shootable(mg, tk))
                {
                   
                    return true;
                }
            }
            return false;
        }
    }
}
