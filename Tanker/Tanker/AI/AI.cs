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
        public GameAI(MainGrid mg, MessageSender ms)
        {
            this.mg = mg;
            this.ms = ms;
        }

        public void move()
        {
            calculateGraph();
            BaseLogic.updateStats(mg);
            if (BaseLogic.IsScoreLow && mg.Coins.Count > 0)
            {
                MotionLogic.nextMove(ms, mg, g.getNextNode(mg.Coins[CoinLogic.getBestCoin(mg, g)]));
            }
            else if (mg.Tanks.Count > 1 && MotionLogic.shootable(mg, EnemyLogic.getNearestEnemy(mg, g)))
            {
                Console.WriteLine("____________ " + EnemyLogic.getNearestEnemy(mg, g).Player_name + "___IS AIMED_TO_SHOOT");
                ms.shoot();
            }
            else
            {
                Console.WriteLine("____________ " + EnemyLogic.getNearestEnemy(mg, g).Player_name + "___IS AIMED_TO_MOVE");
                MotionLogic.nextMove(ms, mg, g.getNextNode(EnemyLogic.getNearestEnemy(mg, g)));
            }
            
        }
        private void calculateGraph()
        {
            g = new Graph(mg, mg.Playername);
            Dijkstra.run(g);
        }
    }
}
