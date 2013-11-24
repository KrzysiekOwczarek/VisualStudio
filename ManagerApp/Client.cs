using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace ManagerApp
{
    public class Client
    {
        const int port = 8001;
        const string ip = "127.0.0.1";
        TcpClient socketForServer;
        NetworkStream networkStream;
        Form1 parent;

        public Client(Form1 parent)
        {
            this.parent = parent;

            try
            {
                socketForServer = new TcpClient(ip, port);
            }
            catch
            {
                Console.WriteLine("Failed to connect to server at {0}:{1}", ip, port);
                return;
            }

           networkStream = socketForServer.GetStream();

        }

        public void runClient()
        {
            
            System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);

            try
            {

                streamWriter.WriteLine("HELLO");
                streamWriter.Flush();

                if (streamReader.ReadLine() == "HELLO")
                {
                    parent.logClient("Connection with CLOUD established!");
                }
                else
                {
                    parent.logClient("CLOUD ERROR...");
                }    
            }
            catch
            {
                parent.logClient("CLOUD unreachable, using last know network configuration...");
            }

            gimmeConfig();

        }

        public void stopClient()
        {

            System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);

            streamWriter.WriteLine("BYE");
            streamWriter.Flush();

            if (streamReader.ReadLine() == "BYE")
                networkStream.Close();
        }

        public void gimmeConfig()
        {

            System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream);
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream);

            try
            {
                streamWriter.WriteLine("GIMME_CONF");
                streamWriter.Flush();

                if (streamReader.ReadLine() == "OK")
                {
                    parent.logClient("Downloading network file from cloud...");

                    List<String> incomingLines = new List<String>();

                    String incomingLine;
                    while ((incomingLine = streamReader.ReadLine()) != "#STOP")
                    {
                        incomingLines.Add(incomingLine);
                    }


                    using (System.IO.StreamWriter file = new System.IO.StreamWriter("network.txt"))
                    {

                        foreach (string line in incomingLines)
                        {
                            file.WriteLine(line);
                        }

                        file.WriteLine("#STOP");
                    }

                    parent.logClient("Network file downloaded...");

                }
                else
                {
                    parent.logClient("Client: Chmura odmawia wyslania pliku network.txt");
                }
            }
            catch
            {
                parent.logError("Client: Pobranie pliku network.txt nieudane");
            }
        }

        public int getNodeNumber()
        {
            int nodes = 0; // CHMURA JAKO ZEROWY

            try
            {
                string[] lines = System.IO.File.ReadAllLines("network.txt");

                foreach (string line in lines)
                {
                    if (line.Contains("#"))
                        nodes++;
                }
            }
            catch
            {
                parent.logError("Client: Brak pliku network.txt");
            }

            return nodes;
        }
    }
}