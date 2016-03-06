using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;

namespace Tanker.GameEntity
{
    public class Bullet : AbstractEntity
    {
        private int direction; // Follows tank convention
        private Vector2 pixelLocation;

        public Bullet(int direction, Vector2 location)
        {
            this.direction = direction;
            pixelLocation = location;
        }
        public int Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public Vector2 PixelLocation
        {
            get
            {
                return pixelLocation;
            }

            set
            {
                pixelLocation = value;
            }
        }
    }
}
