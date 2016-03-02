using NukeIt_Tanker.CommManager;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private Graph calculateGraph(MainGrid mg)
        {
            Graph g = new Graph(mg, mg.Playername);
            Dijkstra.run(g);
            return g;

        }
    }
}
