using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.GameEntity
{
    class Tank : AbstractEntity
    {
        private string player_name;
        private string whether_shot;
        private int coins;
        private int points;
        private int direction;

        public string Player_name
        {
            get { return player_name; }
            set { player_name = value; }
        }

        public int Coins
        {
            get { return coins; }
            set { coins = value; }
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

        public string Whether_shot
        {
            get { return whether_shot; }
            set { whether_shot = value; }
        }


    }
}
