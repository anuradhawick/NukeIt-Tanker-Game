﻿using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanker.AI.GraphTools;

namespace Tanker.AI
{





    class Dijkstra
    {
        private Dijkstra()
        {

        }
        public static void run(Graph g)
        {
            Node[,] nodes = g.getNodes();
            Node head = g.getHead();
            HashSet<Node> vertextSet = new HashSet<Node>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //if (nodes[i, j].Type != Components.Stone && nodes[i, j].Type != Components.Water && nodes[i, j].Type != Components.Brick)
                    //{
                        vertextSet.Add(nodes[i, j]);
                    //}
                    //if (nodes[i, j].Type == Components.Empty || nodes[i, j].Type==Components.Tank)
                    //{
                    //    vertextSet.Add(nodes[i, j]);
                    //}
                }
            }
            head.setDist(0);
            while (vertextSet.Count > 0)
            {
                // Getting the vertex with min distance
                int min = Int32.MaxValue;
                Node u = null;
                foreach (Node n in vertextSet)
                {
                    if (n.getDist() < min)
                    {
                        min = n.getDist();
                        u = n;
                    }
                }
                // Remove the discovered vertex
                vertextSet.Remove(u);
                foreach (Node v in u.getNeighbours())
                {
                    // Update minimum distances to each neighbour
                    if (u.getDist() + 1 < v.getDist())
                    {
                        v.setDist(u.getDist() + 1);
                        v.setParent(u);
                    }
                }
            }

        }
    }
}
