using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.Tokenizer
{
    class JoinSuccessHandler : MessageParser
    {
        int[] location;
        string[] messageComponents;
        string[] sub_components;
        string player_name;
        int direction;

        public JoinSuccessHandler(MainGrid active_grid)
            : base(active_grid)
        {

        }
        public override bool handleMessageImpl(string message)
        {
            if (message[0] != 'S')
            {
                return false;
            }
            else
            {                
                message = message.Substring(0, message.Length - 1);
                messageComponents = message.Split(':');
                for (int i = 1; i < messageComponents.Length; i++)
                {
                    sub_components = messageComponents[i].Split(';');
                    player_name = sub_components[0];
                    location = new int[] { Int32.Parse((sub_components[1].Split(','))[0]), Int32.Parse((sub_components[1].Split(','))[1]) };
                    direction = Int32.Parse(sub_components[2]);
                    //Handle the case and return true
                    //Console.WriteLine("Join success player " + player_name);
                    //Console.WriteLine("Location " + location[0] + "," + location[1]);
                    //Console.WriteLine("Direction " + direction);
                    Tank tk = new Tank();
                    tk.Direction = direction;
                    tk.Health = 100;
                    tk.Location = new Microsoft.Xna.Framework.Vector2(location[0], location[1]);
                    tk.Player_name = player_name;
                    tk.Points = 0;
                    tk.Whether_shot = false;
                    active_grid.addTank(tk);
                }
                active_grid.GameStarted = true;
                return true;
            }
        }
    }
}
