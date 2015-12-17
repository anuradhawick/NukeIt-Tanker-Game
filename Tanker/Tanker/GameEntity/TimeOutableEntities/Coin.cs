using NukeIt_Tanker.GameEntity.TimeOutableEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.GameEntity
{
    class Coin : AbstractEntity,TimeOutable
    {
        // Coins have a specific life time and a value
        private int life_time;
        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public int Life_time
        {
            get { return life_time; }
            set { life_time = value; }
        }


        public int getTimeout()
        {
            return this.Life_time;
        }
    }
}
