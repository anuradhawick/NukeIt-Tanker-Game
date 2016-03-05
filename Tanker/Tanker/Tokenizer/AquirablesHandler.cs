using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.Tokenizer
{
    class AquirablesHandler : MessageParser
    {
        public AquirablesHandler(MainGrid active_grid)
            : base(active_grid)
        {

        }
        // Hande the messages related to the life packs or coins
        public override bool handleMessageImpl(string message)
        {
            message = message.Substring(0, message.Length - 1);
            // if the message is no hadled return false
            if (message[0] == 'C' || message[0] == 'L')
            {
                // if the message is related to coins
                if (message[0] == 'C')
                {
                    // These are the data related to the life pack
                    string[] sections = message.Split(':');
                    int[] location = { Int32.Parse(sections[1].Split(',')[0]), Int32.Parse(sections[1].Split(',')[1]) };
                    int timeout = Int32.Parse(sections[2]);
                    int value = Int32.Parse(sections[3]);
                    // Add the coin to the grid and updateUI
                    // To be implemented
                    //Console.WriteLine("Coins");
                    //Console.WriteLine("Location " + location[0] + "," + location[1]);
                    //Console.WriteLine("Timeout " + timeout);
                    //Console.WriteLine("Value " + value);
                    Coin coin = new Coin();
                    coin.Life_time = timeout;
                    coin.Location = new Microsoft.Xna.Framework.Vector2(location[0], location[1]);
                    coin.Value = value;
                    active_grid.addCoin(coin);
                    return true;
                }
                // if the message is related to life packs
                else
                {
                    string[] sections = message.Split(':');
                    int[] location = { Int32.Parse(sections[1].Split(',')[0]), Int32.Parse(sections[1].Split(',')[1]) };
                    int timeout = Int32.Parse(sections[2]);
                    // Add the coin to the grid and updateUI
                    // To be implemented
                    //Console.WriteLine("Life Pack");
                    //Console.WriteLine("Location " + location[0] + "," + location[1]);
                    //Console.WriteLine("Timeout " + timeout);
                    LifePack lp = new LifePack();
                    lp.Life_time = timeout;
                    lp.Location = new Microsoft.Xna.Framework.Vector2(location[0], location[1]);
                    active_grid.addLifePack(lp);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
