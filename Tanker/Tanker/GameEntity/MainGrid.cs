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
            brickWalls.Add(b.Location, b);
        }
        public BrickWall getBrickWall(Vector2 location)
        {
            return brickWalls[location];
        }

        // Adding and accessing stone walls
        public void addStoneWall(StoneWall s)
        {
            stoneWalls.Add(s.Location, s);
        }
        public StoneWall getStoneWall(Vector2 location)
        {
            return stoneWalls[location];
        }

        // Adding, accessing and removal coins with timeout
        public void addCoin(Coin c)
        {
            coins.Add(c.Location, c);
            Thread t = new Thread(() => timeout(c));
            t.Start();
        }
        public Coin getCoin(Vector2 location)
        {
            return coins[location];
        }
        // Adding, accessing and removal of life packs
        public void addLifePack(LifePack l)
        {
            life_packs.Add(l.Location, l);
            Thread t = new Thread(() => timeout(l));
            t.Start();
        }

        public LifePack getLifePack(Vector2 location)
        {
            return life_packs[location];
        }

        // Thread operated method for removal of coins after timeout
        private void timeout(TimeOutableEntities.TimeOutable te)
        {
            Thread.Sleep(te.getTimeout());
            coins.Remove(((AbstractEntity)te).Location);
        }

        // Update tank location
        public void updateTank(String name,Vector2 location,bool shot,int dir,int points,int health){
            tanks[name].Location = location;
            tanks[name].Whether_shot = shot;
            tanks[name].Direction = dir;
            tanks[name].Points = points;
            tanks[name].Health = health;
        }

        public void updateBrick(Vector2 location,int damage)
        {
            brickWalls[location].Damage = damage;
        }




    }
}
