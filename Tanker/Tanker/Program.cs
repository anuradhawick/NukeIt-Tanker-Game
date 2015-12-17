using System;

namespace Tanker
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
              //  Console.WriteLine("Testing");
                game.Run();
            }
        }
    }
#endif
}

