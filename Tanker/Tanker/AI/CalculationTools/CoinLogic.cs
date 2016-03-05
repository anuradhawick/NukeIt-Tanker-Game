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

        public static Vector2 getBestCoin(MainGrid mg, Graph g)
        {
            // Get the player location
            Vector2 playerLocation = mg.getTank(mg.Playername).Location;
            // get the nearest coin pile                          
            int dist = 1000;
            int tempDist;
            Vector2 nearestCoin = playerLocation; ;
            foreach (Coin item in mg.Coins.Values.ToList<Coin>())
            {
                tempDist = g.getPathByEntity(item).Count;
                if (tempDist < dist)
                {
                    dist = tempDist;
                    nearestCoin = item.Location;
                }
            }
            return nearestCoin;
        }

        public static Vector2 getBestBrickWall(MainGrid mg, Graph g) {
            // Get the player location
            Vector2 playerLocation = mg.getTank(mg.Playername).Location;
            // get the nearest Brick                          
            int dist = 1000;
            int tempDist;
            Vector2 nearestBrick = playerLocation; ;
            foreach (BrickWall item in mg.BrickWalls.Values.ToList<BrickWall>())
            {
                tempDist = g.getPathByEntity(item).Count;
                if (tempDist < dist)
                {
                    dist = tempDist;
                    nearestBrick = item.Location;
                }
            }
            return nearestBrick;
        }
    }
}
