using NukeIt_Tanker.GameEntity;
using NukeIt_Tanker.Tokenizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NukeIt_Tanker.CommManager
{
    class Communicator
    {
        #region "Variables"
        private NetworkStream clientStream; //Stream - outgoing
        private TcpClient client; //To talk back to the client
        private BinaryWriter writer; //To write to the clients

        private NetworkStream serverStream; //Stream - incoming        
        private TcpListener listener; //To listen to the clinets        
        public string reply = ""; //The message to be written

        private static Communicator comm = new Communicator();

        static MessageParser p1;
        static MessageParser p2;
        static MessageParser p3;
        static MessageParser p4;
        static MessageParser p5;
        static MessageParser p6;
        static MessageParser p7;
        #endregion

        private Communicator()
        {

        }

        public static Communicator GetInstance(MainGrid active_grid)
        {
            p1 = new GlobalBroadCastHandler(active_grid);
            p2 = new AquirablesHandler(active_grid);
            p3 = new MovingAndShootingHandler(active_grid);
            p4 = new GameInidiationHandler(active_grid);
            p5 = new JoinMessageParser(active_grid);
            p6 = new JoinSuccessHandler(active_grid);
            p7 = new Finalizer(active_grid);
            p1.setNext(p2);
            p2.setNext(p3);
            p3.setNext(p4);
            p4.setNext(p5);
            p5.setNext(p6);
            p6.setNext(p7);
            return comm;
        }

        public void ReceiveData()
        {
            bool errorOcurred = false;
            Socket connection = null; //The socket that is listened to       
            try
            {
                //Creating listening Socket
                this.listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);
                //Starts listening
                this.listener.Start();
                //Establish connection upon client request
                while (true)
                {
                    //connection is connected socket
                    //if (!listener.Pending())
                    //{
                    //    Thread.Sleep(500);
                    //    continue;
                    //}
                    connection = listener.AcceptSocket();
                    
                    if (connection.Connected)
                    {
                        
                        //To read from socket create NetworkStream object associated with socket
                        this.serverStream = new NetworkStream(connection);

                        SocketAddress sockAdd = connection.RemoteEndPoint.Serialize();
                        string s = connection.RemoteEndPoint.ToString();
                        List<Byte> inputStr = new List<byte>();

                        int asw = 0;
                        while (asw != -1)
                        {
                            asw = this.serverStream.ReadByte();
                            inputStr.Add((Byte)asw);
                        }

                        reply = Encoding.UTF8.GetString(inputStr.ToArray());
                        this.serverStream.Close();
                        string ip = s.Substring(0, s.IndexOf(":"));
                        int port = 7000;
                        try
                        {
                            string ss = reply.Substring(0, reply.IndexOf(";"));
                            port = Convert.ToInt32(ss);
                        }
                        catch (Exception)
                        {
                            port = 7000;
                        }
                        Console.WriteLine("Received: " + reply.Substring(0, reply.Length - 1));
                        p1.handleMessage(reply.Substring(0, reply.Length - 1));

                    }
                }
            }
            catch (Exception e)
            {
                //System.IO.File.WriteAllText(@"C:\Writeline.txt",e.StackTrace);
                //Console.WriteLine("Communication (RECEIVING) Failed! \n " + e.StackTrace);
                errorOcurred = true;
                return;
            }
            finally
            {
                if (connection != null)
                    if (connection.Connected)
                        connection.Close();
                if (errorOcurred)
                    this.ReceiveData();
            }
        }

        public void SendData(string str)
        {
            //Opening the connection
            this.client = new TcpClient();

            try
            {
                if (true)
                {

                    this.client.Connect("127.0.0.1", 6000);

                    if (this.client.Connected)
                    {
                        //To write to the socket
                        this.clientStream = client.GetStream();

                        //Create objects for writing across stream
                        this.writer = new BinaryWriter(clientStream);
                        Byte[] tempStr = Encoding.ASCII.GetBytes(str);

                        //writing to the port         
                        Console.WriteLine("Sent: " + str);
                        this.writer.Write(tempStr);
                        this.writer.Close();
                        this.clientStream.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Err \n" + e.StackTrace);
            }
            finally
            {
                this.client.Close();
            }
        }
    }
}
