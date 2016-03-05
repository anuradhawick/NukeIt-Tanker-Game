using Microsoft.Xna.Framework;
using System;

namespace NukeIt_Tanker.GameEntity
{
    // Acts as the parent class for all building game entities that lies in the Game Grid
    abstract class AbstractEntity
    {
        // Location of the game object
        private Vector2 location;
        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
