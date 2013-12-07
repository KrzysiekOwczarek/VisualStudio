namespace ManagerX
{
    partial class ManagerX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.butConn = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.txtReceive = new System.Windows.Forms.RichTextBox();
            this.comboTrans = new System.Windows.Forms.ComboBox();
            this.txtPortIn = new System.Windows.Forms.TextBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.txtVpiIn = new System.Windows.Forms.TextBox();
            this.txtPortOut = new System.Windows.Forms.TextBox();
            this.txtVpiOut = new System.Windows.Forms.TextBox();
            this.txtVciIn = new System.Windows.Forms.TextBox();
            this.txtVciOut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.butRemove = new System.Windows.Forms.Button();
            this.txtRequest = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.butEstablished = new System.Windows.Forms.Button();
            this.comboReq = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboTunnel = new System.Windows.Forms.ComboBox();
            this.butDisconnect = new System.Windows.Forms.Button();
            this.butClearNode = new System.Windows.Forms.Button();
            this.callingTxt = new System.Windows.Forms.TextBox();
            this.calledPortTxt = new System.Windows.Forms.TextBox();
            this.calledTxt = new System.Windows.Forms.TextBox();
            this.callingVpiTxt = new System.Windows.Forms.TextBox();
            this.callingPortTxt = new System.Windows.Forms.TextBox();
            this.callingVciTxt = new System.Windows.Forms.TextBox();
            this.calledVciTxt = new System.Windows.Forms.TextBox();
            this.calledVpiTxt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // butConn
            // 
            this.butConn.Location = new System.Drawing.Point(301, 30);
            this.butConn.Name = "butConn";
            this.butConn.Size = new System.Drawing.Size(75, 23);
            this.butConn.TabIndex = 0;
            this.butConn.Text = "Start Server";
            this.butConn.UseVisualStyleBackColor = true;
            this.butConn.Click += new System.EventHandler(this.butConn_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(12, 32);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(125, 20);
            this.txtIP.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(156, 32);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(125, 20);
            this.txtPort.TabIndex = 2;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(7, 603);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(367, 85);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(7, 499);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(367, 85);
            this.txtReceive.TabIndex = 4;
            this.txtReceive.Text = "";
            // 
            // comboTrans
            // 
            this.comboTrans.FormattingEnabled = true;
            this.comboTrans.Location = new System.Drawing.Point(6, 47);
            this.comboTrans.Name = "comboTrans";
            this.comboTrans.Size = new System.Drawing.Size(56, 21);
            this.comboTrans.TabIndex = 5;
            // 
            // txtPortIn
            // 
            this.txtPortIn.Location = new System.Drawing.Point(69, 48);
            this.txtPortIn.Name = "txtPortIn";
            this.txtPortIn.Size = new System.Drawing.Size(56, 20);
            this.txtPortIn.TabIndex = 6;
            this.txtPortIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPortIn_KeyPress);
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(281, 31);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.TabIndex = 7;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butSend_Click);
            // 
            // txtVpiIn
            // 
            this.txtVpiIn.Location = new System.Drawing.Point(136, 47);
            this.txtVpiIn.Name = "txtVpiIn";
            this.txtVpiIn.Size = new System.Drawing.Size(56, 20);
            this.txtVpiIn.TabIndex = 8;
            this.txtVpiIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVpiIn_KeyPress);
            // 
            // txtPortOut
            // 
            this.txtPortOut.Location = new System.Drawing.Point(69, 86);
            this.txtPortOut.Name = "txtPortOut";
            this.txtPortOut.Size = new System.Drawing.Size(56, 20);
            this.txtPortOut.TabIndex = 9;
            this.txtPortOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPortOut_KeyPress);
            // 
            // txtVpiOut
            // 
            this.txtVpiOut.Location = new System.Drawing.Point(136, 86);
            this.txtVpiOut.Name = "txtVpiOut";
            this.txtVpiOut.Size = new System.Drawing.Size(56, 20);
            this.txtVpiOut.TabIndex = 10;
            this.txtVpiOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVpiOut_KeyPress);
            // 
            // txtVciIn
            // 
            this.txtVciIn.Location = new System.Drawing.Point(203, 47);
            this.txtVciIn.Name = "txtVciIn";
            this.txtVciIn.Size = new System.Drawing.Size(56, 20);
            this.txtVciIn.TabIndex = 11;
            this.txtVciIn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVciIn_KeyPress);
            // 
            // txtVciOut
            // 
            this.txtVciOut.Location = new System.Drawing.Point(203, 85);
            this.txtVciOut.Name = "txtVciOut";
            this.txtVciOut.Size = new System.Drawing.Size(56, 20);
            this.txtVciOut.TabIndex = 12;
            this.txtVciOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVciOut_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Server IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Server Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Node";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Port IN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "VPI IN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "VCI IN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Port OUT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(133, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "VPI OUT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "VCI OUT";
            // 
            // butRemove
            // 
            this.butRemove.Location = new System.Drawing.Point(281, 56);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(75, 23);
            this.butRemove.TabIndex = 22;
            this.butRemove.Text = "Delete";
            this.butRemove.UseVisualStyleBackColor = true;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(7, 395);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(367, 85);
            this.txtRequest.TabIndex = 23;
            this.txtRequest.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Requests:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 483);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Client Log:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 587);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Server Log:";
            // 
            // butEstablished
            // 
            this.butEstablished.Enabled = false;
            this.butEstablished.Location = new System.Drawing.Point(282, 81);
            this.butEstablished.Name = "butEstablished";
            this.butEstablished.Size = new System.Drawing.Size(75, 23);
            this.butEstablished.TabIndex = 27;
            this.butEstablished.Text = "RUN";
            this.butEstablished.UseVisualStyleBackColor = true;
            this.butEstablished.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboReq
            // 
            this.comboReq.FormattingEnabled = true;
            this.comboReq.Location = new System.Drawing.Point(7, 107);
            this.comboReq.Name = "comboReq";
            this.comboReq.Size = new System.Drawing.Size(121, 21);
            this.comboReq.TabIndex = 28;
            this.comboReq.SelectedIndexChanged += new System.EventHandler(this.comboReq_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Active requests:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Active Connections";
            // 
            // comboTunnel
            // 
            this.comboTunnel.FormattingEnabled = true;
            this.comboTunnel.Location = new System.Drawing.Point(12, 69);
            this.comboTunnel.Name = "comboTunnel";
            this.comboTunnel.Size = new System.Drawing.Size(121, 21);
            this.comboTunnel.TabIndex = 31;
            this.comboTunnel.SelectedIndexChanged += new System.EventHandler(this.comboTunnel_SelectedIndexChanged);
            // 
            // butDisconnect
            // 
            this.butDisconnect.Location = new System.Drawing.Point(156, 69);
            this.butDisconnect.Name = "butDisconnect";
            this.butDisconnect.Size = new System.Drawing.Size(125, 23);
            this.butDisconnect.TabIndex = 32;
            this.butDisconnect.Text = "DISCONNECT";
            this.butDisconnect.UseVisualStyleBackColor = true;
            this.butDisconnect.Click += new System.EventHandler(this.butDisconnect_Click);
            // 
            // butClearNode
            // 
            this.butClearNode.Location = new System.Drawing.Point(281, 85);
            this.butClearNode.Name = "butClearNode";
            this.butClearNode.Size = new System.Drawing.Size(76, 23);
            this.butClearNode.TabIndex = 33;
            this.butClearNode.Text = "Clear";
            this.butClearNode.UseVisualStyleBackColor = true;
            this.butClearNode.Click += new System.EventHandler(this.butClearNode_Click);
            // 
            // callingTxt
            // 
            this.callingTxt.Location = new System.Drawing.Point(6, 44);
            this.callingTxt.Name = "callingTxt";
            this.callingTxt.ReadOnly = true;
            this.callingTxt.Size = new System.Drawing.Size(55, 20);
            this.callingTxt.TabIndex = 36;
            // 
            // calledPortTxt
            // 
            this.calledPortTxt.Location = new System.Drawing.Point(75, 83);
            this.calledPortTxt.Name = "calledPortTxt";
            this.calledPortTxt.Size = new System.Drawing.Size(56, 20);
            this.calledPortTxt.TabIndex = 37;
            this.calledPortTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // calledTxt
            // 
            this.calledTxt.Location = new System.Drawing.Point(6, 83);
            this.calledTxt.Name = "calledTxt";
            this.calledTxt.ReadOnly = true;
            this.calledTxt.Size = new System.Drawing.Size(55, 20);
            this.calledTxt.TabIndex = 38;
            // 
            // callingVpiTxt
            // 
            this.callingVpiTxt.Location = new System.Drawing.Point(142, 43);
            this.callingVpiTxt.Name = "callingVpiTxt";
            this.callingVpiTxt.Size = new System.Drawing.Size(56, 20);
            this.callingVpiTxt.TabIndex = 39;
            this.callingVpiTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            // 
            // callingPortTxt
            // 
            this.callingPortTxt.Location = new System.Drawing.Point(75, 43);
            this.callingPortTxt.Name = "callingPortTxt";
            this.callingPortTxt.Size = new System.Drawing.Size(56, 20);
            this.callingPortTxt.TabIndex = 40;
            this.callingPortTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // callingVciTxt
            // 
            this.callingVciTxt.Location = new System.Drawing.Point(209, 43);
            this.callingVciTxt.Name = "callingVciTxt";
            this.callingVciTxt.Size = new System.Drawing.Size(56, 20);
            this.callingVciTxt.TabIndex = 41;
            this.callingVciTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // calledVciTxt
            // 
            this.calledVciTxt.Location = new System.Drawing.Point(209, 83);
            this.calledVciTxt.Name = "calledVciTxt";
            this.calledVciTxt.Size = new System.Drawing.Size(56, 20);
            this.calledVciTxt.TabIndex = 42;
            this.calledVciTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
            // 
            // calledVpiTxt
            // 
            this.calledVpiTxt.Location = new System.Drawing.Point(142, 83);
            this.calledVpiTxt.Name = "calledVpiTxt";
            this.calledVpiTxt.Size = new System.Drawing.Size(56, 20);
            this.calledVpiTxt.TabIndex = 43;
            this.calledVpiTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(72, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Port";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(139, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "VPI";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(206, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 13);
            this.label18.TabIndex = 46;
            this.label18.Text = "VCI";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(72, 66);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 13);
            this.label19.TabIndex = 47;
            this.label19.Text = "Port";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(136, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "VPI";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(206, 66);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 13);
            this.label21.TabIndex = 49;
            this.label21.Text = "VCI";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(10, 27);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(38, 13);
            this.label22.TabIndex = 50;
            this.label22.Text = "Calling";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(10, 67);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 13);
            this.label23.TabIndex = 51;
            this.label23.Text = "Called";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboTrans);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPortIn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtVpiIn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtVciIn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPortOut);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtVpiOut);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtVciOut);
            this.groupBox1.Controls.Add(this.butAdd);
            this.groupBox1.Controls.Add(this.butRemove);
            this.groupBox1.Controls.Add(this.butClearNode);
            this.groupBox1.Location = new System.Drawing.Point(7, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 123);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transport Nodes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.callingTxt);
            this.groupBox2.Controls.Add(this.calledPortTxt);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.calledTxt);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.callingVpiTxt);
            this.groupBox2.Controls.Add(this.butEstablished);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.callingPortTxt);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.callingVciTxt);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.calledVciTxt);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.calledVpiTxt);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(7, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 113);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client Nodes";
            // 
            // ManagerX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 700);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butDisconnect);
            this.Controls.Add(this.comboTunnel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboReq);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.butConn);
            this.Name = "ManagerX";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerX_FormClosed);
            this.Load += new System.EventHandler(this.ManagerX_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butConn;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.ComboBox comboTrans;
        private System.Windows.Forms.TextBox txtPortIn;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.TextBox txtVpiIn;
        private System.Windows.Forms.TextBox txtPortOut;
        private System.Windows.Forms.TextBox txtVpiOut;
        private System.Windows.Forms.TextBox txtVciIn;
        private System.Windows.Forms.TextBox txtVciOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button butRemove;
        private System.Windows.Forms.RichTextBox txtRequest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button butEstablished;
        private System.Windows.Forms.ComboBox comboReq;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboTunnel;
        private System.Windows.Forms.Button butDisconnect;
        private System.Windows.Forms.Button butClearNode;
        private System.Windows.Forms.TextBox callingTxt;
        private System.Windows.Forms.TextBox calledPortTxt;
        private System.Windows.Forms.TextBox calledTxt;
        private System.Windows.Forms.TextBox callingVpiTxt;
        private System.Windows.Forms.TextBox callingPortTxt;
        private System.Windows.Forms.TextBox callingVciTxt;
        private System.Windows.Forms.TextBox calledVciTxt;
        private System.Windows.Forms.TextBox calledVpiTxt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

