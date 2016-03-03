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
        MainGrid mg;
        string player;
        public Graph(MainGrid mg, string player)
        {
            this.mg = mg;
            this.player = player;
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

            foreach (StoneWall itm in mg.StoneWalls.Values.ToList<StoneWall>())
            {
                nodes[(int)itm.Location.X, (int)itm.Location.Y].Type = Components.Stone;
            }

            foreach (BrickWall itm in mg.BrickWalls.Values.ToList<BrickWall>())
            {
                nodes[(int)itm.Location.X, (int)itm.Location.Y].Type = Components.Brick;
            }

            foreach (Waters itm in mg.Waters.Values.ToList<Waters>())
            {
                nodes[(int)itm.Location.X, (int)itm.Location.Y].Type = Components.Water;
            }
            foreach (Tank itm in mg.Tanks.Values.ToList<Tank>())
            {
                if (itm.Player_name == mg.Playername) continue;
                nodes[(int)itm.Location.X, (int)itm.Location.Y].Type = Components.Tank;
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
            foreach (Tank itm in mg.Tanks.Values.ToList<Tank>())
            {
                if (itm.Player_name == player)
                {
                    nodes[(int)itm.Location.X, (int)itm.Location.Y].setDist(0);
                    //Console.WriteLine(nodes[(int)itm.Value.Location.X, (int)itm.Value.Location.Y].getDist());
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
        public Stack<Node> getPathByNode(Node head)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(head);
            int count = 1;
            while (head.getParent() != null)
            {
                count++;
                head = head.getParent();
                stack.Push(head);
                if (count > 100)
                    break;
            }
            return stack;
        }

        public Stack<Node> getPathByEntity(AbstractEntity ent)
        {
            int X = (int)ent.Location.X;
            int Y = (int)ent.Location.Y;
            return getPathByNode(nodes[X, Y]);

        }

        public Vector2 getNextNode(AbstractEntity ent)
        {
            Stack<Node> path = getPathByEntity(ent);
            if (path.Count < 2)
            {
                return mg.Tanks[player].Location;
            }
            path.Pop();
            Node n = path.Pop();
            return new Vector2(n.getX(), n.getY());
        }

        public Vector2 getNextNode(Node head)
        {
            Stack<Node> path = getPathByNode(head);
            if (path.Count < 2)
            {
                return mg.Tanks[player].Location;
            }
            path.Pop();
            Node n = path.Pop();
            return new Vector2(n.getX(), n.getY());
        }
    }
}
