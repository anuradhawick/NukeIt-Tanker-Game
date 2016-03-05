namespace NukeIt_Tanker.CommManager
{
    /*
    Implementation of the basic 5 messages that are handled by the server
    */
    class MessageSender
    {
        MessageHandler mh;
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
