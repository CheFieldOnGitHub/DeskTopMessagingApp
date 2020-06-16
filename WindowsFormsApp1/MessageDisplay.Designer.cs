namespace WindowsFormsApp1
{
    partial class MessageDisplay
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
            this.txtMsg = new System.Windows.Forms.Label();
            this.imgMsg = new System.Windows.Forms.PictureBox();
            this.txtId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgMsg)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMsg
            // 
            this.txtMsg.AllowDrop = true;
            this.txtMsg.AutoSize = true;
            this.txtMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtMsg.Location = new System.Drawing.Point(3, 20);
            this.txtMsg.MaximumSize = new System.Drawing.Size(300, 0);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(173, 17);
            this.txtMsg.TabIndex = 0;
            this.txtMsg.Tag = "";
            this.txtMsg.Text = "This is a message display!";
            // 
            // imgMsg
            // 
            this.imgMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgMsg.Location = new System.Drawing.Point(0, 20);
            this.imgMsg.Name = "imgMsg";
            this.imgMsg.Size = new System.Drawing.Size(300, 300);
            this.imgMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMsg.TabIndex = 1;
            this.imgMsg.TabStop = false;
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.CadetBlue;
            this.txtId.Location = new System.Drawing.Point(4, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(103, 13);
            this.txtId.TabIndex = 2;
            this.txtId.Text = "some@example.com";
            // 
            // MessageDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.imgMsg);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Name = "MessageDisplay";
            this.Size = new System.Drawing.Size(300, 320);
            ((System.ComponentModel.ISupportInitialize)(this.imgMsg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtMsg;
        private System.Windows.Forms.PictureBox imgMsg;
        private System.Windows.Forms.Label txtId;
    }
}
