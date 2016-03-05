using NukeIt_Tanker.GameEntity.TimeOutableEntities;

namespace NukeIt_Tanker.GameEntity
{
    class LifePack : AbstractEntity, TimeOutable
    {
        private int life_time;
        private long born_time;

        public LifePack()
        {
            Born_time = CurrentTimeMillis();
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
