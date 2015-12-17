using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NukeIt_Tanker.CommManager
{
    class MessageHandler
    {
        Communicator c;
        public MessageHandler()
        {
            c = Communicator.GetInstance();
            ThreadStart ts = new ThreadStart(c.ReceiveData);
            Thread t = new Thread(ts);
            t.Start();
        }

        public void send(string msg)
        {
            Thread thread = new Thread(() => c.SendData(msg));
            thread.Start();
        }
        private void perform_return()
        {

        }
    }
}
