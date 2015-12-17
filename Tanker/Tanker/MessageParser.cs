using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This package implments Chain of Responsibilities(COR) design pattern
namespace NukeIt_Tanker.MessageParser
{
    abstract class MessageParser
    {
        public abstract bool handleMessageImpl(string message);
        private MessageParser nextHandler;
        // Instantiating the message parser
        public MessageParser()
        {
            this.nextHandler = null;
        }
        // Getters and setters for the next handler
        public MessageParser next_handler
        {
            get;
            set;
        }


        public void handleMessage(string message)
        {
            // Handled by this handler
            bool handledByThisNode = this.handleMessageImpl(message);
            // If not grant to next handler
            if (!handledByThisNode && this.nextHandler != null)
            {
                this.nextHandler.handleMessage(message);
            }
        }


    }
}
