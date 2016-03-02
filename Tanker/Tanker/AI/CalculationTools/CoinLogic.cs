using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanker.AI.CalculationTools
{
    class CoinLogic
    {
        private CoinLogic()
        {

        }

        public static Vector2 getBestCoin(MainGrid mg)
        {
            // Get the player location
            Vector2 playerLocation = mg.getTank(mg.Playername).Location;
            // get the nearest coin pile
            int dist = 1000;
            int tempDist;
            Vector2 nearestCoin = playerLocation; ;     
            foreach (Coin item in mg.Coins.Values.ToList<Coin>())
            {
                tempDist = Math.Abs((int)playerLocation.X - (int)item.Location.X) + Math.Abs((int)playerLocation.Y - (int)item.Location.Y);
                if(tempDist < dist)
                {
                    dist = tempDist;
                    nearestCoin = item.Location;
                }
            }
            return nearestCoin;
        }
    }
}
