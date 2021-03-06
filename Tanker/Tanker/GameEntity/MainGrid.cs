﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Tanker.GameEntity;

namespace NukeIt_Tanker.GameEntity
{
    public class MainGrid
    {
        private bool gameStarted = false;
        private bool death = false;
        // The grid contains a hash-table containing the tanks with player name as the key
        private Dictionary<string, Tank> tanks;


        //used to store messages provided by the server
        private string message;


        // Brick walls hashed with their location
        private Dictionary<Vector2, BrickWall> brickWalls;


        // Stone walls hashed with their location
        private Dictionary<Vector2, StoneWall> stoneWalls;


        // Waters hashed with their location
        private Dictionary<Vector2, Waters> waters;


        // Coints hashed with their location
        private Dictionary<Vector2, Coin> coins;


        // Life packs hashed with their location
        private Dictionary<Vector2, LifePack> life_packs;

        // List of bullets on air
        private List<Bullet> bullets;


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
            waters = new Dictionary<Vector2, Waters>();
            coins = new Dictionary<Vector2, Coin>();
            life_packs = new Dictionary<Vector2, LifePack>();
            bullets = new List<Bullet>();
            message = null;
        }

        // Adding bullets
        public void addBullet(Bullet b)
        {
            bullets.Add(b);
        }

        // Retrieve bullets
        public List<Bullet> getBullets()
        {
            return bullets;
        }

        // Remove bullet
        public void removeBullet(Bullet b)
        {
            bullets.Remove(b);
        }

        // Adding and accessing tanks
        public void addTank(Tank t)
        {
            Tanks.Add(t.Player_name, t);
        }
        public Tank getTank(string player_name)
        {
            return Tanks[player_name];
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
        }
        public Coin getCoin(Vector2 location)
        {
            return Coins[location];
        }
        // Adding, accessing and removal of life packs
        public void addLifePack(LifePack l)
        {
            Life_packs.Add(l.Location, l);
        }

        public LifePack getLifePack(Vector2 location)
        {
            return Life_packs[location];
        }
        // Adding, accessing of waters
        public void addWaters(Waters w)
        {
            waters.Add(w.Location, w);
        }

        public Waters getWaters(Vector2 location)
        {
            return Waters[location];
        }

        // Update tank location
        public void updateTank(String name, Vector2 location, bool shot, int dir, int points, int health, int coins)
        {
            tanks[name].Location = location;
            tanks[name].Whether_shot = shot;
            tanks[name].Direction = dir;
            tanks[name].Points = points;
            tanks[name].Health = health;
            tanks[name].Coins = coins;
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

        internal Dictionary<Vector2, Waters> Waters
        {
            get { return waters; }
            set { waters = value; }
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
        internal Dictionary<string, Tank> Tanks
        {
            get { return tanks; }
            set { tanks = value; }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public bool GameStarted
        {
            get
            {
                return gameStarted;
            }

            set
            {
                gameStarted = value;
            }
        }

        public bool Death
        {
            get
            {
                return death;
            }

            set
            {
                death = value;
            }
        }
    }
}
