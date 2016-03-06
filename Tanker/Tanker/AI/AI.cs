using Microsoft.Xna.Framework;
using NukeIt_Tanker.CommManager;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanker.AI.CalculationTools;

namespace Tanker.AI
{
    public class GameAI
    {
        private MainGrid mg;
        private MessageSender ms;
        private Graph g;
        public GameAI(MainGrid mg, MessageSender ms)
        {
            this.mg = mg;
            this.ms = ms;
        }

        // Basic AI logic
        public void move()
        {
            calculateGraph();
            if (BaseLogic.IsHealthLow)
            {
                if (findHealth())
                {
                    // this is ok
                }
                else
                {
                    // Escape if at risk
                    if (!escape())
                    {
                        // Cannot excape, then shoot
                        shoot();
                    }
                    else
                    {
                        // This is ok
                    }
                }
            }
            else if (mg.Tanks.Count < 2)
            {
                if (!chaseCoin())
                {
                    // Initiate brick logic
                    breakBrick();
                }
            }
            else if (mg.Tanks.Count > 1)
            {
                //if (ShootingLogic.isDirectShootable(mg))
                //{
                //    shoot();
                //}
                //else
                if (!chaseCoin())
                {
                    if (!breakBrick())
                    {
                        // No bricks either
                        shoot();
                    }
                    else
                    {
                        // This is ok
                    }
                }
                else
                {
                    // This is ok
                }
            }


        }


        // Brick beaking logic
        private bool breakBrick()
        {
            // Check if bricks exist
            if (mg.BrickWalls.ContainsKey(CoinLogic.getBestBrickWall(mg, g)))
            {
                // Shoot if path is blocked by an enemy
                if (ShootingLogic.shootable(mg, mg.BrickWalls[CoinLogic.getBestBrickWall(mg, g)]))
                {
                    ms.shoot();
                    return true;
                }
                else
                {
                    MotionLogic.nextMove(ms, mg, g.getNextNode(mg.BrickWalls[CoinLogic.getBestBrickWall(mg, g)]));
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        // Update the statistics that are required by AI
        private void calculateGraph()
        {
            // Generate the graph
            g = new Graph(mg, mg.Playername);
            // Run Dijkstra to get shortest path for every node
            Dijkstra.run(g);
            // Update statistics
            BaseLogic.updateStats(mg);
        }


        // Search for health packs and save life
        private bool findHealth()
        {
            // Check if there are life packs
            if (mg.Life_packs.Count > 0)
            {
                if (MotionLogic.isCellOccupied(g, g.getNextNode(mg.Life_packs[HealthLogic.getBestLifePack(mg, g)])))
                {
                    // Shoot if cell is occupied
                    if (ShootingLogic.isDirectShootable(mg))
                    {
                        ms.shoot();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Move if the path is free
                else if (mg.Tanks[mg.Playername].Location != g.getNextNode(mg.Life_packs[HealthLogic.getBestLifePack(mg, g)]))
                {
                    MotionLogic.nextMove(ms, mg, g.getNextNode(mg.Life_packs[HealthLogic.getBestLifePack(mg, g)]));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Shooting logic
        private bool shoot()
        {
            if (mg.Tanks.Count > 1)
            {
                // if shootable without any turning
                if (ShootingLogic.isDirectShootable(mg))
                {
                    ms.shoot();
                    return true;
                }
                // Move if not
                else
                {
                    MotionLogic.nextMove(ms, mg, g.getNextNode(ShootingLogic.getNearestEnemy(mg, g)));
                    return true;
                }
            }
            return false;
        }

        // Coin chasing logic
        private bool chaseCoin()
        {
            // only works if coins are available
            if (mg.Coins.Count > 0)
            {
                if (MotionLogic.isCellOccupied(g, g.getNextNode(mg.Coins[CoinLogic.getBestCoin(mg, g)])))
                {
                    // If the next cell is occupied by someone try shooting
                    if (ShootingLogic.isDirectShootable(mg))
                    {
                        ms.shoot();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // If there exit a direct path for the coin
                else if (mg.Tanks[mg.Playername].Location != g.getNextNode(mg.Coins[CoinLogic.getBestCoin(mg, g)]))
                {
                    MotionLogic.nextMove(ms, mg, g.getNextNode(mg.Coins[CoinLogic.getBestCoin(mg, g)]));
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }

        // Escape if vulnerable for an attack
        private bool escape()
        {
            // Check is we need to escape or it's fine
            if (ShootingLogic.shouldEscape(mg, g))
            {
                MotionLogic.nextMove(ms, mg, g.getNextNode(g.getNodes()[(int)ShootingLogic.getNearestSafePlace(mg, g).X, (int)ShootingLogic.getNearestSafePlace(mg, g).Y]));
                return true;
            }
            return false;
        }

    }
}
