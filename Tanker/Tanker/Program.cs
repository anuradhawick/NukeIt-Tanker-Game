using NukeIt_Tanker.CommManager;
using NukeIt_Tanker.GameEntity;
using NukeIt_Tanker.Tokenizer;
using System;
using System.Collections.Generic;
using Tanker.AI;
using Tanker.AI.GraphTools;

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
                //Console.WriteLine("Testing");
                MainGrid active_grid = new MainGrid();
                //MessageHandler msghandler = new MessageHandler(active_grid);
                //MessageSender msgSender = new MessageSender(msghandler);
                //Console.ReadLine();
                //msgSender.join();
                //Console.WriteLine("Joined");
                MessageParser p1 = new GlobalBroadCastHandler(active_grid);
                MessageParser p2 = new AquirablesHandler(active_grid);
                MessageParser p3 = new MovingAndShootingHandler(active_grid);
                MessageParser p4 = new GameInidiationHandler(active_grid);
                MessageParser p5 = new JoinMessageParser(active_grid);
                MessageParser p6 = new JoinSuccessHandler(active_grid);
                MessageParser p7 = new Finalizer(active_grid);
                p1.setNext(p2);
                p2.setNext(p3);
                p3.setNext(p4);
                p4.setNext(p5);
                p5.setNext(p6);
                p6.setNext(p7);

                p1.handleMessage("I:P2:5,3;1,4;3,6;0,8;2,6;4,8;6,3;5,7;1,3:2,4;6,7;7,2;8,6;2,7;1,8;7,4;8,1;0,3;7,1:4,3;6,8;9,3;0,2;1,7;2,3;5,8;9,8;5,2;7,6#");
                p1.handleMessage("S:P0;0,0;0:P1;0,9;0:P2;9,0;0#");
                p1.handleMessage("C:3,8:16423:1747#");
                //p1.handleMessage("G:P0;0,0;0;0;100;0;0:P1;0,9;0;0;100;0;0:P2;9,0;0;0;100;0;0:5,3,0;1,4,0;3,6,0;0,8,0;2,6,0;4,8,0;6,3,0;5,7,0;1,3,0#");
                //p1.handleMessage("L:2,8:59130#");



                Graph g = new Graph(active_grid, "P0");
                Node[,] ns = g.getNodes();
                Console.WriteLine("Main grid");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(string.Format("{0,5}", ns[i, j].getDist()) + " ");
                    }
                    Console.WriteLine();
                }
                Dijkstra.run(g);
                Console.WriteLine("After Running Dijkstra");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(string.Format("{0,5}", ns[i, j].getDist()) + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Done");
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (ns[i, j].getParent() != null)
                            Console.Write(string.Format("{0,5}", ns[i, j].getParent().getX() + "," + ns[i, j].getParent().getY()) + " ");
                        else
                        {
                            Console.Write(string.Format("{0,5}", "_") + " ");
                        }
                    }
                    Console.WriteLine();
                }
                Stack<Node> path = g.getPathByNode(g.getNodes()[3, 8]);
                //Stack<Node> path = g.getPath(active_grid.getCoin(new Microsoft.Xna.Framework.Vector2(3,8)));
                while (path.Count > 0)
                {
                    Node n = path.Pop();
                    int x = n.getX();
                    int y = n.getY();
                    Console.WriteLine(x + " , " + y);
                }
                //game.Run();
            }
        }
    }
#endif
}

