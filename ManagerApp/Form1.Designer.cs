namespace ManagerApp
{
    partial class Form1
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
            this.netFileButton = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // netFileButton
            // 
            this.netFileButton.Location = new System.Drawing.Point(362, 12);
            this.netFileButton.Name = "netFileButton";
            this.netFileButton.Size = new System.Drawing.Size(132, 23);
            this.netFileButton.TabIndex = 0;
            this.netFileButton.Text = "Download Network File";
            this.netFileButton.UseVisualStyleBackColor = true;
            this.netFileButton.Click += new System.EventHandler(this.netFileButton_Click);
            // 
            // logText
            // 
            this.logText.Location = new System.Drawing.Point(12, 388);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(482, 140);
            this.logText.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 540);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.netFileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button netFileButton;
        private System.Windows.Forms.TextBox logText;
    }
}

