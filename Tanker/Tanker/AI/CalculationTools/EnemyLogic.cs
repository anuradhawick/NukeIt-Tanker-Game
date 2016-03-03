using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanker.AI.GraphTools;

namespace Tanker.AI.CalculationTools
{
    class EnemyLogic
    {

        public static Tank getNearestEnemy(MainGrid mg, Graph g)
        {
            // Get the player location
            Vector2 playerLocation = mg.getTank(mg.Playername).Location;
            // get the nearest coin pile                          
            int dist = 1000;
            int tempDist;
            Tank nearestEnemy = mg.Tanks[mg.Playername];
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
        public static bool shouldEscape(MainGrid mg, Graph g)
        {
            return false;
        }

        // Get the location of the place with no vulnerability
        public static Vector2 getNearestSafePlace(MainGrid mg, Graph g)
        {

            return new Vector2();
        }

        private static List<Node> getSafePlaces(MainGrid mg,Graph g)
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
                                        if(ourPlayer.Location.X == tk.Location.X && ourPlayer.Location.Y < tk.Location.Y)
                                        {
                                            // At Risk
                                        }
                                        else
                                        {
                                            // Safe
                                            safePlaces.Add(nodes[i,j]);
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
    }
}
