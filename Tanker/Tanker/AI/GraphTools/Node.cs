using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanker.AI.GraphTools
{
    /*
    Building unit of the game graph
    */
    public class Node
    {
        private Node parent;
        private Components type;
        private List<Node> neighbours;
        private int x, y;
        private int dist = 99999;

        public void addNeighbour(Node n)
        {
            neighbours.Add(n);
            parent = null;
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
        public Components Type
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
            parent = n;
        }
        public Node getParent()
        {
            return parent;
        }

        public void setDist(int i)
        {
            dist = i;
        }

        public int getDist()
        {
            return dist;
        }
    }
}
