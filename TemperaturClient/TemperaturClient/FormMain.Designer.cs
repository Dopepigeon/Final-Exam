namespace TemperaturClient
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
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonShowData = new System.Windows.Forms.Button();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.radioButtonList = new System.Windows.Forms.RadioButton();
            this.radioButtonGraph = new System.Windows.Forms.RadioButton();
            this.userControlTempList = new TemperaturClient.Usercontrols.UserControlTempList();
            this.usercontrolGraph = new TemperaturClient.Usercontrols.UsercontrolGraph();
            this.SuspendLayout();
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(89, 25);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(120, 22);
            this.dateTimePickerStart.TabIndex = 0;
            this.dateTimePickerStart.Value = new System.DateTime(2020, 6, 19, 0, 0, 0, 0);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(89, 56);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(120, 22);
            this.dateTimePickerEnd.TabIndex = 1;
            this.dateTimePickerEnd.Value = new System.DateTime(2020, 6, 19, 21, 8, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ende: ";
            // 
            // buttonShowData
            // 
            this.buttonShowData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowData.Location = new System.Drawing.Point(315, 25);
            this.buttonShowData.Name = "buttonShowData";
            this.buttonShowData.Size = new System.Drawing.Size(168, 53);
            this.buttonShowData.TabIndex = 5;
            this.buttonShowData.Text = "Get data";
            this.buttonShowData.UseVisualStyleBackColor = true;
            this.buttonShowData.Click += new System.EventHandler(this.buttonShowData_Click);
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "dd-MM-yyyy      hh:mm:ss";
            this.dateTimePickerStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(215, 25);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.ShowUpDown = true;
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(82, 22);
            this.dateTimePickerStartTime.TabIndex = 7;
            this.dateTimePickerStartTime.Value = new System.DateTime(2020, 6, 26, 13, 0, 0, 0);
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.CustomFormat = "dd-MM-yyyy      hh:mm:ss";
            this.dateTimePickerEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(215, 56);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.ShowUpDown = true;
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(82, 22);
            this.dateTimePickerEndTime.TabIndex = 8;
            this.dateTimePickerEndTime.Value = new System.DateTime(2020, 6, 26, 19, 0, 0, 0);
            // 
            // radioButtonList
            // 
            this.radioButtonList.AutoSize = true;
            this.radioButtonList.Location = new System.Drawing.Point(514, 30);
            this.radioButtonList.Name = "radioButtonList";
            this.radioButtonList.Size = new System.Drawing.Size(41, 17);
            this.radioButtonList.TabIndex = 11;
            this.radioButtonList.Text = "List";
            this.radioButtonList.UseVisualStyleBackColor = true;
            this.radioButtonList.CheckedChanged += new System.EventHandler(this.radioButtonList_CheckedChanged);
            // 
            // radioButtonGraph
            // 
            this.radioButtonGraph.AutoSize = true;
            this.radioButtonGraph.Checked = true;
            this.radioButtonGraph.Location = new System.Drawing.Point(514, 56);
            this.radioButtonGraph.Name = "radioButtonGraph";
            this.radioButtonGraph.Size = new System.Drawing.Size(54, 17);
            this.radioButtonGraph.TabIndex = 12;
            this.radioButtonGraph.TabStop = true;
            this.radioButtonGraph.Text = "Graph";
            this.radioButtonGraph.UseVisualStyleBackColor = true;
            this.radioButtonGraph.CheckedChanged += new System.EventHandler(this.radioButtonGraph_CheckedChanged);
            // 
            // userControlTempList
            // 
            this.userControlTempList.Location = new System.Drawing.Point(12, 98);
            this.userControlTempList.Name = "userControlTempList";
            this.userControlTempList.Size = new System.Drawing.Size(924, 503);
            this.userControlTempList.TabIndex = 10;
            this.userControlTempList.Visible = false;
            // 
            // usercontrolGraph
            // 
            this.usercontrolGraph.Location = new System.Drawing.Point(19, 98);
            this.usercontrolGraph.Name = "usercontrolGraph";
            this.usercontrolGraph.Size = new System.Drawing.Size(924, 503);
            this.usercontrolGraph.TabIndex = 9;
            this.usercontrolGraph.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 613);
            this.Controls.Add(this.radioButtonGraph);
            this.Controls.Add(this.radioButtonList);
            this.Controls.Add(this.userControlTempList);
            this.Controls.Add(this.usercontrolGraph);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.buttonShowData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonShowData;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private Usercontrols.UsercontrolGraph usercontrolGraph;
        private Usercontrols.UserControlTempList userControlTempList;
        private System.Windows.Forms.RadioButton radioButtonList;
        private System.Windows.Forms.RadioButton radioButtonGraph;
    }
}

