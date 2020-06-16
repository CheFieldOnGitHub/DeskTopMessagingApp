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
    public partial class MessageDisplay : UserControl
    {
        public MessageDisplay()
        {
            InitializeComponent();    
        }

        private string _message;
        private string _id;
        private String _pictureProfile;
        
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                imgMsg.Visible = false;
                txtMsg.Visible = true;
                txtMsg.Text = value;
            }
        }

        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                txtId.Text = value;
            }
        }

        public string PictureProfile
        {
            get { return _pictureProfile; }
            set
            {
                _pictureProfile = value;
                txtMsg.Visible = false;
                imgMsg.Visible = true;
               
                System.Net.WebRequest request =
            System.Net.WebRequest.Create(value);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream =
                    response.GetResponseStream();
                Bitmap bitmap2 = new Bitmap(responseStream);
                if(bitmap2.Height > bitmap2.Width)
                {
                    imgMsg.Height = 300;
                    double v = (300f / bitmap2.Height) * bitmap2.Width;
                    imgMsg.Width = (int) Math.Round(v);
                    //int r = (int)Math.Round(v);
                    //MessageBox.Show(imgMsg.Width.ToString());
                    //MessageBox.Show(r.ToString());
                }
                else
                {
                    imgMsg.Width = 300;
                    double v = (300f / bitmap2.Width) * bitmap2.Height;
                    //int r = (int)Math.Round(v);
                    imgMsg.Height = (int)Math.Round(v);
                    //MessageBox.Show(imgMsg.Height.ToString());
                    //MessageBox.Show(r.ToString());
                    
                }
                imgMsg.Load(value);
            }
        }
    }
}
