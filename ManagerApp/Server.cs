using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ManagerApp
{
    public class Server
    {
        const int port = 8002;
        const string ip = "127.0.0.1";
        static TcpListener tcpListener;
        static Form1 parent;
        int nodeNumber;

        public Server(Form1 form)
        {
            parent = form;
        }

        static void Listeners()
        {
            while (true)
            {
                Socket socketForClient = tcpListener.AcceptSocket();
                if (socketForClient.Connected)
                {
                    Console.WriteLine("Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
                    NetworkStream networkStream = new NetworkStream(socketForClient);
                    System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
                    System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream);

                   
                    while (true)
                    {
                        string theString = streamReader.ReadLine();

                        if (theString == "HELLO")
                        {
                            parent.logServer("Client "+ streamReader.ReadLine() + " says HELLO");
                            streamWriter.WriteLine("HELLO");
                            streamWriter.Flush();
                        }
                        else if (theString == "GIMME_CONF")
                        {
                            streamWriter.WriteLine("OK");
                            streamWriter.Flush();

                            try
                            {
                                string[] lines = System.IO.File.ReadAllLines("network.txt");

                                foreach (string line in lines)
                                {
                                    // Use a tab to indent each line of the file.
                                    streamWriter.WriteLine(line);
                                }

                                streamWriter.WriteLine("#STOP");
                                streamWriter.Flush();
                            }
                            catch
                            {
                                parent.logError("Server: Brak pliku network.txt");
                            }
                            parent.logServer("CONF sent to CLIENT!");
                        }
                        else if (theString == "BYE")
                        {
                            streamWriter.WriteLine("BYE");
                            streamWriter.Flush();
                            parent.logServer("Client DISCONNECTED");
                            break;
                        }


                    }
                    streamReader.Close();
                    networkStream.Close();
                    streamWriter.Close();

                }
                socketForClient.Close();

            }
           
        }

        public void runServer()
        {
            IPAddress ipAddress = IPAddress.Parse(ip);
            tcpListener = new TcpListener(ipAddress, port);

            tcpListener.Start();
            //Console.WriteLine("************This is Server program************");
            //Console.WriteLine("How many clients are going to connect to this server?:");
            //int numberOfClientsYouNeedToConnect = int.Parse(Console.ReadLine());
            // (int i = 0; i < nodeNumber; i++)
            //{
                Thread newThread = new Thread(new ThreadStart(Listeners));
                newThread.Start();
                //parent.logServer("THREAD #"+i+"STARTED");
            //}
        }

        public void setNodeNumber(int nodeNumber)
        {
            this.nodeNumber = nodeNumber;
        }

    }
}