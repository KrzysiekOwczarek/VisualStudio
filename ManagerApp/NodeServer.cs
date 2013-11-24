using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace ManagerApp
{
    class NodeServer
    {
        Form1 parent;
        List<String> connetedNodes = new List<String>();

        const int port = 8002;
        const string ip = "127.0.0.1";
        static TcpListener tcpListener;

        //TcpListener serverSocket = new TcpListener(8002);
        //TcpClient clientSocket = default(TcpClient);

        public NodeServer(Form1 parent)
        {
            this.parent = parent;
        }

        public void runServer()
        {

            IPAddress ipAddress = IPAddress.Parse(ip);
            tcpListener = new TcpListener(ipAddress, port);

            int counter = 0;

            //serverSocket.Start();

            tcpListener.Start();
            Console.WriteLine(" >> " + "Server Started");

            counter = 0;
            Socket socketForClient;
            while (true)
            {
                counter += 1;
                //clientSocket = serverSocket.AcceptTcpClient();

                socketForClient = tcpListener.AcceptSocket();
                if (socketForClient.Connected)
                {
                    Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
                    handleClient client = new handleClient(this);
                    //client.startClient(clientSocket, Convert.ToString(counter));

                    client.startClient(socketForClient, Convert.ToString(counter));
                }
               
               
            }
            socketForClient.Close();
            //clientSocket.Close();
            //serverSocket.Stop();
            //Console.WriteLine(" >> " + "exit");
            //Console.ReadLine();
        }

        public Form1 getParent()
        {
            return parent;
        }

        public List<String> getConnectedNodes()
        {
            return connetedNodes;
        }

        public class handleClient
        {
            NodeServer parent;
            TcpClient clientSocket = new TcpClient();
            Socket socket;
            string clNo;
            string clName;

            public handleClient(NodeServer parent)
            {
                this.parent = parent;
            }

            public void startClient(Socket inClientSocket, string clineNo)
            {
                this.socket = inClientSocket;
                this.clientSocket.Client = inClientSocket;
                this.clNo = clineNo;
                Thread ctThread = new Thread(doChat);
                ctThread.Start();
            }

            private void doChat()
            {
                
                NetworkStream networkStream = clientSocket.GetStream();
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);
                System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream);

                while ((true))
                {
                    try
                    {
                       
                        string theString = streamReader.ReadLine();

                        if (theString == "HELLO")
                        {
                            String nodeName = streamReader.ReadLine();
                            clName = nodeName;

                            parent.getConnectedNodes().Add(nodeName);
                            parent.getParent().updateNodeBox(parent.getConnectedNodes());

                            parent.getParent().logServer("Client " + nodeName + " on socket " + socket.RemoteEndPoint + " says HELLO");
                            streamWriter.WriteLine("HELLO");
                            streamWriter.Flush();
                        }
                        else if (theString == "CONNECT_TO")
                        {
                            String enClient = streamReader.ReadLine();
                            parent.getParent().logServer("CLIENT NAME: " + clName + " REQUEST CONNECTION TO CLIENT NAME: " + enClient);

                            
                        }
                        else if (theString == "BYE")
                        {

                            String nodeName = streamReader.ReadLine();
                            parent.getConnectedNodes().Remove(nodeName);
                            parent.getParent().updateNodeBox(parent.getConnectedNodes());

                            streamWriter.WriteLine("BYE");
                            streamWriter.Flush();
                            parent.getParent().logServer("Client "+ nodeName + " DISCONNECTED");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(" >> " + ex.ToString());
                    }
                }

            
            }
        } 
    }
}
