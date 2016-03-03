using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.Tokenizer
{
    class GameInidiationHandler : MessageParser
    {
        private string player_name;
        private List<int[]> bricks;
        private List<int[]> stone;
        private List<int[]> water;
        private string[] message_components;
        private string[] temp;

        public GameInidiationHandler(MainGrid active_grid)
            : base(active_grid)
        {
            bricks = new List<int[]>();
            stone = new List<int[]>();
            water = new List<int[]>();
        }
        public override bool handleMessageImpl(string message)
        {
            if (message[0] != 'I')
            {
                return false;
            }
            else
            {
                message = message.Substring(0, message.Length - 1);
                message_components = message.Split(':');
                // Decoding player name
                player_name = message_components[1];
                // Decoding brick locations
                temp = message_components[2].Split(';');
                Console.WriteLine("Game initiation handler player name is "+player_name);
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    bricks.Add(cordinate);
                    Console.WriteLine("Brick " + cordinate[0] + "," + cordinate[1]);
                    BrickWall br = new BrickWall();
                    br.Location = new Microsoft.Xna.Framework.Vector2(cordinate[0], cordinate[1]);
                    br.Damage = 0;
                    this.active_grid.Playername = player_name;
                    lock (active_grid.BrickWalls)
                    {
                        this.active_grid.addBrickWall(br);
                    }
                }
                // Decoding stone locations
                temp = message_components[3].Split(';');
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    stone.Add(cordinate);
                    Console.WriteLine("Stone " + cordinate[0] + "," + cordinate[1]);
                    StoneWall st = new StoneWall();
                    st.Location = new Microsoft.Xna.Framework.Vector2(cordinate[0], cordinate[1]);
                    lock (active_grid.StoneWalls)
                    {
                        active_grid.addStoneWall(st);
                    }
                    
                }
                // Decoding water locations
                temp = message_components[4].Split(';');
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    water.Add(cordinate);
                    Console.WriteLine("Water " + cordinate[0] + "," + cordinate[1]);
                    Waters wt = new Waters();
                    wt.Location = new Microsoft.Xna.Framework.Vector2(cordinate[0], cordinate[1]);
                    lock (active_grid.Waters)
                    {
                        active_grid.addWaters(wt);
                    }                    
                }

                // Do the required mechanism here
                return true;
            }
        }
    }
}
