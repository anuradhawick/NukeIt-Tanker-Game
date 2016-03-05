using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System.Collections.Generic;
using System.Linq;
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
            // Setting up Component types for each node
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
            // Setting up neighbour nodes for each node
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    // if waters, or stone walls or brick wall it does not have neighbours but has parents
                    if (nodes[i, j].Type == Components.Water || nodes[i, j].Type == Components.Stone || nodes[i, j].Type == Components.Brick)
                    {
                        continue;
                    }
                    else
                    {
                        // up
                        if (MotionLogic.isValidCell(i - 1, j))
                        {
                            nodes[i, j].addNeighbour(nodes[i - 1, j]);
                        }
                        // down
                        if (MotionLogic.isValidCell(i + 1, j))
                        {
                            nodes[i, j].addNeighbour(nodes[i + 1, j]);
                        }
                        // right
                        if (MotionLogic.isValidCell(i, j + 1))
                        {
                            nodes[i, j].addNeighbour(nodes[i, j + 1]);
                        }
                        // left
                        if (MotionLogic.isValidCell(i, j - 1))
                        {
                            nodes[i, j].addNeighbour(nodes[i, j - 1]);
                        }
                    }
                }
            }
            // Set distance to our player as zero which is the head
            foreach (Tank itm in mg.Tanks.Values.ToList<Tank>())
            {
                if (itm.Player_name == player)
                {
                    nodes[(int)itm.Location.X, (int)itm.Location.Y].setDist(0);
                }
            }
            head = nodes[(int)mg.Tanks[player].Location.X, (int)mg.Tanks[player].Location.Y];
        }
        public Node[,] getNodes()
        {
            return nodes;
        }

        public Node getHead()
        {

            return head;

        }


        // Get path for a node
        public Stack<Node> getPathByNode(Node node)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(node);
            while (node.getParent() != null)
            {
                node = node.getParent();
                stack.Push(node);
            }
            return stack;
        }

        // Get path for an entity
        public Stack<Node> getPathByEntity(AbstractEntity ent)
        {
            int X = (int)ent.Location.X;
            int Y = (int)ent.Location.Y;
            return getPathByNode(nodes[X, Y]);

        }

        // Get next node for an entity
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
        // Overload of the above method
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
