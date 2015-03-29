namespace DisplayMessageSender.Forms
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
            this.uxMessage = new System.Windows.Forms.TextBox();
            this.uxLabel = new System.Windows.Forms.Label();
            this.uxSendMessage = new System.Windows.Forms.Button();
            this.uxClose = new System.Windows.Forms.Button();
            this.uxLabelSerialPort = new System.Windows.Forms.Label();
            this.uxSerialPorts = new System.Windows.Forms.ComboBox();
            this.uxMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // uxMessage
            // 
            this.uxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxMessage.Location = new System.Drawing.Point(16, 98);
            this.uxMessage.Name = "uxMessage";
            this.uxMessage.Size = new System.Drawing.Size(454, 29);
            this.uxMessage.TabIndex = 0;
            // 
            // uxLabel
            // 
            this.uxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxLabel.AutoSize = true;
            this.uxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxLabel.Location = new System.Drawing.Point(12, 71);
            this.uxLabel.Name = "uxLabel";
            this.uxLabel.Size = new System.Drawing.Size(162, 24);
            this.uxLabel.TabIndex = 1;
            this.uxLabel.Text = "Wpisz wiadomość";
            // 
            // uxSendMessage
            // 
            this.uxSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxSendMessage.Location = new System.Drawing.Point(16, 167);
            this.uxSendMessage.Name = "uxSendMessage";
            this.uxSendMessage.Size = new System.Drawing.Size(454, 42);
            this.uxSendMessage.TabIndex = 2;
            this.uxSendMessage.Text = "Wyślij";
            this.uxSendMessage.UseVisualStyleBackColor = true;
            this.uxSendMessage.Click += new System.EventHandler(this.uxSendMessage_Click);
            // 
            // uxClose
            // 
            this.uxClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxClose.Location = new System.Drawing.Point(16, 215);
            this.uxClose.Name = "uxClose";
            this.uxClose.Size = new System.Drawing.Size(454, 56);
            this.uxClose.TabIndex = 3;
            this.uxClose.Text = "Zamknij";
            this.uxClose.UseVisualStyleBackColor = true;
            // 
            // uxLabelSerialPort
            // 
            this.uxLabelSerialPort.AutoSize = true;
            this.uxLabelSerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxLabelSerialPort.Location = new System.Drawing.Point(12, 9);
            this.uxLabelSerialPort.Name = "uxLabelSerialPort";
            this.uxLabelSerialPort.Size = new System.Drawing.Size(164, 24);
            this.uxLabelSerialPort.TabIndex = 4;
            this.uxLabelSerialPort.Text = "Wybierz port COM";
            // 
            // uxSerialPorts
            // 
            this.uxSerialPorts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxSerialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxSerialPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxSerialPorts.FormattingEnabled = true;
            this.uxSerialPorts.Location = new System.Drawing.Point(16, 36);
            this.uxSerialPorts.Name = "uxSerialPorts";
            this.uxSerialPorts.Size = new System.Drawing.Size(454, 32);
            this.uxSerialPorts.TabIndex = 5;
            // 
            // uxMode
            // 
            this.uxMode.AutoSize = true;
            this.uxMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uxMode.Location = new System.Drawing.Point(16, 133);
            this.uxMode.Name = "uxMode";
            this.uxMode.Size = new System.Drawing.Size(305, 28);
            this.uxMode.TabIndex = 6;
            this.uxMode.Text = "Ustaw wiadomość jako domyślna";
            this.uxMode.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 283);
            this.Controls.Add(this.uxMode);
            this.Controls.Add(this.uxSerialPorts);
            this.Controls.Add(this.uxLabelSerialPort);
            this.Controls.Add(this.uxClose);
            this.Controls.Add(this.uxSendMessage);
            this.Controls.Add(this.uxLabel);
            this.Controls.Add(this.uxMessage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 322);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 322);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisplayMessageSender";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uxMessage;
        private System.Windows.Forms.Label uxLabel;
        private System.Windows.Forms.Button uxSendMessage;
        private System.Windows.Forms.Button uxClose;
        private System.Windows.Forms.Label uxLabelSerialPort;
        private System.Windows.Forms.ComboBox uxSerialPorts;
        private System.Windows.Forms.CheckBox uxMode;
    }
}

