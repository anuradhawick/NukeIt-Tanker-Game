﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NukeIt_Tanker.Tokenizer
{
    class Finalizer : MessageParser
    {
        public override bool handleMessageImpl(string message)
        {
            if (message == "GAME_FINISHED#")
            {
                // The Game has ended
                // Update the UI
                Console.WriteLine("Game finished parsed");
                return true;
            }
            return false;
        }
    }
}
