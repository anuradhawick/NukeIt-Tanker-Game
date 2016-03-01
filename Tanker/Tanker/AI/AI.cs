using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanker.AI
{
    class GameAI
    {
        public GameAI(MainGrid mg)
        {

        }

        private Graph calculateGraph(MainGrid mg)
        {
            Graph g = new Graph(mg, mg.Playername);
            Dijkstra.run(g);
            return g;

        }
    }
}
