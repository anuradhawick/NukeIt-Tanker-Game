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
        private static string player;
        private static int health;
        private static int score;
        private static int coins;
        private static bool isScoreLow;
        private static bool isHealthLow;
        private static bool isVulnerable;
        private static MainGrid mg;

        public static bool IsScoreLow
        {
            get
            {
                return isScoreLow;
            }

            set
            {
                isScoreLow = value;
            }
        }

        public static bool IsHealthLow
        {
            get
            {
                return isHealthLow;
            }

            set
            {
                isHealthLow = value;
            }
        }

        public static bool IsVulnerable
        {
            get
            {
                return isVulnerable;
            }

            set
            {
                isVulnerable = value;
            }
        }

        private BaseLogic()
        {

        }

        public static void updateStats(MainGrid mg)
        {
            BaseLogic.mg = mg;
            player = mg.Playername;
            health = mg.Tanks[mg.Playername].Health;
            score = mg.Tanks[mg.Playername].Points;
            coins = mg.Tanks[mg.Playername].Coins;
            if (health <= 50)
            {
                IsHealthLow = true;
            }
            isCoinsNeeded();
        }

        private static void isCoinsNeeded()
        {
            int maxCoins = 0;
            foreach (Tank tk in mg.Tanks.Values.ToList<Tank>())
            {
                if (tk.Player_name == player) continue;
                if (maxCoins < tk.Coins) maxCoins = tk.Coins;
            }
            if (maxCoins < coins)
            {
                IsScoreLow = true;
            }
            else
            {
                IsScoreLow = false;
            }
        }
    }
}
