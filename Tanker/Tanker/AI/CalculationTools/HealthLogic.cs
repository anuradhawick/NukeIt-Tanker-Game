using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanker.AI.CalculationTools
{
    public class HealthLogic
    {

        private HealthLogic() { }

        public static Vector2 getBestLifePack(MainGrid mg, Graph g)
        {
            // Get the player location
            Vector2 playerLocation = mg.getTank(mg.Playername).Location;
            // get the nearest coin pile
            int dist = 1000;
            int tempDist;
            Vector2 nearestLifePack = playerLocation; ;
            foreach (LifePack item in mg.Life_packs.Values.ToList<LifePack>())
            {
                tempDist = g.getPathByEntity(item).Count;
                if (tempDist < dist)
                {
                    dist = tempDist;
                    nearestLifePack = item.Location;
                }
            }
            return nearestLifePack;
        }
    }
}
