using NukeIt_Tanker.GameEntity.TimeOutableEntities;

namespace NukeIt_Tanker.GameEntity
{
    public class Coin : AbstractEntity, TimeOutable
    {
        // Coins have a specific life time and a value
        private int life_time;
        private int value;
        private long born_time;

        public Coin()
        {
            born_time = CurrentTimeMillis();
        }
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

        public long Born_time
        {
            get { return born_time; }
            set { born_time = value; }
        }

        public int getTimeout()
        {
            return this.Life_time;
        }
    }
}
