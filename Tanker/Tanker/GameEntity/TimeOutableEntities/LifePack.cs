using NukeIt_Tanker.GameEntity.TimeOutableEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.GameEntity
{
    class LifePack : AbstractEntity,TimeOutable
    {
        private int life_time;

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
