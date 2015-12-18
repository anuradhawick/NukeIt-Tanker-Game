using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NukeIt_Tanker.GameEntity
{
    class MainGrid
    {
        // The grid contains a hash-table containing the tanks with player name as the key
        private Dictionary<string, Tank> tanks;


        // Brick walls hashed with their location
        private Dictionary<Vector2, BrickWall> brickWalls;


        // Stone walls hashed with their location
        private Dictionary<Vector2, StoneWall> stoneWalls;


        // Waters hashed with their location
        private Dictionary<Vector2, StoneWall> waters;


        // Coints hashed with their location
        private Dictionary<Vector2, Coin> coins;


        // Life packs hashed with their location
        private Dictionary<Vector2, LifePack> life_packs;


        private string playername;

        public string Playername
        {
            get { return playername; }
            set { playername = value; }
        }

        public MainGrid()
        {
            tanks = new Dictionary<string, Tank>();
            brickWalls = new Dictionary<Vector2, BrickWall>();
            stoneWalls = new Dictionary<Vector2, StoneWall>();
            waters = new Dictionary<Vector2, StoneWall>();
            coins = new Dictionary<Vector2, Coin>();
            life_packs = new Dictionary<Vector2, LifePack>();
        }

        // Adding and accessing tanks
        public void addTank(Tank t)
        {
            tanks.Add(t.Player_name, t);
        }
        public Tank getTank(string player_name)
        {
            return tanks[player_name];
        }

        // Adding and accessing Brick Walls
        public void addBrickWall(BrickWall b)
        {
            BrickWalls.Add(b.Location, b);
        }
        public BrickWall getBrickWall(Vector2 location)
        {
            return BrickWalls[location];
        }

        // Adding and accessing stone walls
        public void addStoneWall(StoneWall s)
        {
            StoneWalls.Add(s.Location, s);
        }
        public StoneWall getStoneWall(Vector2 location)
        {
            return StoneWalls[location];
        }

        // Adding, accessing and removal coins with timeout
        public void addCoin(Coin c)
        {
            Coins.Add(c.Location, c);
            Thread t = new Thread(() => timeout(c));
            t.Start();
        }
        public Coin getCoin(Vector2 location)
        {
            return Coins[location];
        }
        // Adding, accessing and removal of life packs
        public void addLifePack(LifePack l)
        {
            Life_packs.Add(l.Location, l);
            Thread t = new Thread(() => timeout(l));
            t.Start();
        }

        public LifePack getLifePack(Vector2 location)
        {
            return Life_packs[location];
        }

        // Thread operated method for removal of coins after timeout
        private void timeout(TimeOutableEntities.TimeOutable te)
        {
            Thread.Sleep(te.getTimeout());
            Coins.Remove(((AbstractEntity)te).Location);
        }

        // Update tank location
        public void updateTank(String name, Vector2 location, bool shot, int dir, int points, int health)
        {
            tanks[name].Location = location;
            tanks[name].Whether_shot = shot;
            tanks[name].Direction = dir;
            tanks[name].Points = points;
            tanks[name].Health = health;
        }

        public void updateBrick(Vector2 location, int damage)
        {
            BrickWalls[location].Damage = damage;
        }

        internal Dictionary<Vector2, Coin> Coins
        {
            get { return coins; }
            set { coins = value; }
        }

        internal Dictionary<Vector2, BrickWall> BrickWalls
        {
            get { return brickWalls; }
            set { brickWalls = value; }
        }

        internal Dictionary<Vector2, StoneWall> Waters
        {
            get { return waters; }
            set { waters = value; }
        }

        internal Dictionary<string, Tank> Tanks
        {
            get { return tanks; }
            set { tanks = value; }
        }
        internal Dictionary<Vector2, StoneWall> StoneWalls
        {
            get { return stoneWalls; }
            set { stoneWalls = value; }
        }

        internal Dictionary<Vector2, LifePack> Life_packs
        {
            get { return life_packs; }
            set { life_packs = value; }
        }
    }
}
