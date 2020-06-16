namespace WindowsFormsApp1
{
    partial class AuthScreen
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
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.txtUserEmail = new System.Windows.Forms.Label();
            this.tbUserEmail = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(0, 1);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(205, 35);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "Sign-In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(202, 1);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(205, 35);
            this.btnSignUp.TabIndex = 1;
            this.btnSignUp.Text = "Sign-Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.AutoSize = true;
            this.txtUserEmail.Location = new System.Drawing.Point(17, 63);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(60, 13);
            this.txtUserEmail.TabIndex = 2;
            this.txtUserEmail.Text = "User Email:";
            // 
            // tbUserEmail
            // 
            this.tbUserEmail.Location = new System.Drawing.Point(83, 60);
            this.tbUserEmail.Name = "tbUserEmail";
            this.tbUserEmail.Size = new System.Drawing.Size(282, 20);
            this.tbUserEmail.TabIndex = 3;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(83, 88);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(282, 20);
            this.tbPassword.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.Location = new System.Drawing.Point(17, 91);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(56, 13);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "Password:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(83, 114);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(282, 20);
            this.tbUserName.TabIndex = 7;
            this.tbUserName.Visible = false;
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSize = true;
            this.txtUserName.Location = new System.Drawing.Point(17, 117);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(63, 13);
            this.txtUserName.TabIndex = 6;
            this.txtUserName.Text = "User Name:";
            this.txtUserName.Visible = false;
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(289, 141);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 8;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // AuthScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(407, 176);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.tbUserEmail);
            this.Controls.Add(this.txtUserEmail);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnSignIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(423, 235);
            this.Name = "AuthScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AuthScreen_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label txtUserEmail;
        private System.Windows.Forms.TextBox tbUserEmail;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label txtPassword;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label txtUserName;
        private System.Windows.Forms.Button btnEnter;
    }
}