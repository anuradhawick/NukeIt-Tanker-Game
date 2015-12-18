using Microsoft.Xna.Framework;
using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanker.AI
{
    class PathFinder
    {
        List<Vector2> openList;
        public PathFinder(MainGrid active_grid)
        {
            openList = new List<Vector2>();
        }

        private void runAStar(Vector2 start, Vector2 end)
        {
            openList.Add(start);
            while (true)
            {
                
            }
        }

        static private bool ValidCoordinates(int x, int y)
        {
            // Our coordinates are constrained between 0 and 14.
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

    }

    enum SquareContent
    {
        Empty,
        Water,
        Contestant,
        Brick,
        Stone,
        Coin,
        LifePack
    };
}
