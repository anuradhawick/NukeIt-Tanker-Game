namespace NukeIt_Tanker.GameEntity
{
    class Tank : AbstractEntity
    {
        // Attributes of a tank
        private string player_name;
        private bool whether_shot;
        private int points;
        private int direction;
        private int health;
        private int coins;

        // Getters and setters
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string Player_name
        {
            get { return player_name; }
            set { player_name = value; }
        }


        public int Points
        {
            get { return points; }
            set { points = value; }
        }


        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public bool Whether_shot
        {
            get { return whether_shot; }
            set { whether_shot = value; }
        }

        public int Coins
        {
            get
            {
                return coins;
            }

            set
            {
                coins = value;
            }
        }
    }
}
