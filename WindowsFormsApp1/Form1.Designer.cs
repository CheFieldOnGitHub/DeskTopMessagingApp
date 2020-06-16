namespace WindowsFormsApp1
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
            this.components = new System.ComponentModel.Container();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtContName = new System.Windows.Forms.Label();
            this.btnImgMsg = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSignInOut = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.Label();
            this.fpMsgs = new System.Windows.Forms.FlowLayoutPanel();
            this.fpContacts = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ribPicProfile = new WindowsFormsApp1.RoundPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribPicProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.AutoCompleteCustomSource.AddRange(new string[] {
            "search",
            "custom",
            "find",
            "help"});
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbSearch.Location = new System.Drawing.Point(21, 10);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(131, 20);
            this.tbSearch.TabIndex = 4;
            this.tbSearch.Text = "Search...";
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(158, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(37, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Go";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtContName
            // 
            this.txtContName.AutoSize = true;
            this.txtContName.Location = new System.Drawing.Point(218, 13);
            this.txtContName.Name = "txtContName";
            this.txtContName.Size = new System.Drawing.Size(35, 13);
            this.txtContName.TabIndex = 7;
            this.txtContName.Text = "label1";
            // 
            // btnImgMsg
            // 
            this.btnImgMsg.Location = new System.Drawing.Point(196, 403);
            this.btnImgMsg.Name = "btnImgMsg";
            this.btnImgMsg.Size = new System.Drawing.Size(75, 23);
            this.btnImgMsg.TabIndex = 8;
            this.btnImgMsg.Text = "Image";
            this.btnImgMsg.UseVisualStyleBackColor = true;
            this.btnImgMsg.Click += new System.EventHandler(this.btnImgMsg_Click);
            // 
            // tbMsg
            // 
            this.tbMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMsg.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbMsg.Location = new System.Drawing.Point(277, 405);
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(414, 21);
            this.tbMsg.TabIndex = 9;
            this.tbMsg.Text = "Type a message...";
            this.tbMsg.Enter += new System.EventHandler(this.tbMsg_Enter);
            this.tbMsg.Leave += new System.EventHandler(this.tbMsg_Leave);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(697, 403);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSignInOut
            // 
            this.btnSignInOut.Location = new System.Drawing.Point(697, 18);
            this.btnSignInOut.Name = "btnSignInOut";
            this.btnSignInOut.Size = new System.Drawing.Size(75, 23);
            this.btnSignInOut.TabIndex = 11;
            this.btnSignInOut.Text = "Sign-Out";
            this.btnSignInOut.UseVisualStyleBackColor = true;
            this.btnSignInOut.Click += new System.EventHandler(this.btnSignInOut_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSize = true;
            this.txtUserName.Location = new System.Drawing.Point(631, 23);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(60, 13);
            this.txtUserName.TabIndex = 12;
            this.txtUserName.Text = "User Name";
            // 
            // fpMsgs
            // 
            this.fpMsgs.AutoScroll = true;
            this.fpMsgs.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fpMsgs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpMsgs.Location = new System.Drawing.Point(197, 53);
            this.fpMsgs.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.fpMsgs.Name = "fpMsgs";
            this.fpMsgs.Size = new System.Drawing.Size(575, 346);
            this.fpMsgs.TabIndex = 13;
            this.fpMsgs.WrapContents = false;
            // 
            // fpContacts
            // 
            this.fpContacts.AutoScroll = true;
            this.fpContacts.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fpContacts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpContacts.Location = new System.Drawing.Point(20, 53);
            this.fpContacts.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.fpContacts.Name = "fpContacts";
            this.fpContacts.Padding = new System.Windows.Forms.Padding(3);
            this.fpContacts.Size = new System.Drawing.Size(176, 373);
            this.fpContacts.TabIndex = 14;
            this.fpContacts.WrapContents = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ribPicProfile
            // 
            this.ribPicProfile.BackColor = System.Drawing.Color.DarkGray;
            this.ribPicProfile.Location = new System.Drawing.Point(587, 7);
            this.ribPicProfile.Name = "ribPicProfile";
            this.ribPicProfile.Size = new System.Drawing.Size(40, 40);
            this.ribPicProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ribPicProfile.TabIndex = 15;
            this.ribPicProfile.TabStop = false;
            this.ribPicProfile.Click += new System.EventHandler(this.ribPicProfile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ribPicProfile);
            this.Controls.Add(this.fpContacts);
            this.Controls.Add(this.fpMsgs);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnSignInOut);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.btnImgMsg);
            this.Controls.Add(this.txtContName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribPicProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label txtContName;
        private System.Windows.Forms.Button btnImgMsg;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSignInOut;
        private System.Windows.Forms.Label txtUserName;
        private System.Windows.Forms.FlowLayoutPanel fpMsgs;
        private System.Windows.Forms.FlowLayoutPanel fpContacts;
        private RoundPictureBox ribPicProfile;
        private System.Windows.Forms.Timer timer1;
    }
}

