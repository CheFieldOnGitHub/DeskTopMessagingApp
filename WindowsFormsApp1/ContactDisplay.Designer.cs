namespace WindowsFormsApp1
{
    partial class ContactDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUserName = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.Label();
            this.txtPairedId = new System.Windows.Forms.Label();
            this.rpbProfilePic = new WindowsFormsApp1.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rpbProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSize = true;
            this.txtUserName.Location = new System.Drawing.Point(49, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(35, 13);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "Name";
            this.txtUserName.Click += new System.EventHandler(this.txtUserName_Click);
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.AutoSize = true;
            this.txtUserEmail.Location = new System.Drawing.Point(49, 30);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(104, 13);
            this.txtUserEmail.TabIndex = 2;
            this.txtUserEmail.Text = "email@example.com";
            this.txtUserEmail.Click += new System.EventHandler(this.txtUserEmail_Click);
            // 
            // txtPairedId
            // 
            this.txtPairedId.AutoSize = true;
            this.txtPairedId.Location = new System.Drawing.Point(234, 30);
            this.txtPairedId.Name = "txtPairedId";
            this.txtPairedId.Size = new System.Drawing.Size(13, 13);
            this.txtPairedId.TabIndex = 3;
            this.txtPairedId.Text = "0";
            // 
            // rpbProfilePic
            // 
            this.rpbProfilePic.BackColor = System.Drawing.Color.DarkGray;
            this.rpbProfilePic.Location = new System.Drawing.Point(3, 3);
            this.rpbProfilePic.Name = "rpbProfilePic";
            this.rpbProfilePic.Size = new System.Drawing.Size(40, 40);
            this.rpbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rpbProfilePic.TabIndex = 0;
            this.rpbProfilePic.TabStop = false;
            // 
            // ContactDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPairedId);
            this.Controls.Add(this.txtUserEmail);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.rpbProfilePic);
            this.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Name = "ContactDisplay";
            this.Size = new System.Drawing.Size(250, 49);
            this.Click += new System.EventHandler(this.ContactDisplay_Click);
            ((System.ComponentModel.ISupportInitialize)(this.rpbProfilePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundPictureBox rpbProfilePic;
        private System.Windows.Forms.Label txtUserName;
        private System.Windows.Forms.Label txtUserEmail;
        private System.Windows.Forms.Label txtPairedId;
    }
}
