using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NukeIt_Tanker.CommManager
{
    // The class that handles incomming messages from the communicator and update the main grid
    public class MessageHandler
    {
        Communicator c;
        // Receive in a seperate thread
        public MessageHandler(MainGrid active_grid)
        {
            c = Communicator.GetInstance(active_grid);
            ThreadStart ts = new ThreadStart(c.ReceiveData);
            Thread t = new Thread(ts,50000000);
            t.Start();
        }
        // Send in the same thread
        public void send(string msg)
        {
            c.SendData(msg);
        }
    }
}
