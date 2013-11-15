using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace ManagerApp
{
    class Server
    {

        const int port = 8001;
        const string ip = "127.0.0.1";
        const int maxBuffer = 100;

        public Server()
        {

        }

        public void runServer()
	    {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                TcpListener tcpListener = new TcpListener(ipAddress, port);
                tcpListener.Start();
 
                Console.WriteLine(string.Format("The server is running at port {0}..", port));
                Console.WriteLine(string.Format("The local End point is: {0}", tcpListener.LocalEndpoint));
 
                Console.WriteLine("\nWaiting for connection..");
                using (Socket socket = tcpListener.AcceptSocket())
                {
                    Console.WriteLine(string.Format("Connection accepted from: {0}", socket.RemoteEndPoint));

                    
 
                    byte[] receiveBuffer = new byte[maxBuffer];
                    int usedBuffer = socket.Receive(receiveBuffer);
 
                    Console.WriteLine("\nRecieved..");
                    for (int i = 0; i < usedBuffer; i++)
                        Console.Write(Convert.ToChar(receiveBuffer[i]));
 
                    Console.WriteLine("\n\nSent acknowledgement");
                    socket.Send(new ASCIIEncoding().GetBytes("The string was recieved by the server."));
 
                    Console.ReadLine();
                }
 
                tcpListener.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error: {0}", e.StackTrace));
            }   

	    }

    }

}


