using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace WindowsFormsApp1
{
    public partial class AuthScreen : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "XTYjUlP7zHZgyvneqUoYJ18auiNeQA0QZrQB2y6M",
            BasePath = "https://mchat-ca3c9.firebaseio.com/"

        };

        IFirebaseClient client;
        FirebaseResponse response;

        

        public AuthScreen()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);

            btnSignIn.BackColor = Color.CadetBlue;
            btnSignIn.ForeColor = Color.White;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            btnSignUp.BackColor = default(Color);
            btnSignUp.ForeColor = default(Color);
            btnSignIn.BackColor = Color.CadetBlue;
            btnSignIn.ForeColor = Color.White;
            tbUserName.Clear();
            txtUserName.Visible = false;
            tbUserName.Visible = false;
            

        }

        private void AuthScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            btnSignIn.BackColor = default(Color);
            btnSignIn.ForeColor = default(Color);
            btnSignUp.BackColor = Color.CadetBlue;
            btnSignUp.ForeColor = Color.White;
            txtUserName.Visible = true;
            tbUserName.Visible = true;
        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            var signUpDetails = new
            {
                email = tbUserEmail.Text,
                password = tbPassword.Text,
                name = tbUserName.Text,
                picProfile = "noPic"
            };
            string email;
            if (txtUserName.Visible)
            {
                if(!tbUserEmail.Text.Equals("") && !tbPassword.Text.Equals("") && !tbUserName.Text.Equals(""))
                {
                    try
                    {
                        email = tbUserEmail.Text.Replace('.', '_');
                        response = await client.GetAsync("DemoApp/MessageInfo/ID/" + email + "/email");
                        if (tbUserEmail.Text.Equals(response.ResultAs<string>()))
                        {
                            MessageBox.Show("User already exist!");
                        }
                        else
                        {       
                            await client.SetAsync("DemoApp/MessageInfo/ID/" + email, signUpDetails);
                            await client.SetAsync("DemoApp/MessageInfo/Accounts/" + email + "/Contacts/pairedCount", 0);
                            Properties.Settings.Default.Email = tbUserEmail.Text;
                            Properties.Settings.Default.Name = tbUserName.Text;
                            Properties.Settings.Default.Save();
                            response = await client.GetAsync("DemoApp/Search/UserCount");
                            int count = response.ResultAs<int>() + 1;
                            await client.SetAsync("DemoApp/Search/UserCount", count);
                            await client.SetAsync("DemoApp/Search/Users/" + count.ToString(), tbUserEmail.Text);
                            await client.SetAsync("DemoApp/MessageInfo/Accounts/" + email + "/Contacts/pairedCount", 0);
                            tbUserEmail.Clear();
                            tbPassword.Clear();
                            tbUserName.Clear();
                            this.Hide();
                        }
                        
                    }
                    catch
                    {
                        MessageBox.Show("Error has accured");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Input fields cannot be empty");
                }
                
            }else if (!txtUserName.Visible)
            {
                if (!tbUserEmail.Text.Equals("") && !tbPassword.Text.Equals(""))
                {
                    try
                    {

                        email = tbUserEmail.Text.Replace('.', '_');
                        response = await client.GetAsync("DemoApp/MessageInfo/ID/" + email + "/email");

                        if (tbUserEmail.Text.Equals(response.ResultAs<string>()))
                        {
                            response = await client.GetAsync("DemoApp/MessageInfo/ID/" + email + "/password");
                            if (tbPassword.Text.Equals(response.ResultAs<string>()))
                            {
                                response = await client.GetAsync("DemoApp/MessageInfo/ID/" + email + "/name");
                                Properties.Settings.Default.Email = tbUserEmail.Text;
                                Properties.Settings.Default.Name = response.ResultAs<string>();
                                Properties.Settings.Default.Save();
                                tbUserEmail.Clear();
                                tbPassword.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Access denied");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("User does not exist!");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Error has accured");
                    }

                }
                else
                {
                    MessageBox.Show("Input fields cannot be empty");
                }
            }

        }
    }
}
