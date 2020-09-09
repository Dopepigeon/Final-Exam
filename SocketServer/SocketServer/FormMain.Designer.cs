namespace SocketServer
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.buttonStopServer = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(430, 352);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartServer.Location = new System.Drawing.Point(457, 12);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(139, 58);
            this.buttonStartServer.TabIndex = 1;
            this.buttonStartServer.Text = "Start server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Enabled = false;
            this.buttonStopServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopServer.Location = new System.Drawing.Point(457, 86);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(139, 58);
            this.buttonStopServer.TabIndex = 2;
            this.buttonStopServer.Text = "Stop server";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.buttonStopServer_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(457, 339);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(139, 21);
            this.comboBoxPorts.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(454, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port for Serial:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 376);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPorts);
            this.Controls.Add(this.buttonStopServer);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.richTextBoxLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Button buttonStopServer;
        public System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Label label1;
    }
}

