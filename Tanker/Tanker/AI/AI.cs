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
    class GameAI
    {
        private MainGrid mg;
        private MessageSender ms;
        private Graph g;
        //private List
        public GameAI(MainGrid mg, MessageSender ms)
        {
            this.mg = mg;
            this.ms = ms;
        }

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

        private bool breakBrick()
        {
            if (mg.BrickWalls.ContainsKey(CoinLogic.getBestBrickWall(mg, g)))
            {
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

        private void calculateGraph()
        {
            g = new Graph(mg, mg.Playername);
            Dijkstra.run(g);
            BaseLogic.updateStats(mg);
        }

        private bool findHealth()
        {
            if (mg.Life_packs.Count > 0)
            {
                if (MotionLogic.isCellOccupied(g, g.getNextNode(mg.Life_packs[HealthLogic.getBestLifePack(mg, g)])))
                {
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

        private bool shoot()
        {
            if (mg.Tanks.Count > 1)
            {
                if (ShootingLogic.isDirectShootable(mg))
                {
                    ms.shoot();
                    //Console.WriteLine("Contains this many tanks"+mg.Tanks.Count);
                    return true;
                }
                else
                {
                    MotionLogic.nextMove(ms, mg, g.getNextNode(ShootingLogic.getNearestEnemy(mg, g)));
                    //Console.WriteLine("AIMED TO KILL " + EnemyLogic.getNearestEnemy(mg, g).Player_name + "========= TO" + g.getNextNode(EnemyLogic.getNearestEnemy(mg, g)).X + "," + g.getNextNode(EnemyLogic.getNearestEnemy(mg, g)).Y + "FROM " + mg.Tanks[mg.Playername].Location.X + "," + mg.Tanks[mg.Playername].Location.X);
                    return true;
                }
            }
            return false;
        }

        private bool chaseCoin()
        {
            if (mg.Coins.Count > 0)
            {
                if (MotionLogic.isCellOccupied(g, g.getNextNode(mg.Coins[CoinLogic.getBestCoin(mg, g)])))
                {
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

        private bool escape()
        {
            if (ShootingLogic.shouldEscape(mg, g))
            {
                MotionLogic.nextMove(ms, mg, g.getNextNode(g.getNodes()[(int)ShootingLogic.getNearestSafePlace(mg, g).X, (int)ShootingLogic.getNearestSafePlace(mg, g).Y]));
                return true;
            }
            return false;
        }

    }
}
