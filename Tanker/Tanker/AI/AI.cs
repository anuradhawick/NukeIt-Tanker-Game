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
            shoot();
            //if (!chaseCoin())
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine("Soot itttttt=====");
            //    }
            //    shoot();
            //}
            if (BaseLogic.IsHealthLow)
            {
                // Chase for health
            }
            else if (BaseLogic.IsScoreLow)
            {
                
                // Chase for coins
                
            }
            else
            {
                //shoot();
            }

        }
        private void calculateGraph()
        {
            g = new Graph(mg, mg.Playername);
            Dijkstra.run(g);
            BaseLogic.updateStats(mg);
        }

        private bool shoot()
        {
            if (mg.Tanks.Count > 1)
            {
                if (MotionLogic.isDirectShootable(mg, g))
                {
                    ms.shoot();
                    return true;
                }
                else
                {
                    MotionLogic.nextMove(ms, mg, g.getNextNode(EnemyLogic.getNearestEnemy(mg, g)));
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
                    if (MotionLogic.isDirectShootable(mg, g))
                    {
                        ms.shoot();
                        return true;
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


    }
}
