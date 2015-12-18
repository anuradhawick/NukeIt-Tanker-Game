using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanker.AI.GraphTools
{
    class Node
    {
        Node parent;
        Components type;
        List<Node> neighbours;
        int x, y;
        int dist;

        public void addNeighbour(Node n)
        {
            neighbours.Add(n);
            parent = null;
            dist = 99999;
        }

        public List<Node> getNeighbours()
        {
            return neighbours;
        }



        public int getY()
        {
            return y;
        }
        public void setY(int i)
        {
            y = i;
        }

        public int getX()
        {
            return x;
        }

        public void setX(int i)
        {
            x = i;
        }
        internal Components Type
        {
            get { return type; }
            set { type = value; }
        }
        public Node()
        {
            neighbours = new List<Node>();
        }

        public void setParent(Node n)
        {
            this.parent = n;
        }
        public Node getParent()
        {
            return this.parent;
        }

        public void setDist(int i)
        {
            this.dist = i;
        }

        public int getDist()
        {
            return this.dist;
        }
    }
}
