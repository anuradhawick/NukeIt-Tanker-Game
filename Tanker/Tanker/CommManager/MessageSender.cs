using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.CommManager
{
    class MessageSender
    {
        MessageHandler mh;
        bool canSend = true;
        public MessageSender(MessageHandler i)
        {
            mh = i;
        }

        public void join()
        {
            mh.send("JOIN#");
        }

        public void up()
        {
            mh.send("UP#");
        }

        public void down()
        {
            mh.send("DOWN#");
        }

        public void left()
        {
            mh.send("LEFT#");
        }

        public void right()
        {
            mh.send("RIGHT#");
        }

        public void shoot()
        {
            mh.send("SHOOT#");
        }
    }
}
