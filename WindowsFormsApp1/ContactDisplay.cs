using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ContactDisplay : UserControl
    {
        public ContactDisplay()
        {
            InitializeComponent();
        }
        private string _userName;
        private string _userEmail;
        private string _pairedId;
        private string _pictureProfile;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; txtUserName.Text = value; }
        }

        public string UserEmail
        {
            get { return _userEmail; }
            set { _userEmail = value; txtUserEmail.Text = value; }
        }

        public string PairedId
        {
            get { return _pairedId; }
            set { _pairedId = value; txtPairedId.Text = value; }
        }

        public string PictureProfile
        {
            get { return _pictureProfile; }
            set { _pictureProfile = value; rpbProfilePic.Load(value); }
        }

        private void ContactDisplay_Click(object sender, EventArgs e)
        {
            Form1.pathToContactMsg = txtUserEmail.Text;
            Form1.pathToPairedId = txtPairedId.Text;
            Form1.pathToContactName = txtUserName.Text;
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            Form1.pathToContactMsg = txtUserEmail.Text;
            Form1.pathToPairedId = txtPairedId.Text;
            Form1.pathToContactName = txtUserName.Text;
        }

        private void txtUserEmail_Click(object sender, EventArgs e)
        {
            Form1.pathToContactMsg = txtUserEmail.Text;
            Form1.pathToPairedId = txtPairedId.Text;
            Form1.pathToContactName = txtUserName.Text;
        }
    }
}
