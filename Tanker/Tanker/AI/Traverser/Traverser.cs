using NukeIt_Tanker.CommManager;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanker.AI.GraphTools;

namespace Tanker.AI.Traverser
{
    class Traverser
    {
        private MainGrid main_grid;
        private MessageSender ms;
        private string player_name;
        public Traverser(MainGrid mg, MessageSender msg, string player)
        {
            this.main_grid = mg;
            this.ms = msg;
            this.player_name = player;
        }

        public void move()
        {
            Graph g = new Graph(main_grid, player_name);
            Node[,] ns = g.getNodes();
            Dijkstra.run(g);
        }
    }
}
