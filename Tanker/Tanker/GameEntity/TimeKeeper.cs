using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
namespace Tanker.GameEntity
{
    // Time keeper for expiring timeoutable entities
    public class TimeKeeper : AbstractEntity
    {
        private MainGrid mg;
        private Timer timer;
        private static Dictionary<Vector2, Coin> coins;
        private static Dictionary<Vector2, LifePack> life_packs;

        // Ticks every 500ms and update the maingrid
        public TimeKeeper(MainGrid mg)
        {
            this.mg = mg;
            timer = new Timer(500);
            timer.Elapsed += (sender, e) => performRemoval(sender, e, this);
            timer.Enabled = true;
            timer.Start();
        }

        internal MainGrid Mg
        {
            get { return mg; }
            set { mg = value; }
        }

        private static void performRemoval(Object t, ElapsedEventArgs arg, TimeKeeper tk)
        {
            coins = tk.Mg.Coins;
            life_packs = tk.Mg.Life_packs;
            // Removal of coins
            foreach (Coin cc in coins.Values.ToList<Coin>())
            {
                if (CurrentTimeMillis() > cc.Life_time + cc.Born_time)
                {
                    coins.Remove(cc.Location);
                }
            }
            // removal of life packs
            foreach (LifePack cc in life_packs.Values.ToList<LifePack>())
            {
                if (CurrentTimeMillis() > cc.Life_time + cc.Born_time)
                {
                    life_packs.Remove(cc.Location);
                }
            }
        }
    }
}
