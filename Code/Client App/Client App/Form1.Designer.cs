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
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SignUpBtn = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.MessagesListView = new System.Windows.Forms.ListView();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.onlineUsersLV = new System.Windows.Forms.ListView();
            this.GroupChatTitle = new System.Windows.Forms.Label();
            this.OnlineUsersTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.messageBox.Enabled = false;
            this.messageBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.messageBox.Location = new System.Drawing.Point(51, 628);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(432, 35);
            this.messageBox.TabIndex = 0;
            this.messageBox.TextChanged += new System.EventHandler(this.messageBox_TextChanged);
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.sendMessageButton.Enabled = false;
            this.sendMessageButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.sendMessageButton.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendMessageButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sendMessageButton.Location = new System.Drawing.Point(489, 626);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(110, 37);
            this.sendMessageButton.TabIndex = 1;
            this.sendMessageButton.Text = "Send";
            this.sendMessageButton.UseVisualStyleBackColor = false;
            this.sendMessageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LoginBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LoginBtn.Location = new System.Drawing.Point(348, 213);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(128, 50);
            this.LoginBtn.TabIndex = 12;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // SignUpBtn
            // 
            this.SignUpBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.SignUpBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpBtn.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.SignUpBtn.Location = new System.Drawing.Point(534, 213);
            this.SignUpBtn.Name = "SignUpBtn";
            this.SignUpBtn.Size = new System.Drawing.Size(128, 50);
            this.SignUpBtn.TabIndex = 11;
            this.SignUpBtn.Text = "Sign Up";
            this.SignUpBtn.UseVisualStyleBackColor = false;
            this.SignUpBtn.Click += new System.EventHandler(this.SignUpBtn_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(316, 147);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(84, 17);
            this.PasswordLabel.TabIndex = 10;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(316, 103);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(85, 17);
            this.UsernameLabel.TabIndex = 9;
            this.UsernameLabel.Text = "Username";
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.ConnectionLabel.Location = new System.Drawing.Point(827, 646);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(123, 17);
            this.ConnectionLabel.TabIndex = 24;
            this.ConnectionLabel.Text = "Not Connected";
            this.ConnectionLabel.Click += new System.EventHandler(this.label6_Click);
            // 
            // MessagesListView
            // 
            this.MessagesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessagesListView.HideSelection = false;
            this.MessagesListView.Location = new System.Drawing.Point(51, 333);
            this.MessagesListView.Name = "MessagesListView";
            this.MessagesListView.Size = new System.Drawing.Size(548, 287);
            this.MessagesListView.TabIndex = 26;
            this.MessagesListView.UseCompatibleStateImageBehavior = false;
            this.MessagesListView.View = System.Windows.Forms.View.List;
            // 
            // UsernameTB
            // 
            this.UsernameTB.BackColor = System.Drawing.Color.White;
            this.UsernameTB.Location = new System.Drawing.Point(428, 103);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(262, 22);
            this.UsernameTB.TabIndex = 27;
            // 
            // PasswordTB
            // 
            this.PasswordTB.BackColor = System.Drawing.Color.White;
            this.PasswordTB.Location = new System.Drawing.Point(428, 147);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(261, 22);
            this.PasswordTB.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.Font = new System.Drawing.Font("Verdana", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button1.Location = new System.Drawing.Point(51, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 29;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(454, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 44);
            this.label1.TabIndex = 30;
            this.label1.Text = "Log In!";
            // 
            // onlineUsersLV
            // 
            this.onlineUsersLV.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.onlineUsersLV.HideSelection = false;
            this.onlineUsersLV.Location = new System.Drawing.Point(693, 333);
            this.onlineUsersLV.MultiSelect = false;
            this.onlineUsersLV.Name = "onlineUsersLV";
            this.onlineUsersLV.Size = new System.Drawing.Size(257, 287);
            this.onlineUsersLV.TabIndex = 31;
            this.onlineUsersLV.UseCompatibleStateImageBehavior = false;
            this.onlineUsersLV.View = System.Windows.Forms.View.List;
            this.onlineUsersLV.SelectedIndexChanged += new System.EventHandler(this.onlineUsersLV_SelectedIndexChanged_1);
            // 
            // GroupChatTitle
            // 
            this.GroupChatTitle.AutoSize = true;
            this.GroupChatTitle.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupChatTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GroupChatTitle.Location = new System.Drawing.Point(47, 310);
            this.GroupChatTitle.Name = "GroupChatTitle";
            this.GroupChatTitle.Size = new System.Drawing.Size(116, 20);
            this.GroupChatTitle.TabIndex = 32;
            this.GroupChatTitle.Text = "Group Chat";
            // 
            // OnlineUsersTitle
            // 
            this.OnlineUsersTitle.AutoSize = true;
            this.OnlineUsersTitle.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnlineUsersTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.OnlineUsersTitle.Location = new System.Drawing.Point(689, 310);
            this.OnlineUsersTitle.Name = "OnlineUsersTitle";
            this.OnlineUsersTitle.Size = new System.Drawing.Size(129, 20);
            this.OnlineUsersTitle.TabIndex = 33;
            this.OnlineUsersTitle.Text = "Online Users";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1004, 693);
            this.Controls.Add(this.OnlineUsersTitle);
            this.Controls.Add(this.GroupChatTitle);
            this.Controls.Add(this.onlineUsersLV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.MessagesListView);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.SignUpBtn);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
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
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button SignUpBtn;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.ListView MessagesListView;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView onlineUsersLV;
        private System.Windows.Forms.Label GroupChatTitle;
        private System.Windows.Forms.Label OnlineUsersTitle;
    }
}

