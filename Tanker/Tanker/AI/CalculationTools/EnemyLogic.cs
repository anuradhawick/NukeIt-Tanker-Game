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
        public static bool shouldEscape(MainGrid mg, Graph g)
        {
            return false;
        }

        // Get the location of the place with no vulnerability
        public static Vector2 getNearestSafePlace(MainGrid mg, Graph g)
        {
            return new Vector2();
        }
    }
}
