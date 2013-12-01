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
            this.comboConn = new System.Windows.Forms.ComboBox();
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
            this.SuspendLayout();
            // 
            // butConn
            // 
            this.butConn.Location = new System.Drawing.Point(354, 32);
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
            this.txtLog.Location = new System.Drawing.Point(9, 470);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(420, 85);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(9, 350);
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(420, 85);
            this.txtReceive.TabIndex = 4;
            this.txtReceive.Text = "";
            // 
            // comboConn
            // 
            this.comboConn.FormattingEnabled = true;
            this.comboConn.Location = new System.Drawing.Point(12, 80);
            this.comboConn.Name = "comboConn";
            this.comboConn.Size = new System.Drawing.Size(56, 21);
            this.comboConn.TabIndex = 5;
            // 
            // txtPortIn
            // 
            this.txtPortIn.Location = new System.Drawing.Point(12, 128);
            this.txtPortIn.Name = "txtPortIn";
            this.txtPortIn.Size = new System.Drawing.Size(60, 20);
            this.txtPortIn.TabIndex = 6;
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(354, 80);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.TabIndex = 7;
            this.butAdd.Text = "Add";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butSend_Click);
            // 
            // txtVpiIn
            // 
            this.txtVpiIn.Location = new System.Drawing.Point(78, 128);
            this.txtVpiIn.Name = "txtVpiIn";
            this.txtVpiIn.Size = new System.Drawing.Size(60, 20);
            this.txtVpiIn.TabIndex = 8;
            // 
            // txtPortOut
            // 
            this.txtPortOut.Location = new System.Drawing.Point(12, 172);
            this.txtPortOut.Name = "txtPortOut";
            this.txtPortOut.Size = new System.Drawing.Size(60, 20);
            this.txtPortOut.TabIndex = 9;
            // 
            // txtVpiOut
            // 
            this.txtVpiOut.Location = new System.Drawing.Point(78, 172);
            this.txtVpiOut.Name = "txtVpiOut";
            this.txtVpiOut.Size = new System.Drawing.Size(60, 20);
            this.txtVpiOut.TabIndex = 10;
            // 
            // txtVciIn
            // 
            this.txtVciIn.Location = new System.Drawing.Point(144, 128);
            this.txtVciIn.Name = "txtVciIn";
            this.txtVciIn.Size = new System.Drawing.Size(60, 20);
            this.txtVciIn.TabIndex = 11;
            this.txtVciIn.Text = "0";
            // 
            // txtVciOut
            // 
            this.txtVciOut.Location = new System.Drawing.Point(144, 172);
            this.txtVciOut.Name = "txtVciOut";
            this.txtVciOut.Size = new System.Drawing.Size(60, 20);
            this.txtVciOut.TabIndex = 12;
            this.txtVciOut.Text = "0";
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
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Node:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Port IN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "VPI IN";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "VCI IN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Port OUT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "VPI OUT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(141, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "VCI OUT";
            // 
            // butRemove
            // 
            this.butRemove.Location = new System.Drawing.Point(354, 112);
            this.butRemove.Name = "butRemove";
            this.butRemove.Size = new System.Drawing.Size(75, 23);
            this.butRemove.TabIndex = 22;
            this.butRemove.Text = "Delete";
            this.butRemove.UseVisualStyleBackColor = true;
            this.butRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // txtRequest
            // 
            this.txtRequest.Location = new System.Drawing.Point(9, 228);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(420, 85);
            this.txtRequest.TabIndex = 23;
            this.txtRequest.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Requests:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 334);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Client Log:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 454);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Server Log:";
            // 
            // butEstablished
            // 
            this.butEstablished.Enabled = false;
            this.butEstablished.Location = new System.Drawing.Point(293, 189);
            this.butEstablished.Name = "butEstablished";
            this.butEstablished.Size = new System.Drawing.Size(136, 33);
            this.butEstablished.TabIndex = 27;
            this.butEstablished.Text = "ESTABLISHED";
            this.butEstablished.UseVisualStyleBackColor = true;
            this.butEstablished.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboReq
            // 
            this.comboReq.FormattingEnabled = true;
            this.comboReq.Location = new System.Drawing.Point(308, 162);
            this.comboReq.Name = "comboReq";
            this.comboReq.Size = new System.Drawing.Size(121, 21);
            this.comboReq.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(305, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Requests:";
            // 
            // ManagerX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 576);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboReq);
            this.Controls.Add(this.butEstablished);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.butRemove);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVciOut);
            this.Controls.Add(this.txtVciIn);
            this.Controls.Add(this.txtVpiOut);
            this.Controls.Add(this.txtPortOut);
            this.Controls.Add(this.txtVpiIn);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.txtPortIn);
            this.Controls.Add(this.comboConn);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.butConn);
            this.Name = "ManagerX";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerX_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butConn;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.RichTextBox txtReceive;
        private System.Windows.Forms.ComboBox comboConn;
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
    }
}

