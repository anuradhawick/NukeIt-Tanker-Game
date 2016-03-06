using NukeIt_Tanker.GameEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This package implments Chain of Responsibilities(COR) design pattern
namespace NukeIt_Tanker.Tokenizer
{
    public abstract class MessageParser
    {
        public abstract bool handleMessageImpl(string message);
        private MessageParser nextHandler;
        protected MainGrid active_grid;
        // Instantiating the message parser
        public MessageParser(MainGrid active_grid)
        {
            this.active_grid = active_grid;
            this.nextHandler = null;
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

        // Getters and setters for the next handler
        public void setNext(MessageParser p)
        {
            this.nextHandler = p;
        }
    }
}
