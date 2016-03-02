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

        public static Vector2 getSuitableEnemy(MainGrid mg, Graph g)
        {
            // Get the player location
            Vector2 playerLocation = mg.getTank(mg.Playername).Location;
            // get the nearest coin pile                          
            int dist = 1000;
            int tempDist;
            Vector2 nearestEnemy = playerLocation; ;
            foreach (Tank tank in mg.Tanks.Values.ToList<Tank>())
            {
                tempDist = g.getPathByEntity(tank).Count;
                //tempDist = Math.Abs((int)playerLocation.X - (int)item.Location.X) + Math.Abs((int)playerLocation.Y - (int)item.Location.Y);
                if (tempDist < dist)
                {
                    dist = tempDist;
                    nearestEnemy=tank.Location;
                }
            }
            return nearestEnemy;
        }
    }
}
