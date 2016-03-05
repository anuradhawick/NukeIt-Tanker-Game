namespace NukeIt_Tanker.GameEntity
{
    class BrickWall : Wall
    {

        private int damage;
        public BrickWall()
        {
            // damage caused to the brick wall
            damage = 0;
        }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
    }
}
