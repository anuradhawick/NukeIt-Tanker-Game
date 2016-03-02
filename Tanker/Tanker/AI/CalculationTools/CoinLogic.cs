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

        private Vector2 getBestCoin(MainGrid mg)
        {
            // Get the player location
            Vector2 playerLocation = mg.getTank(mg.Playername).Location;

            return new Vector2();
        }
    }
}
