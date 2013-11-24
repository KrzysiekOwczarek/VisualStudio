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
        private int clientIndex;

        public ManagerX()
        {
            InitializeComponent();
            //txtIP.Text = IPAddress.Any.ToString(); //nasluchuj na każdym interfejsie
            txtIP.Text = "127.0.0.1";
            txtPort.Text = 8002.ToString();
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
                txtIP.Enabled = false;
                txtPort.Enabled = false;
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

                System.Object[] ItemObject = new System.Object[size];
                int i = 0;
                foreach (Request req in requestList)
                {
                    if (req.isActive())
                    {
                        ComboboxItem item = new ComboboxItem();
                        item.Text = req.calling.name + " to " + req.called;
                        item.Value = req.ID;
                        ItemObject[i] = item;
                        //ItemObject[i] = req.calling.name;
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

        private void msgHandler(String srvMsg, String clientName)
        {
            upLogBox(clientName.ToString());

            foreach (Connection co in clientList)
            {
                if (co.name.Equals(clientName))
                {
                    upLogBox("FOUND");
                    thisClient = co;
                    break;
                }
            }

            //thisClient = clientList.ElementAtOrDefault(clientIndex - 1);
            if (thisClient == null || !thisClient.isConnected())
            {
                upLogBox("Client " + clientIndex + " is disconnected");
                return;
            }


            thisClient.clientSender(srvMsg);
            upRecvBox("<@Client " + clientIndex + "> " + srvMsg);
            upLogBox("Message sent successfully to Client " + clientIndex);

        }

        public void sendClientList(Connection rq)
        {
            foreach (Connection co in clientList)
            {
                if (co.type.Equals("client") && co.isConnected())
                {
                    rq.clientSender(co.name);
                }
            }

            rq.clientSender(" ");
        }

        public void addReqToList(Connection calling, String called)
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
            srvMsg = "ADD " + txtPortIn.Text + " " + txtVpiIn.Text + "/" + txtVciIn.Text + " " + txtPortOut.Text + " " + txtVpiOut.Text + "/" + txtVciOut.Text; //przechwyć wiadomość z SendBoxa
            if (srvMsg == null) return;
            txtPortIn.Clear(); //wyczyść SendBoxa
            txtPortOut.Clear();
            txtVpiIn.Clear();
            txtVpiOut.Clear();
            txtVciIn.Clear();
            txtVciOut.Clear();
            msgHandler(srvMsg, comboConn.SelectedItem.ToString()); //zrozum i obsłuż odpowiednio wiadomość
            comboConn.SelectedIndex = -1;
            comboConn.Focus(); //przywróć kursor znowu w pole wysyłania
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            srvMsg = "DEL " + txtPortIn.Text + " " + txtVpiIn.Text + "/" + txtVciIn.Text + " " + txtPortOut.Text + " " + txtVpiOut.Text + "/" + txtVciOut.Text; //przechwyć wiadomość z SendBoxa
            if (srvMsg == null) return;
            txtPortIn.Clear(); //wyczyść SendBoxa
            txtPortOut.Clear();
            txtVpiIn.Clear();
            txtVpiOut.Clear();
            txtVciIn.Clear();
            txtVciOut.Clear();
            msgHandler(srvMsg, comboConn.SelectedItem.ToString()); //zrozum i obsłuż odpowiednio wiadomość
            comboConn.SelectedIndex = -1;
            comboConn.Focus(); //przywróć kursor znowu w pole wysyłania
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int requestID = Convert.ToInt32((comboReq.SelectedItem as ComboboxItem).Value.ToString());

            foreach (Request req in requestList)
            {
                if (req.ID == requestID)
                {
                    //upLogBox("FOUND REQ");
                    msgHandler("ESTABLISHED", req.calling.name);
                    req.deactivate();
                    updateComboReqItem();
                    break;
                }
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

        //Deserializaja
        private void ClientReceiver()
        {
            try
            { // tylko wyświetla tekst w przeslanym pakiecie, nie przekazuje tego dalej

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

                        serverForm.updateComboConnItem();
                        serverForm.upRecvBox("Transport " + name + " logged in");
                        clientSender("LOGGED");
                    }
                    else if (theString == "REQ_CALL")
                    {
                        if (type.Equals("client"))
                        {
                            
                            String called = streamReader.ReadLine();
                            serverForm.addReqToList(this, called);
                            serverForm.upRequestBox("Client " + name + " requested call with client " + called);

                        }
                        else
                        {
                            serverForm.upRequestBox("Transport node cannot make calls...");
                        }
                    }
                    else if (theString == "REQ_CLIENTS")
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

        //Serializacja
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

        public Connection calling { get; private set; }
        public String called { get; private set; }
        public int ID { get; private set; }
        private Boolean active;

        public Request(Connection calling, String called, int ID)
        {
            this.ID = ID;
            this.calling = calling;
            this.called = called;
            this.active = true;
        }

        public Boolean isActive()
        {
            return active;
        }

        public void deactivate()
        {
            active = false;
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
