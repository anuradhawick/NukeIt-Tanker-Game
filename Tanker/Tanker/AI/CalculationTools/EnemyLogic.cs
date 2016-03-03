using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public static bool shouldEscape(MainGrid grid, Graph g)
        {
            Tank ourPlayer = grid.getTank(grid.Playername);
            foreach (Tank tank in grid.Tanks.Values.ToList<Tank>()) {
                if (ourPlayer.Location.X == tank.Location.X)
                {
                    if ((ourPlayer.Location.Y > tank.Location.Y & tank.Direction == 2) || (ourPlayer.Location.Y < tank.Location.Y & tank.Direction == 0))
                    {
                        foreach (StoneWall stone in grid.StoneWalls.Values.ToList<StoneWall>())
                        {
                            if ((ourPlayer.Location.X <stone.Location.X && stone.Location.X <tank.Location.X) || (tank.Location.X<stone.Location.X && stone.Location.X<ourPlayer.Location.X) )
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
            return new Vector2();
        }
    }
}
