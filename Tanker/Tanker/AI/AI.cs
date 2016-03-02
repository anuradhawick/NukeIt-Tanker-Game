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
            Vector2 target;
            if (mg.Coins.Count > 0)
            {
                target = g.getNextNode(mg.Coins[CoinLogic.getBestCoin(mg)]);
                MotionLogic.nextMove(ms, mg, target);
                Console.WriteLine(target.X + " ______ " + target.Y);
            }
        }
        private void calculateGraph()
        {
            g = new Graph(mg, mg.Playername);
            Dijkstra.run(g);
        }
    }
}
