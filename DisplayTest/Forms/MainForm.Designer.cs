namespace DisplayTest.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.uxSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.uxGetDisplayStatus = new System.Windows.Forms.Button();
            this.uxSerialPorts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // uxSerialPort
            // 
            this.uxSerialPort.ReadTimeout = 5000;
            this.uxSerialPort.WriteTimeout = 2000;
            // 
            // uxGetDisplayStatus
            // 
            this.uxGetDisplayStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxGetDisplayStatus.Location = new System.Drawing.Point(12, 165);
            this.uxGetDisplayStatus.Name = "uxGetDisplayStatus";
            this.uxGetDisplayStatus.Size = new System.Drawing.Size(260, 84);
            this.uxGetDisplayStatus.TabIndex = 0;
            this.uxGetDisplayStatus.Text = "Pobierz status wyświetlacza";
            this.uxGetDisplayStatus.UseVisualStyleBackColor = true;
            this.uxGetDisplayStatus.Click += new System.EventHandler(this.uxGetDisplayStatus_Click);
            // 
            // uxSerialPorts
            // 
            this.uxSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxSerialPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxSerialPorts.FormattingEnabled = true;
            this.uxSerialPorts.Location = new System.Drawing.Point(12, 12);
            this.uxSerialPorts.Name = "uxSerialPorts";
            this.uxSerialPorts.Size = new System.Drawing.Size(185, 32);
            this.uxSerialPorts.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.uxSerialPorts);
            this.Controls.Add(this.uxGetDisplayStatus);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort uxSerialPort;
        private System.Windows.Forms.Button uxGetDisplayStatus;
        private System.Windows.Forms.ComboBox uxSerialPorts;
    }
}