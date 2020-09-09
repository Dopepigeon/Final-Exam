namespace TemperaturClient.Usercontrols
{
    partial class UsercontrolGraph
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxGraph.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBoxGraph.Location = new System.Drawing.Point(23, 43);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(879, 412);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxGraph_Paint);
            this.pictureBoxGraph.MouseLeave += new System.EventHandler(this.pictureBoxGraph_MouseLeave);
            this.pictureBoxGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGraph_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Graph";
            // 
            // UsercontrolGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxGraph);
            this.Name = "UsercontrolGraph";
            this.Size = new System.Drawing.Size(924, 479);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Label label1;
    }
}
