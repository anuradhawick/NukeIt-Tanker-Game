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

        public GameInidiationHandler()
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
                Console.WriteLine("Game initiation handler");
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    bricks.Add(cordinate);
                    Console.WriteLine("Brick " + cordinate[0] + "," + cordinate[1]);
                }
                // Decoding stone locations
                temp = message_components[3].Split(';');
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    stone.Add(cordinate);
                    Console.WriteLine("Stone " + cordinate[0] + "," + cordinate[1]);
                }
                // Decoding water locations
                temp = message_components[4].Split(';');
                foreach (string s in temp)
                {
                    int[] cordinate = { Int32.Parse(s.Split(',')[0]), Int32.Parse(s.Split(',')[1]) };
                    water.Add(cordinate);
                    Console.WriteLine("Water " + cordinate[0] + "," + cordinate[1]);
                }

                // Do the required mechanism here
                return true;
            }
        }
    }
}
