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
        private NodeServer nodeServer;
        private Client cloudClient;

        public Form1()
        {
            InitializeComponent();
            //cloudClient = new Client(this);
            nodeServer = new NodeServer(this);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*Thread serverThread = new Thread(new ThreadStart(agentServer.runServer));
            serverThread.Start();*/

            //Thread clientThread = new Thread(new ThreadStart(cloudClient.runClient));
            //clientThread.Start();

            //agentServer.setNodeNumber(cloudClient.getNodeNumber());

            Thread serverThread = new Thread(new ThreadStart(nodeServer.runServer));
            serverThread.Start();
            
        }

        public void logError(String text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(logError), new object[] { text });
                return;
            }
            this.errorLog.Text += text + Environment.NewLine;
        }

        public void logClient(String text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(logClient), new object[] { text });
                return;
            }
            this.cloudClientLog.Text += text + Environment.NewLine;
        }

        public void logServer(String text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(logServer), new object[] { text });
                return;
            }
            this.nodeServerLog.Text += text + Environment.NewLine;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cloudClient.stopClient();
            //Application.Exit();
            //nodeServer.stopServer();
        }

        private void netFileButton_Click(object sender, EventArgs e)
        {
            //cloudClient.gimmeConfig();
        }

        public void updateNodeBox(List<String> nodeList)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<List<String>>(updateNodeBox), new object[] { nodeList });
                return;
            }

            nodeBox.Items.Clear();
            System.Object[] ItemObject = new System.Object[nodeList.Count()];
            int i = 0;
            foreach (String node in nodeList)
            {
                ItemObject[i] = node;
                i++;
            }

            nodeBox.Items.AddRange(ItemObject);

        }
    }
}
