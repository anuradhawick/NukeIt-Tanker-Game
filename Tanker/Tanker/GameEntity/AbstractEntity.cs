using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.GameEntity
{
    // Acts as the parent class for all building game entities that lies in the Game Grid
    abstract class AbstractEntity
    {
        // Location of the game object
        private int[] location;

        public int[] Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
