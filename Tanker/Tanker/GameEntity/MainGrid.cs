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
        private Dictionary<int[], BrickWall> brickWalls;
        // Stone walls hashed with their location
        private Dictionary<int[], StoneWall> stoneWalls;
        // Waters hashed with their location
        private Dictionary<int[], StoneWall> waters;
        // Coints hashed with their location
        private Dictionary<int[], Coin> coins;
        // Life packs hashed with their location
        private Dictionary<int[], LifePack> life_packs;

        public MainGrid()
        {

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
        public BrickWall getBrickWall(int[] location)
        {
            return brickWalls[location];
        }

        // Adding and accessing stone walls
        public void addStoneWall(StoneWall s)
        {
            stoneWalls.Add(s.Location, s);
        }
        public StoneWall getStoneWall(int[] location)
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
        public Coin getCoin(int[] location)
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

        public LifePack getLifePack(int[] location)
        {
            return life_packs[location];
        }

        // Thread operated method for removal of coins after timeout
        private void timeout(TimeOutableEntities.TimeOutable te)
        {
            Thread.Sleep(te.getTimeout());
            coins.Remove(((AbstractEntity)te).Location);
        }

        
    }
}
