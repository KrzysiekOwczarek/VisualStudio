using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ManagerApp
{
    public partial class Form1 : Form
    {
        private Server agentServer = new Server();
        private Client cloudClient = new Client();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Thread serverThread = new Thread(new ThreadStart(agentServer.runServer));
            serverThread.Start();*/

            Thread clientThread = new Thread(new ThreadStart(cloudClient.runClient));
            clientThread.Start();
        }

        private void netFileButton_Click(object sender, EventArgs e)
        {
            
        }


    }
}
