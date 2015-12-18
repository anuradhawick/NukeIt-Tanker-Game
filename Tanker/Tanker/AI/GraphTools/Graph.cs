using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tanker.AI.GraphTools;

namespace Tanker.AI
{
    class Graph
    {
        Node[,] nodes;
        Node head;
        public Graph(MainGrid mg, string player)
        {
            nodes = new Node[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    nodes[i, j] = new Node();
                    nodes[i, j].Type = Components.Empty;
                    nodes[i, j].setX(i);
                    nodes[i, j].setY(j);
                }
            }
            
            foreach (KeyValuePair<Vector2, StoneWall> itm in mg.StoneWalls)
            {
                nodes[(int)itm.Value.Location.X, (int)itm.Value.Location.Y].Type = Components.Stone;
            }

            foreach (KeyValuePair<Vector2, BrickWall> itm in mg.BrickWalls)
            {
                nodes[(int)itm.Value.Location.X, (int)itm.Value.Location.Y].Type = Components.Brick;
            }

            foreach (KeyValuePair<Vector2, Waters> itm in mg.Waters)
            {
                nodes[(int)itm.Value.Location.X, (int)itm.Value.Location.Y].Type = Components.Water;
            }
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // up
                    if (isValidCell(i - 1, j) && nodes[i - 1, j].Type == Components.Empty)
                    {
                        nodes[i, j].addNeighbour(nodes[i - 1, j]);
                    }
                    // down
                    if (isValidCell(i + 1, j) && nodes[i + 1, j].Type == Components.Empty)
                    {
                        nodes[i, j].addNeighbour(nodes[i + 1, j]);
                    }
                    // right
                    if (isValidCell(i, j + 1) && nodes[i, j + 1].Type == Components.Empty)
                    {
                        nodes[i, j].addNeighbour(nodes[i, j + 1]);
                    }
                    // left
                    if (isValidCell(i, j - 1) && nodes[i, j - 1].Type == Components.Empty)
                    {
                        nodes[i, j].addNeighbour(nodes[i, j - 1]);
                    }
                }
            }
            foreach (KeyValuePair<string, Tank> itm in mg.Tanks)
            {
                if (itm.Key == player)
                {
                    Console.WriteLine("Here");
                    nodes[(int)itm.Value.Location.X, (int)itm.Value.Location.Y].setDist(0);
                    Console.WriteLine(nodes[(int)itm.Value.Location.X, (int)itm.Value.Location.Y].getDist());
                }
            }
            this.head = nodes[(int)mg.Tanks[player].Location.X, (int)mg.Tanks[player].Location.Y];
        }
        public Node[,] getNodes()
        {
            return this.nodes;
        }

        public Node getHead()
        {

            return this.head;

        }


        // Check if a cell is in the grid
        private Boolean isValidCell(int x, int y)
        {
            if (x < 0)
            {
                return false;
            }
            if (y < 0)
            {
                return false;
            }
            if (x > 9)
            {
                return false;
            }
            if (y > 9)
            {
                return false;
            }
            return true;
        }
        public Stack<Node> getPath(Node head)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(head);
            while (head.getParent() != null)
            {
                head = head.getParent();
                stack.Push(head);
            }
            return stack;
        }
    }
}
