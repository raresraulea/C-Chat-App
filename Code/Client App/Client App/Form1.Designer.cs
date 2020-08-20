namespace Client_App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("a");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("b");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.ServerIPLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.IPAddressTB = new System.Windows.Forms.TextBox();
            this.PortTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SignUpBtn = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.AdminBoardUsernameTB = new System.Windows.Forms.TextBox();
            this.BlockBtn = new System.Windows.Forms.Button();
            this.WarnBtn = new System.Windows.Forms.Button();
            this.AdminBoardLabel = new System.Windows.Forms.Label();
            this.DeleteAccBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MessagesListView = new System.Windows.Forms.ListView();
            this.Sender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.messageBox.Location = new System.Drawing.Point(22, 629);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(376, 22);
            this.messageBox.TabIndex = 0;
            this.messageBox.Text = "Type...";
            this.messageBox.TextChanged += new System.EventHandler(this.messageBox_TextChanged);
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(423, 629);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(75, 23);
            this.sendMessageButton.TabIndex = 1;
            this.sendMessageButton.Text = "Send";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ServerIPLabel
            // 
            this.ServerIPLabel.AutoSize = true;
            this.ServerIPLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerIPLabel.Location = new System.Drawing.Point(24, 29);
            this.ServerIPLabel.Name = "ServerIPLabel";
            this.ServerIPLabel.Size = new System.Drawing.Size(94, 17);
            this.ServerIPLabel.TabIndex = 2;
            this.ServerIPLabel.Text = "IP Address";
            this.ServerIPLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortLabel.Location = new System.Drawing.Point(24, 73);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(41, 17);
            this.PortLabel.TabIndex = 3;
            this.PortLabel.Text = "Port";
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.BackColor = System.Drawing.Color.LightSalmon;
            this.DisconnectBtn.Enabled = false;
            this.DisconnectBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DisconnectBtn.Location = new System.Drawing.Point(630, 29);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(128, 50);
            this.DisconnectBtn.TabIndex = 4;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = false;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ConnectBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ConnectBtn.Location = new System.Drawing.Point(429, 29);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(128, 50);
            this.ConnectBtn.TabIndex = 6;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // IPAddressTB
            // 
            this.IPAddressTB.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPAddressTB.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.IPAddressTB.Location = new System.Drawing.Point(135, 24);
            this.IPAddressTB.Margin = new System.Windows.Forms.Padding(5);
            this.IPAddressTB.Name = "IPAddressTB";
            this.IPAddressTB.Size = new System.Drawing.Size(262, 23);
            this.IPAddressTB.TabIndex = 7;
            this.IPAddressTB.Text = "IP Address...";
            // 
            // PortTB
            // 
            this.PortTB.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortTB.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.PortTB.Location = new System.Drawing.Point(135, 67);
            this.PortTB.Margin = new System.Windows.Forms.Padding(5);
            this.PortTB.Name = "PortTB";
            this.PortTB.Size = new System.Drawing.Size(262, 23);
            this.PortTB.TabIndex = 8;
            this.PortTB.Text = "Port...";
            // 
            // PasswordTB
            // 
            this.PasswordTB.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTB.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.PasswordTB.Location = new System.Drawing.Point(135, 179);
            this.PasswordTB.Margin = new System.Windows.Forms.Padding(5);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(262, 23);
            this.PasswordTB.TabIndex = 14;
            this.PasswordTB.Text = "Password...";
            // 
            // UsernameTB
            // 
            this.UsernameTB.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTB.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.UsernameTB.Location = new System.Drawing.Point(135, 135);
            this.UsernameTB.Margin = new System.Windows.Forms.Padding(5);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(262, 23);
            this.UsernameTB.TabIndex = 13;
            this.UsernameTB.Text = "Username..";
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LoginBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LoginBtn.Location = new System.Drawing.Point(429, 141);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(128, 50);
            this.LoginBtn.TabIndex = 12;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            // 
            // SignUpBtn
            // 
            this.SignUpBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.SignUpBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpBtn.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.SignUpBtn.Location = new System.Drawing.Point(630, 141);
            this.SignUpBtn.Name = "SignUpBtn";
            this.SignUpBtn.Size = new System.Drawing.Size(128, 50);
            this.SignUpBtn.TabIndex = 11;
            this.SignUpBtn.Text = "Sign Up";
            this.SignUpBtn.UseVisualStyleBackColor = false;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(24, 180);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(84, 17);
            this.PasswordLabel.TabIndex = 10;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(24, 136);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(85, 17);
            this.UsernameLabel.TabIndex = 9;
            this.UsernameLabel.Text = "Username";
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.BackColor = System.Drawing.Color.LightSalmon;
            this.LogoutBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LogoutBtn.Location = new System.Drawing.Point(832, 141);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(128, 50);
            this.LogoutBtn.TabIndex = 15;
            this.LogoutBtn.Text = "Logout";
            this.LogoutBtn.UseVisualStyleBackColor = false;
            // 
            // AdminBoardUsernameTB
            // 
            this.AdminBoardUsernameTB.Enabled = false;
            this.AdminBoardUsernameTB.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminBoardUsernameTB.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.AdminBoardUsernameTB.Location = new System.Drawing.Point(136, 260);
            this.AdminBoardUsernameTB.Margin = new System.Windows.Forms.Padding(5);
            this.AdminBoardUsernameTB.Name = "AdminBoardUsernameTB";
            this.AdminBoardUsernameTB.Size = new System.Drawing.Size(262, 23);
            this.AdminBoardUsernameTB.TabIndex = 19;
            this.AdminBoardUsernameTB.Text = "Username...";
            this.AdminBoardUsernameTB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BlockBtn
            // 
            this.BlockBtn.BackColor = System.Drawing.Color.Tomato;
            this.BlockBtn.Enabled = false;
            this.BlockBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlockBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.BlockBtn.Location = new System.Drawing.Point(630, 253);
            this.BlockBtn.Name = "BlockBtn";
            this.BlockBtn.Size = new System.Drawing.Size(128, 50);
            this.BlockBtn.TabIndex = 18;
            this.BlockBtn.Text = "Block";
            this.BlockBtn.UseVisualStyleBackColor = false;
            this.BlockBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // WarnBtn
            // 
            this.WarnBtn.BackColor = System.Drawing.Color.SandyBrown;
            this.WarnBtn.Enabled = false;
            this.WarnBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarnBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.WarnBtn.Location = new System.Drawing.Point(429, 250);
            this.WarnBtn.Name = "WarnBtn";
            this.WarnBtn.Size = new System.Drawing.Size(128, 50);
            this.WarnBtn.TabIndex = 17;
            this.WarnBtn.Text = "Warn";
            this.WarnBtn.UseVisualStyleBackColor = false;
            this.WarnBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdminBoardLabel
            // 
            this.AdminBoardLabel.AutoSize = true;
            this.AdminBoardLabel.Enabled = false;
            this.AdminBoardLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminBoardLabel.Location = new System.Drawing.Point(24, 263);
            this.AdminBoardLabel.Name = "AdminBoardLabel";
            this.AdminBoardLabel.Size = new System.Drawing.Size(109, 17);
            this.AdminBoardLabel.TabIndex = 16;
            this.AdminBoardLabel.Text = "Admin Board";
            this.AdminBoardLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // DeleteAccBtn
            // 
            this.DeleteAccBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.DeleteAccBtn.Enabled = false;
            this.DeleteAccBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAccBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DeleteAccBtn.Location = new System.Drawing.Point(832, 253);
            this.DeleteAccBtn.Name = "DeleteAccBtn";
            this.DeleteAccBtn.Size = new System.Drawing.Size(141, 50);
            this.DeleteAccBtn.TabIndex = 20;
            this.DeleteAccBtn.Text = "Delete Account";
            this.DeleteAccBtn.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-5, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1088, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-45, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1088, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-42, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1088, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.ConnectionLabel.Location = new System.Drawing.Point(844, 46);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(123, 17);
            this.ConnectionLabel.TabIndex = 24;
            this.ConnectionLabel.Text = "Not Connected";
            this.ConnectionLabel.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Location = new System.Drawing.Point(695, 610);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Not Connected";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // MessagesListView
            // 
            this.MessagesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sender,
            this.Message});
            this.MessagesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessagesListView.HideSelection = false;
            listViewItem6.IndentCount = 1;
            this.MessagesListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.MessagesListView.Location = new System.Drawing.Point(22, 333);
            this.MessagesListView.Name = "MessagesListView";
            this.MessagesListView.Size = new System.Drawing.Size(476, 276);
            this.MessagesListView.TabIndex = 26;
            this.MessagesListView.UseCompatibleStateImageBehavior = false;
            this.MessagesListView.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1004, 693);
            this.Controls.Add(this.MessagesListView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DeleteAccBtn);
            this.Controls.Add(this.AdminBoardUsernameTB);
            this.Controls.Add(this.BlockBtn);
            this.Controls.Add(this.WarnBtn);
            this.Controls.Add(this.AdminBoardLabel);
            this.Controls.Add(this.LogoutBtn);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.SignUpBtn);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PortTB);
            this.Controls.Add(this.IPAddressTB);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.ServerIPLabel);
            this.Controls.Add(this.sendMessageButton);
            this.Controls.Add(this.messageBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.Label ServerIPLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox IPAddressTB;
        private System.Windows.Forms.TextBox PortTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button SignUpBtn;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.TextBox AdminBoardUsernameTB;
        private System.Windows.Forms.Button BlockBtn;
        private System.Windows.Forms.Button WarnBtn;
        private System.Windows.Forms.Label AdminBoardLabel;
        private System.Windows.Forms.Button DeleteAccBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView MessagesListView;
        private System.Windows.Forms.ColumnHeader Sender;
        private System.Windows.Forms.ColumnHeader Message;
    }
}

