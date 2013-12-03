using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerX
{
    public partial class ManagerX : Form
    {
        //Default Settings and Form properties
        private IPAddress address; //Adres na którym server nasłuchuje
        private Int32 port; //port początkowy
        private TcpListener serverSocket; //gniazdko sieciowe na połaczenia TCP (prawie jak ServerSocket w javie)
        private TcpClient clientSocket; //przedstawienie klienta po stronie servera (w prawie jak Socket w javie)
        private Thread ConnThread; //wątek służący do odbierania połączeń
        private List<Connection> clientList;//lista klientów (byłych i obecnych, rozłączeni nie są usówani tylko mają status disconnected)
        private List<Request> requestList;
        private int iD; //ID nowego klienta
        public bool isRunning { get; private set; } //info czy server chodzi
        public int connected; //ilość podłączonych klientów (aktywnych, nie tych co już zerwali połączenie)

        //auxiliary variables
        private Connection thisClient;
        private String srvMsg;

        public ManagerX()
        {
            InitializeComponent();
            //txtIP.Text = IPAddress.Any.ToString(); //nasluchuj na każdym interfejsie
            txtIP.Text = "127.0.0.1";
            txtPort.Text = 8002.ToString();

            txtIP.ReadOnly = true;
            txtPort.ReadOnly = true;

            txtPortIn.ReadOnly = true;
            txtVpiIn.ReadOnly = true;
            txtVciIn.ReadOnly = true;
            txtPortOut.ReadOnly = true;
            txtVpiOut.ReadOnly = true;
            txtVciOut.ReadOnly = true;
            butAdd.Enabled = false;
            butRemove.Enabled = false;

            butClearNode.Enabled = false;

            butEstablished.Enabled = false;
            butDisconnect.Enabled = false;
        }

        delegate void initCallback();
        private void init() //odpal server (nie Formę, forma juz jest, teraz ogólnie mechanizm servera)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new initCallback(init), new object[] { });
            }
            else
            {
                try
                {
                    address = IPAddress.Parse(txtIP.Text); //parsuj to co w pudełku
                    port = Int32.Parse(txtPort.Text); //
                    iD = 0; //nie ma klientów
                    clientList = new List<Connection>(); //tworzenie nowego kontenera na klienty (LOL nie klientów)
                    requestList = new List<Request>();
                    (serverSocket = new TcpListener(address, port)).Start(); //wystartowanie gniazdka sieciowego
                    (ConnThread = new Thread(Connector)).Start(); //wystartowanie wątku odpowiedzalnego za odbieranie połączeń
                }
                catch
                {
                    upLogBox("Server Error, chceck your IP and Port settings, sir");
                }

                butConn.Text = "Shutdown Server"; //zmiana napisu na przycisku
                isRunning = true; //teraz server chodzi :D
                if (txtIP.Text == "0.0.0.0")
                    upLogBox("Awaiting connection on every interface @ port " + port + ", sir");
                else upLogBox("Awaiting connection on " + address + " @ port " + port + ", sir");
            }
        }

        delegate void ceaseCallback();
        private void cease() //wygaś server - czynności gdy połączenie jest zamykane
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ceaseCallback(cease), new object[] { });
            }
            else
            {
                isRunning = false;
                foreach (Connection co in clientList) { try { co.cease(); } catch { upLogBox(" >>>>> Unknown Error <<<<< "); } }
                connected = 0;
                serverSocket.Stop();
                butConn.Text = "Run Server";
                butEstablished.Enabled = false;
                txtIP.Enabled = true;
                txtPort.Enabled = true;
                upLogBox("Server stopped, sir");
            }
        }

        delegate void upRequestBoxCallback(String text);
        public void upRequestBox(String text) //funkcja pokazująca tekst w okienku z logiem
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new upRequestBoxCallback(upRequestBox), new object[] { text });
            }
            else
            {
                if (text.ElementAt(text.Length - 1) != '\n')
                    txtRequest.AppendText(DateTime.Now.ToString(@"h\:mm\:ss tt") + " => " + text + "\n");
                //DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt")
                else txtRequest.AppendText(text);
                txtRequest.ScrollToCaret();
            }
        }

        delegate void upLogBoxCallback(String text);
        public void upLogBox(String text) //funkcja pokazująca tekst w okienku z logiem
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new upLogBoxCallback(upLogBox), new object[] { text });
            }
            else
            {
                if (text.ElementAt(text.Length - 1) != '\n')
                    txtLog.AppendText(DateTime.Now.ToString(@"h\:mm\:ss tt") + " => " + text + "\n");
                //DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt")
                else txtLog.AppendText(text);
                txtLog.ScrollToCaret();
            }
        }

        delegate void upRecvBoxCallback(String text);
        public void upRecvBox(String text) //funkcja pokazujące tekst w okienku 'odebrane'
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new upRecvBoxCallback(upRecvBox), new object[] { text });
            }
            else
            {
                if (text.ElementAt(text.Length - 1) != '\n')
                    txtReceive.AppendText(DateTime.Now.ToString(@"h\:mm\:ss tt") + ": " + text + "\n");
                else txtReceive.AppendText(text);
                txtReceive.ScrollToCaret();
            }
        }

        delegate void updateComboConnItemCallback();
        public void updateComboConnItem()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new updateComboConnItemCallback(updateComboConnItem), new object[] { });
            }
            else
            {
                int size = 0;
                foreach (Connection co in clientList)
                {
                    if (co.isConnected())
                    {
                        size++;
                    }
                }

                comboConn.Items.Clear();
                comboConn.SelectedIndex = -1;
                comboConn.SelectedIndex = -1; // BUG

                System.Object[] ItemObject = new System.Object[size];
                int i = 0;
                foreach (Connection co in clientList)
                {
                    if (co.isConnected())
                    {
                        ItemObject[i] = co.name;
                        i++;
                    }
                }


                comboConn.Items.AddRange(ItemObject);
            }
        }

        delegate void updateComboReqItemCallback();
        public void updateComboReqItem()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new updateComboReqItemCallback(updateComboReqItem), new object[] { });
            }
            else
            {
                int size = 0;
                foreach (Request req in requestList)
                {
                    if (req.isActive())
                    {
                        size++;
                    }
                }

                comboReq.Items.Clear();
                comboReq.SelectedIndex = -1;
                comboReq.SelectedIndex = -1; // BUG

                System.Object[] ItemObject = new System.Object[size];
                int i = 0;
                foreach (Request req in requestList)
                {
                    if (req.isActive())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = req.calling + " to " + req.called;
                        item.Value = req.ID;
                        ItemObject[i] = item;
                        i++;
                    }
                }


                comboReq.Items.AddRange(ItemObject);

                if (comboReq.Items.Count == 0)
                    butEstablished.Enabled = false;
                else
                    butEstablished.Enabled = true;
            }
        }

        delegate void updateComboTunnelItemCallback();
        public void updateComboTunnelItem()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new updateComboTunnelItemCallback(updateComboReqItem), new object[] { });
            }
            else
            {
                int size = 0;
                foreach (Request req in requestList)
                {
                    if (!req.isActive() && !req.isDisconnected())
                    {
                        size++;
                    }
                }

                comboTunnel.Items.Clear();
                comboTunnel.SelectedIndex = -1;
                comboTunnel.SelectedIndex = -1; // BUG

                System.Object[] ItemObject = new System.Object[size];
                int i = 0;
                foreach (Request req in requestList)
                {
                    if (!req.isActive() && !req.isDisconnected())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = req.calling + " to " + req.called;
                        item.Value = req.ID;
                        ItemObject[i] = item;
                        i++;
                    }
                }


                comboTunnel.Items.AddRange(ItemObject);

            }
        }

        private void msgHandler(String srvMsg, String clientName)
        {
            
            foreach (Connection co in clientList)
            {
                if (co.name == clientName)
                {
                    thisClient = co;
                    break;
                }
            }

            //thisClient = clientList.ElementAtOrDefault(clientIndex - 1);
            if (thisClient == null || !thisClient.isConnected())
            {
                upLogBox("Client " + thisClient.ID + " is disconnected");
                return;
            }


            thisClient.clientSender(srvMsg);
            upRecvBox("<@Client " + thisClient.name + "> " + srvMsg);
            upLogBox("Message sent successfully to Client " + thisClient.name);

        }

        public void sendClientList(Connection rq)
        {
            String msg = "";

            foreach (Connection co in clientList)
            {
                if (co.type.Equals("client") && co.isConnected())
                {
                    msg += co.name + " ";
                }
            }

            rq.clientSender(msg);
        }

        public void addReqToList(String calling, String called)
        {
            int ID = requestList.Count();
            requestList.Add(new Request(calling, called, ID));
            updateComboReqItem();
        }

        private void Connector()
        {
            connected = 0; //przy starcie servera nie ma zbyt wielu klientów
            try
            {
                while (true)
                {
                    clientSocket = null;
                    clientSocket = serverSocket.AcceptTcpClient(); //oczewikanie na nowego klienta (pauza w wątku)
                    clientList.Add(new Connection(this, clientSocket, ++iD)); //podłączenie nowego klienta i dodanie go do kontenera
                    connected++; //mamy jednego więcej aktywnego klienta, to nie jest jakaś ważna zmienna bo służy tylko do statusboxa
                    upLogBox("Client " + iD + " connected! from " + clientList.ElementAt(iD - 1).address + " @ " + clientList.ElementAt(iD - 1).port);
                }
            }
            catch
            {
                if (isRunning) upLogBox("Something has gone wrong, sir. Server has stopped working");
            }
            finally
            {
                connected = 0;
                if (isRunning) cease();
            }
        }

        private void ManagerX_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isRunning) this.cease();
            //jeśli server chodzi, wygaś, a jak nie to tylko:
            this.Dispose();
            this.Close();
        }

        private void butConn_Click(object sender, EventArgs e)
        {
            //jak chodzi to zgaś, jak nie chodzi to włącz :P
            if (isRunning == false) this.init();
            else this.cease();
        }

        private void butSend_Click(object sender, EventArgs e)
        {
            if (txtPortIn.Text.Length != 0 && txtVpiIn.Text.Length != 0 && txtVciIn.Text.Length != 0 && txtPortOut.Text.Length != 0 && txtVpiOut.Text.Length != 0 && txtVciOut.Text.Length != 0)
            {
                srvMsg = "ADD " + txtPortIn.Text + " " + txtVpiIn.Text + " " + txtVciIn.Text + " " + txtPortOut.Text + " " + txtVpiOut.Text + " " + txtVciOut.Text; //przechwyć wiadomość z SendBoxa
                if (srvMsg == null) return;

                if (comboReq.SelectedIndex != -1)
                {

                    foreach (Request req in requestList)
                    {
                        if (req.ID == Convert.ToInt32((comboReq.SelectedItem as ComboboxItem).Value.ToString()))
                        {
                            req.commands.Add(comboConn.SelectedItem.ToString(), txtPortIn.Text + " " + txtVpiIn.Text + " " + txtVciIn.Text + " " + txtPortOut.Text + " " + txtVpiOut.Text + " " + txtVciOut.Text);

                            break;
                        }
                    }

                }

                txtPortIn.Clear(); //wyczyść SendBoxa
                txtPortOut.Clear();
                txtVpiIn.Clear();
                txtVpiOut.Clear();
                txtVciIn.Clear();
                txtVciOut.Clear();

                txtPortIn.ReadOnly = true;
                txtVpiIn.ReadOnly = true;
                txtVciIn.ReadOnly = true;
                txtPortOut.ReadOnly = true;
                txtVpiOut.ReadOnly = true;
                txtVciOut.ReadOnly = true;
                butAdd.Enabled = false;
                butRemove.Enabled = false;

                msgHandler(srvMsg, comboConn.SelectedItem.ToString()); //zrozum i obsłuż odpowiednio wiadomość
                comboConn.SelectedIndex = -1;
                comboConn.SelectedIndex = -1; // BUG
                comboConn.Focus(); //przywróć kursor znowu w pole wysyłania
            }
            else
            {
                upLogBox("FILL ALL FIELDS BEFORE ADDING!");
            }
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            if (txtPortIn.Text.Length != 0 && txtVpiIn.Text.Length != 0 && txtVciIn.Text.Length != 0 && txtPortOut.Text.Length != 0 && txtVpiOut.Text.Length != 0 && txtVciOut.Text.Length != 0)
            {
                srvMsg = "DELETE " + txtPortIn.Text + " " + txtVpiIn.Text + " " + txtVciIn.Text + " " + txtPortOut.Text + " " + txtVpiOut.Text + " " + txtVciOut.Text; //przechwyć wiadomość z SendBoxa
                if (srvMsg == null) return;

                txtPortIn.Clear(); //wyczyść SendBoxa
                txtPortOut.Clear();
                txtVpiIn.Clear();
                txtVpiOut.Clear();
                txtVciIn.Clear();
                txtVciOut.Clear();

                txtPortIn.ReadOnly = true;
                txtVpiIn.ReadOnly = true;
                txtVciIn.ReadOnly = true;
                txtPortOut.ReadOnly = true;
                txtVpiOut.ReadOnly = true;
                txtVciOut.ReadOnly = true;
                butAdd.Enabled = false;
                butRemove.Enabled = false;

                msgHandler(srvMsg, comboConn.SelectedItem.ToString()); //zrozum i obsłuż odpowiednio wiadomość
                comboConn.SelectedIndex = -1;
                comboConn.SelectedIndex = -1; // BUG
                comboConn.Focus(); //przywróć kursor znowu w pole wysyłania
            }
            else
            {
                upLogBox("FILL ALL FIELDS BEFORE DELETING!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int requestID = Convert.ToInt32((comboReq.SelectedItem as ComboboxItem).Value.ToString());

            foreach (Request req in requestList)
            {
                if (req.ID == requestID)
                {
                    msgHandler("ESTABLISHED", req.calling);
                    req.deactivate();
                    updateComboReqItem();
                    comboReq.SelectedIndex = -1;
                    comboReq.SelectedIndex = -1;
                    updateComboTunnelItem();
                    break;
                }
            }
        }

        private void ManagerX_Load(object sender, EventArgs e)
        {

        }

        private void comboReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;

            if (comboBox.SelectedIndex != -1)
            {
                butEstablished.Enabled = true;
            }
            else
            {
                butEstablished.Enabled = false;
            }
        }

        private void comboConn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedIndex != -1)
            {
                txtPortIn.ReadOnly = false;
                txtVpiIn.ReadOnly = false;
                txtVciIn.ReadOnly = false;
                txtPortOut.ReadOnly = false;
                txtVpiOut.ReadOnly = false;
                txtVciOut.ReadOnly = false;
                butAdd.Enabled = true;
                butRemove.Enabled = true;
                butClearNode.Enabled = true;
            }
            else
            {
                txtPortIn.ReadOnly = true;
                txtVpiIn.ReadOnly = true;
                txtVciIn.ReadOnly = true;
                txtPortOut.ReadOnly = true;
                txtVpiOut.ReadOnly = true;
                txtVciOut.ReadOnly = true;
                butAdd.Enabled = false;
                butRemove.Enabled = false;
                butClearNode.Enabled = false;
            }
            
        }

        private void butClearNode_Click(object sender, EventArgs e)
        {
            msgHandler("CLEAR", comboConn.SelectedItem.ToString());
        }

        private void comboTunnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            if (comboBox.SelectedIndex != -1)
            {
                butDisconnect.Enabled = true;
            }
            else
            {
                butDisconnect.Enabled = false;
            }
        }

        private void butDisconnect_Click(object sender, EventArgs e)
        {
            int tunnelID = Convert.ToInt32((comboTunnel.SelectedItem as ComboboxItem).Value.ToString());

            foreach (Request req in requestList)
            {
                if (req.ID == tunnelID)
                {
                    foreach (KeyValuePair<string, string> pair in req.commands)
                    {
                        String msg = "DELETE " + pair.Value;
                        msgHandler(msg, pair.Key);
                    }

                    req.disconnect();
                    updateComboTunnelItem();
                    break;
                }
            }
        }

        private void txtPortIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)  && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtVpiIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtVciIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPortOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtVpiOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtVciOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

    }

    public class Connection
    {
        public int ID { get; private set; }
        public IPAddress address { get; private set; }
        public int port { get; private set; }
        public String name { get; private set; }
        public String type { get; private set; }
        private TcpClient clientSocket;
        private ManagerX serverForm;
        private Thread thread;
        private NetworkStream netStream;

        public Connection(ManagerX serverForm, TcpClient clientSocket, int ID)
        {
            this.ID = ID;
            this.address = IPAddress.Parse((((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address).ToString());
            this.port = ((IPEndPoint)clientSocket.Client.RemoteEndPoint).Port;
            this.clientSocket = clientSocket;
            this.serverForm = serverForm;
            netStream = clientSocket.GetStream();
            (thread = new Thread(ClientReceiver)).Start();
        }

        public bool isConnected()
        {
            try { if (clientSocket.Connected) return true; else return false; }
            catch { return false; }
        }

        
        private void ClientReceiver()
        {
            try
            {

                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(netStream);
                System.IO.StreamReader streamReader = new System.IO.StreamReader(netStream);

                while (true)
                {
                    string theString = streamReader.ReadLine();

                    if (theString == "LOGINC")
                    {
                        name = streamReader.ReadLine();
                        type = "client";

                        serverForm.updateComboConnItem();
                        serverForm.upRecvBox("Client " + name + " logged in");
                        clientSender("LOGGED");
                    }
                    else if (theString == "LOGINT")
                    {
                        name = streamReader.ReadLine();
                        type = "transport";
                        //dupa
                        serverForm.updateComboConnItem();
                        serverForm.upRecvBox("Transport " + name + " logged in");
                        clientSender("LOGGED");
                    }
                    else if (theString == "CALL")
                    {
                        if (type.Equals("client"))
                        {
                            String called = streamReader.ReadLine();
                            serverForm.addReqToList(this.name, called);
                            serverForm.upRequestBox("Client " + name + " requested call with client " + called);
                        }
                        else
                        {
                            serverForm.upRequestBox("Transport node cannot make calls...");
                        }
                    }
                    else if (theString == "GET_CLIENTS")
                    {
                        serverForm.sendClientList(this);
                    }

                }
            }
            catch
            {
                if (serverForm.isRunning)
                {
                    serverForm.updateComboConnItem();
                    serverForm.upRecvBox("Client " + name + " disconnected");
                    serverForm.upLogBox("Connection with client " + ID + " lost, sir");
                }
            }
            finally
            {
                serverForm.connected--;
                cease();
            }
        }

        public void clientSender(String srvMsg)
        {
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(netStream);
            System.IO.StreamReader streamReader = new System.IO.StreamReader(netStream);

            streamWriter.WriteLine(srvMsg);
            streamWriter.Flush();

        }

        public void cease()
        {
            clientSocket.Close();
        }
    }

    public class Request
    {

        public String calling;
        public String called;
        public int ID;
        private Boolean active;
        private Boolean disconnected;
        public Dictionary<String, String> commands;

        public Request(String calling, String called, int ID)
        {
            this.ID = ID;
            this.calling = calling;
            this.called = called;
            this.active = true;
            this.commands = new Dictionary<string, string>();
            this.disconnected = false;
        }

        public Boolean isActive()
        {
            return active;
        }

        public void deactivate()
        {
            active = false;
        }

        public Boolean isDisconnected()
        {
            return disconnected;
        }

        public void disconnect()
        {
            disconnected = true;
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

    }
}
