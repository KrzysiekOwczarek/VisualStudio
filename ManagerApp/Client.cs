using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ManagerApp
{
    class Client
    {
        const int port = 8001;
        const string ip = "127.0.0.1";
        const int maxBuffer = 100;

        public Client()
        {

        }

        public void runClient()
        {
            try
            {
                using (TcpClient tcpClient = new TcpClient())
                {
                    Console.WriteLine("Connecting..");
                    tcpClient.Connect(ip, port);
                    Console.WriteLine("Connected");
 
                    Console.Write("\nEnter the string to be transmitted: ");
                    String inputString = "TEST";
                    Stream networkStream = tcpClient.GetStream();
 
                    byte[] sendBuffer = new ASCIIEncoding().GetBytes(inputString);
                    Console.WriteLine("Transmitting..\n");
                    networkStream.Write(sendBuffer, 0, sendBuffer.Length);
 
                    Console.WriteLine("Receive acknowledgement from server..");
                    byte[] receiveBuffer = new byte[maxBuffer];
                    int k = networkStream.Read(receiveBuffer, 0, maxBuffer);
 
                    for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(receiveBuffer[i]));
 
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error: {0}", e.StackTrace));
            }
        }
    }
}
