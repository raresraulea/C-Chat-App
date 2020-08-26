namespace Client_App
{
    partial class SettingForm
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
            this.PortTB = new System.Windows.Forms.TextBox();
            this.IPAddressTB = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.PortLabel = new System.Windows.Forms.Label();
            this.ServerIPLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PortTB
            // 
            this.PortTB.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortTB.ForeColor = System.Drawing.Color.DimGray;
            this.PortTB.Location = new System.Drawing.Point(136, 73);
            this.PortTB.Margin = new System.Windows.Forms.Padding(5);
            this.PortTB.Name = "PortTB";
            this.PortTB.Size = new System.Drawing.Size(262, 23);
            this.PortTB.TabIndex = 13;
            this.PortTB.Text = "1302";
            // 
            // IPAddressTB
            // 
            this.IPAddressTB.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPAddressTB.ForeColor = System.Drawing.Color.DimGray;
            this.IPAddressTB.Location = new System.Drawing.Point(136, 30);
            this.IPAddressTB.Margin = new System.Windows.Forms.Padding(5);
            this.IPAddressTB.Name = "IPAddressTB";
            this.IPAddressTB.Size = new System.Drawing.Size(262, 23);
            this.IPAddressTB.TabIndex = 12;
            this.IPAddressTB.Text = "127.0.0.1";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ConnectBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ConnectBtn.Location = new System.Drawing.Point(28, 122);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(128, 50);
            this.ConnectBtn.TabIndex = 11;
            this.ConnectBtn.Text = "Save Settings";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortLabel.Location = new System.Drawing.Point(25, 79);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(41, 17);
            this.PortLabel.TabIndex = 10;
            this.PortLabel.Text = "Port";
            // 
            // ServerIPLabel
            // 
            this.ServerIPLabel.AutoSize = true;
            this.ServerIPLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerIPLabel.Location = new System.Drawing.Point(25, 35);
            this.ServerIPLabel.Name = "ServerIPLabel";
            this.ServerIPLabel.Size = new System.Drawing.Size(94, 17);
            this.ServerIPLabel.TabIndex = 9;
            this.ServerIPLabel.Text = "IP Address";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 211);
            this.Controls.Add(this.PortTB);
            this.Controls.Add(this.IPAddressTB);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.ServerIPLabel);
            this.Name = "SettingForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PortTB;
        private System.Windows.Forms.TextBox IPAddressTB;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label ServerIPLabel;
    }
}