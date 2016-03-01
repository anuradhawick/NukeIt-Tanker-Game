using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanker.AI.CalculationTools
{
    class BaseLogic
    {
        private static int health;
        private static int score;
        private static bool isScoreHigh;
        private static bool isHealthLow;
        private static bool isVulnerable;
        private BaseLogic()
        {

        }

        public static Vector2 getNext()
        {
            return new Vector2();
        }

        public void updateStats(MainGrid mg)
        {

        }
    }
}
