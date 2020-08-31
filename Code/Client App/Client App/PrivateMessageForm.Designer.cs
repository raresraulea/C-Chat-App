namespace Client_App
{
    partial class PrivateMessageForm
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
            this.PrivateChatTitle = new System.Windows.Forms.Label();
            this.MessagesListView = new System.Windows.Forms.ListView();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrivateChatTitle
            // 
            this.PrivateChatTitle.AutoSize = true;
            this.PrivateChatTitle.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrivateChatTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PrivateChatTitle.Location = new System.Drawing.Point(21, 21);
            this.PrivateChatTitle.Name = "PrivateChatTitle";
            this.PrivateChatTitle.Size = new System.Drawing.Size(174, 20);
            this.PrivateChatTitle.TabIndex = 36;
            this.PrivateChatTitle.Text = "Private Chat with";
            this.PrivateChatTitle.Click += new System.EventHandler(this.PrivateChatTitle_Click);
            // 
            // MessagesListView
            // 
            this.MessagesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessagesListView.HideSelection = false;
            this.MessagesListView.Location = new System.Drawing.Point(25, 58);
            this.MessagesListView.Name = "MessagesListView";
            this.MessagesListView.Size = new System.Drawing.Size(522, 279);
            this.MessagesListView.TabIndex = 35;
            this.MessagesListView.UseCompatibleStateImageBehavior = false;
            this.MessagesListView.View = System.Windows.Forms.View.List;
            this.MessagesListView.SelectedIndexChanged += new System.EventHandler(this.MessagesListView_SelectedIndexChanged);
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.sendMessageButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.sendMessageButton.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendMessageButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sendMessageButton.Location = new System.Drawing.Point(463, 351);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(84, 29);
            this.sendMessageButton.TabIndex = 34;
            this.sendMessageButton.Text = "Send";
            this.sendMessageButton.UseVisualStyleBackColor = false;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.messageBox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.messageBox.Location = new System.Drawing.Point(25, 353);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(406, 27);
            this.messageBox.TabIndex = 33;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(22, 400);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(35, 17);
            this.textLabel.TabIndex = 37;
            this.textLabel.Text = "Text";
            // 
            // PrivateMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 539);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.PrivateChatTitle);
            this.Controls.Add(this.MessagesListView);
            this.Controls.Add(this.sendMessageButton);
            this.Controls.Add(this.messageBox);
            this.Name = "PrivateMessageForm";
            this.Text = "PrivateMessageForm";
            this.Load += new System.EventHandler(this.PrivateMessageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PrivateChatTitle;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.TextBox messageBox;
        public System.Windows.Forms.ListView MessagesListView;
        public System.Windows.Forms.Label textLabel;
    }
}