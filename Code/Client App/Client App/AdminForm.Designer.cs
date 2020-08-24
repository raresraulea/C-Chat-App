namespace Client_App
{
    partial class AdminForm
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
            this.DeleteAccBtn = new System.Windows.Forms.Button();
            this.AdminBoardUsernameTB = new System.Windows.Forms.TextBox();
            this.BlockBtn = new System.Windows.Forms.Button();
            this.WarnBtn = new System.Windows.Forms.Button();
            this.AdminBoardLabel = new System.Windows.Forms.Label();
            this.AdminBoardUsernameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DeleteAccBtn
            // 
            this.DeleteAccBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.DeleteAccBtn.Enabled = false;
            this.DeleteAccBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteAccBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.DeleteAccBtn.Location = new System.Drawing.Point(448, 124);
            this.DeleteAccBtn.Name = "DeleteAccBtn";
            this.DeleteAccBtn.Size = new System.Drawing.Size(141, 50);
            this.DeleteAccBtn.TabIndex = 25;
            this.DeleteAccBtn.Text = "Delete Account";
            this.DeleteAccBtn.UseVisualStyleBackColor = false;
            // 
            // AdminBoardUsernameTB
            // 
            this.AdminBoardUsernameTB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AdminBoardUsernameTB.Enabled = false;
            this.AdminBoardUsernameTB.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminBoardUsernameTB.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.AdminBoardUsernameTB.Location = new System.Drawing.Point(185, 61);
            this.AdminBoardUsernameTB.Margin = new System.Windows.Forms.Padding(5);
            this.AdminBoardUsernameTB.Name = "AdminBoardUsernameTB";
            this.AdminBoardUsernameTB.Size = new System.Drawing.Size(251, 23);
            this.AdminBoardUsernameTB.TabIndex = 24;
            // 
            // BlockBtn
            // 
            this.BlockBtn.BackColor = System.Drawing.Color.Chocolate;
            this.BlockBtn.Enabled = false;
            this.BlockBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlockBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.BlockBtn.Location = new System.Drawing.Point(244, 124);
            this.BlockBtn.Name = "BlockBtn";
            this.BlockBtn.Size = new System.Drawing.Size(128, 50);
            this.BlockBtn.TabIndex = 23;
            this.BlockBtn.Text = "Block";
            this.BlockBtn.UseVisualStyleBackColor = false;
            // 
            // WarnBtn
            // 
            this.WarnBtn.BackColor = System.Drawing.Color.LightCoral;
            this.WarnBtn.Enabled = false;
            this.WarnBtn.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WarnBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.WarnBtn.Location = new System.Drawing.Point(31, 124);
            this.WarnBtn.Name = "WarnBtn";
            this.WarnBtn.Size = new System.Drawing.Size(128, 50);
            this.WarnBtn.TabIndex = 22;
            this.WarnBtn.Text = "Warn";
            this.WarnBtn.UseVisualStyleBackColor = false;
            // 
            // AdminBoardLabel
            // 
            this.AdminBoardLabel.AutoSize = true;
            this.AdminBoardLabel.Enabled = false;
            this.AdminBoardLabel.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminBoardLabel.Location = new System.Drawing.Point(250, 9);
            this.AdminBoardLabel.Name = "AdminBoardLabel";
            this.AdminBoardLabel.Size = new System.Drawing.Size(109, 17);
            this.AdminBoardLabel.TabIndex = 21;
            this.AdminBoardLabel.Text = "Admin Board";
            // 
            // AdminBoardUsernameLbl
            // 
            this.AdminBoardUsernameLbl.AutoSize = true;
            this.AdminBoardUsernameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminBoardUsernameLbl.Location = new System.Drawing.Point(78, 64);
            this.AdminBoardUsernameLbl.Name = "AdminBoardUsernameLbl";
            this.AdminBoardUsernameLbl.Size = new System.Drawing.Size(81, 17);
            this.AdminBoardUsernameLbl.TabIndex = 26;
            this.AdminBoardUsernameLbl.Text = "Username";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(626, 201);
            this.Controls.Add(this.AdminBoardUsernameLbl);
            this.Controls.Add(this.DeleteAccBtn);
            this.Controls.Add(this.AdminBoardUsernameTB);
            this.Controls.Add(this.BlockBtn);
            this.Controls.Add(this.WarnBtn);
            this.Controls.Add(this.AdminBoardLabel);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteAccBtn;
        private System.Windows.Forms.TextBox AdminBoardUsernameTB;
        private System.Windows.Forms.Button BlockBtn;
        private System.Windows.Forms.Button WarnBtn;
        private System.Windows.Forms.Label AdminBoardLabel;
        private System.Windows.Forms.Label AdminBoardUsernameLbl;
    }
}