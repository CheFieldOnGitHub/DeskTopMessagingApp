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

using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System.Reactive.Linq;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "XTYjUlP7zHZgyvneqUoYJ18auiNeQA0QZrQB2y6M",
            BasePath = "https://mchat-ca3c9.firebaseio.com/"

        };

        static string auth = "XTYjUlP7zHZgyvneqUoYJ18auiNeQA0QZrQB2y6M"; // your app secret
        FirebaseClient firebaseClient = new FirebaseClient(
          "https://mchat-ca3c9.firebaseio.com/",
          new FirebaseOptions
          {
              AuthTokenAsyncFactory = () => Task.FromResult(auth)
          });

        IFirebaseClient client, clientSearch;
        FirebaseResponse response;
        FirebaseResponse searchResponse;
        FirebaseResponse messageResponse;
        EventStreamResponse ESRMsgs;

        ContactDisplay cdp;
        MessageDisplay mdp;
        AuthScreen authScreen = new AuthScreen();
        string userEmail, userName;
        string noPic = "https://firebasestorage.googleapis.com/v0/b/mchat-ca3c9.appspot.com/o/DemoApp%2FPictureProfile%2FnoPicture%2Fprofile_placeholder.png?alt=media&token=c4651302-5fe9-4a45-acb1-a537b824a67e";
        public static string pathToContactName = "";
        public static string pathToContactMsg = "";
        public static string pathToPairedId = "";
        public string prePairedId = "";
        public int sMessageCount;

        public Form1()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
            clientSearch = new FireSharp.FirebaseClient(config);
            
        }

        private async void PopulateMessageView()
        {
            //Populate message list
            string msgCountPath = "DemoApp/Messages/" + pathToPairedId + "/msgCount";
            response = await client.GetAsync(msgCountPath);
            if (response.ResultAs<string>() != null)
            {
                int messageCount = response.ResultAs<int>();
                sMessageCount = response.ResultAs<int>();
                for (int i = 0; i < messageCount; i++)
                {

                    string path = "DemoApp/Messages/" + pathToPairedId + "/messages/" + i.ToString() + "/";
                    var msgBundle = new
                    {
                        msg = await client.GetAsync(path + "msg"),
                        id = await client.GetAsync(path + "id"),
                        img = await client.GetAsync(path + "img")

                    };

                    if (!msgBundle.msg.ResultAs<string>().Equals(""))
                    {
                        mdp = new MessageDisplay();
                        mdp.Message = msgBundle.msg.ResultAs<string>();
                        mdp.ID = msgBundle.id.ResultAs<string>();
                        mdp.AutoSize = true;
                        if (msgBundle.id.ResultAs<string>().Equals(Properties.Settings.Default.Email))
                        {
                            mdp.Margin = new Padding(250, 20, 0, 0);
                        }
                        else
                        {
                            mdp.Margin = new Padding(30, 20, 0, 0);
                        }
                        fpMsgs.Controls.Add(mdp);
                    }
                    else
                    {
                        mdp = new MessageDisplay();
                        mdp.PictureProfile = msgBundle.img.ResultAs<string>();
                        mdp.ID = msgBundle.id.ResultAs<string>();
                        mdp.AutoSize = true;

                        if (msgBundle.id.ResultAs<string>().Equals(Properties.Settings.Default.Email))
                        {
                            mdp.Margin = new Padding(250, 20, 0, 0);
                        }
                        else
                        {
                            mdp.Margin = new Padding(30, 20, 0, 0);
                        }
                        fpMsgs.Controls.Add(mdp);
                    }


                }
                //
                //Stream event listener
                ESRMsgs = await client.OnAsync("DemoApp/Messages/" + pathToPairedId + "/messages/complete" , changed: async (sender, args, context) => {
                    System.Console.WriteLine(args.Data);
                    //sMessageCount++;
                    //response = await client.GetAsync("DemoApp/Messages/" + pathToPairedId + "/messages/" + messageCount.ToString());

                    Invoke(new MethodInvoker(async delegate
                    {
                        if (response.ResultAs<string>() != null)
                        {
                            string path = "DemoApp/Messages/" + pathToPairedId + "/messages/" + (sMessageCount).ToString() + "/";
                            var msgBundle = new
                            {
                                msg = await client.GetAsync(path + "msg"),
                                id = await client.GetAsync(path + "id"),
                                img = await client.GetAsync(path + "img")
                            };

                            if (!msgBundle.msg.ResultAs<string>().Equals(""))
                            {
                                mdp = new MessageDisplay();
                                mdp.Message = msgBundle.msg.ResultAs<string>();
                                mdp.ID = msgBundle.id.ResultAs<string>();
                                mdp.AutoSize = true;
                                if (msgBundle.id.ResultAs<string>().Equals(Properties.Settings.Default.Email))
                                {
                                    mdp.Margin = new Padding(250, 20, 0, 0);
                                }
                                else
                                {
                                    mdp.Margin = new Padding(30, 20, 0, 0);
                                }
                                fpMsgs.Controls.Add(mdp);
                                sMessageCount++;
                            }
                            else
                            {
                                mdp = new MessageDisplay();
                                mdp.PictureProfile = msgBundle.img.ResultAs<string>();
                                mdp.ID = msgBundle.id.ResultAs<string>();
                                mdp.AutoSize = true;

                                if (msgBundle.id.ResultAs<string>().Equals(Properties.Settings.Default.Email))
                                {
                                    mdp.Margin = new Padding(250, 20, 0, 0);
                                }
                                else
                                {
                                    mdp.Margin = new Padding(30, 20, 0, 0);
                                }
                                fpMsgs.Controls.Add(mdp);
                                sMessageCount++;
                            }
                        }

                    }));

                });
             
            }
            else
            {
                MessageBox.Show("Has no message");
            }
           

        }
    
       
        private async void LoadDataToFirebase()
        {
            //Load picture profile.
            response = await client.GetAsync("DemoApp/MessageInfo/ID/" + userEmail + "/picProfile");
            if(response.ResultAs<string>() != "noPic")
            {
                ribPicProfile.Load(response.ResultAs<String>());
            }
            else
            {
                ribPicProfile.Load(noPic);
            }
            

            //Populate contact list
            string populateContacts = "DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts";
            response = await client.GetAsync(populateContacts + "/pairedCount");
            int pairedCount = response.ResultAs<int>();
            
           for(int i = 0; i < pairedCount; i++)
            {
                string contactEmail;
                response = await client.GetAsync(populateContacts+"/pairedId/" + (i+1).ToString());
                cdp = new ContactDisplay();
                cdp.Width = fpContacts.Width - 30;
                cdp.UserEmail = response.ResultAs<string>();                
                contactEmail = response.ResultAs<string>();
                contactEmail = contactEmail.Replace('.', '_');
                response = await client.GetAsync(populateContacts +"/pairedInfo/"+ contactEmail+"/pairedId");
                cdp.PairedId = response.ResultAs<string>();
                response = await client.GetAsync("DemoApp/MessageInfo/ID/" + contactEmail + "/name");
                cdp.UserName = response.ResultAs<string>();
                response = await client.GetAsync("DemoApp/MessageInfo/ID/" + contactEmail + "/picProfile");
                if (response.ResultAs<string>() == "noPic")
                {
                    cdp.PictureProfile = noPic;
                }
                else
                {
                    cdp.PictureProfile = response.ResultAs<string>();
                }
                
                fpContacts.Controls.Add(cdp);
                
            }
            
            //Stream event listener
            EventStreamResponse eventStreamResponse = await client.OnAsync(populateContacts+"/pairedId", added:  async (sender, args, context) => {
                System.Console.WriteLine(args.Data);
                pairedCount++;
                response =  await client.GetAsync(populateContacts +"/pairedId/"+pairedCount.ToString());
                
                Invoke(new MethodInvoker(async delegate 
                {
                    //string t = response.ResultAs<string>();
                    if (response.ResultAs<string>() != null)
                    {
                        string contactEmail;
                        cdp = new ContactDisplay();
                        cdp.Width = fpContacts.Width - 30;
                        cdp.UserEmail = response.ResultAs<string>();
                        contactEmail = response.ResultAs<string>();
                        contactEmail = contactEmail.Replace('.', '_');
                        response = await client.GetAsync(populateContacts + "/pairedInfo/" + contactEmail + "/pairedId");
                        cdp.PairedId = response.ResultAs<string>();
                        response = await client.GetAsync("DemoApp/MessageInfo/ID/" + contactEmail + "/name");
                        cdp.UserName = response.ResultAs<string>();
                        response = await client.GetAsync("DemoApp/MessageInfo/ID/" + contactEmail + "/picProfile");
                        if (response.ResultAs<string>() == "noPic")
                        {
                            cdp.PictureProfile = noPic;
                        }
                        else
                        {
                            cdp.PictureProfile = response.ResultAs<string>();
                        }
                        fpContacts.Controls.Add(cdp);
                    }
                                                   
                }));

                //msg.Invoke(new MethodInvoker(delegate { msg.Message = response.ResultAs<string>(); fpMsgs.Controls.Add(msg); }));

            });
            //eventStreamResponse.Dispose();
           
           
        }    
       
        private async void btnSend_Click(object sender, EventArgs e)
        {
                     
                  
            if(tbMsg.Text.Equals("") || tbMsg.ForeColor == SystemColors.ScrollBar || pathToPairedId.Equals(""))
            {
                //Do Nothing
            }
            else
            {
                var msgBundle = new
                {
                    id = Properties.Settings.Default.Email,
                    img = "none",
                    msg = tbMsg.Text
                };

                messageResponse = await client.GetAsync("DemoApp/Messages/" + pathToPairedId + "/msgCount");
                int msgCount = messageResponse.ResultAs<int>();
                await client.SetAsync("DemoApp/Messages/" + pathToPairedId + "/msgCount", (msgCount + 1)); 
                await client.SetAsync("DemoApp/Messages/" + pathToPairedId + "/messages/" + msgCount.ToString(), msgBundle); 
                await client.SetAsync("DemoApp/Messages/" + pathToPairedId + "/messages/complete/count", (msgCount + 1));
                tbMsg.Text = "";
                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            if (Properties.Settings.Default.Email == "empty" && Properties.Settings.Default.Name == "empty")
            {
                fpContacts.Controls.Clear();
                fpMsgs.Controls.Clear();
                authScreen.ShowDialog();
            }
            else
            {
                txtUserName.Text = Properties.Settings.Default.Name;
                txtContName.Text = "Messaging App";
                
            }
        }

        private void btnSignInOut_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Email = "empty";
            Properties.Settings.Default.Name = "empty";
            Properties.Settings.Default.Save();
            fpContacts.Controls.Clear();
            fpMsgs.Controls.Clear();
            Application.Exit();

            //sign out the user and make the property saved data empty.
        }

        private string _setUserName;

        public string SetUserName
        {
            get { return _setUserName; }
            set { _setUserName = value; txtUserName.Text = value; }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txtUserName.Text = Properties.Settings.Default.Name;
            userEmail = Properties.Settings.Default.Email;
            userEmail = userEmail.Replace('.', '_');
            LoadDataToFirebase();
            loadSearchBar();
        }

        private async void btnImgMsg_Click(object sender, EventArgs e)
        {      

            if (pathToPairedId.Equals(""))
            {
                //Do Nothing
                MessageBox.Show("Open a chat");
            }
            else
            {
                string imageFile = "";
                var openFileDialog = new OpenFileDialog();

                messageResponse = await client.GetAsync("DemoApp/Messages/" + pathToPairedId + "/msgCount");
                int msgCount = messageResponse.ResultAs<int>();
                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        imageFile = openFileDialog.FileName;
                        // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
                        var stream = File.Open(imageFile, FileMode.Open);

                        // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                        var task = new FirebaseStorage("mchat-ca3c9.appspot.com")
                            .Child("DemoApp/ImageMessage/" + userEmail +"/"+msgCount.ToString())
                            .PutAsync(stream);

                        // Track progress of the upload
                        task.Progress.ProgressChanged += (s, e1) => Console.WriteLine($"Progress: {e1.Percentage} %");

                        // await the task to wait until upload completes and get the download url
                        var downloadUrl = await task;
                        var msgBundle = new
                        {
                            id = Properties.Settings.Default.Email,
                            img = downloadUrl.ToString(),
                            msg = ""
                        };

                       
                        await client.SetAsync("DemoApp/Messages/" + pathToPairedId + "/msgCount", (msgCount + 1));
                        await client.SetAsync("DemoApp/Messages/" + pathToPairedId + "/messages/" + msgCount.ToString(), msgBundle);
                        await client.SetAsync("DemoApp/Messages/" + pathToPairedId + "/messages/complete/count", (msgCount + 1));

                    }
                }
                catch
                {
                    MessageBox.Show("Something went wrong.");
                }

            }
        }

        private async void ribPicProfile_Click(object sender, EventArgs e)
        {
            string imageFile = "";
            var openFileDialog = new OpenFileDialog();

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageFile = openFileDialog.FileName;
                    // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
                    var stream = File.Open(imageFile, FileMode.Open);

                    // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
                    var task = new FirebaseStorage("mchat-ca3c9.appspot.com")
                        .Child("DemoApp/PictureProfile/"+userEmail)
                        .PutAsync(stream);

                    // Track progress of the upload
                    task.Progress.ProgressChanged += (s, e1) => Console.WriteLine($"Progress: {e1.Percentage} %");
          
                    // await the task to wait until upload completes and get the download url
                    var downloadUrl = await task;
                    await client.SetAsync("DemoApp/MessageInfo/ID/" + userEmail + "/picProfile", downloadUrl);
                    ribPicProfile.Load(downloadUrl);
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong.");
            }
        }
        
        public int userCount;
        public List<string> searchList = new List<string>();
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtContName.Text = pathToContactName;
            if (prePairedId != pathToPairedId)
            {
                if (ESRMsgs != null)
                {
                    ESRMsgs.Dispose();
                }
                
                fpMsgs.Controls.Clear();
                
                prePairedId = pathToPairedId;
                PopulateMessageView();
            }
            
        }

        private void tbMsg_Enter(object sender, EventArgs e)
        {
            if (tbMsg.ForeColor == SystemColors.ScrollBar)
            {
                tbMsg.Text = "";
                tbMsg.ForeColor = Color.Black;
            }
        }

        private void tbMsg_Leave(object sender, EventArgs e)
        {
            if (tbMsg.Text.Equals(""))
            {
                tbMsg.ForeColor = SystemColors.ScrollBar;
                tbMsg.Text = "Type a message...";
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.ForeColor == SystemColors.ScrollBar)
            {
                tbSearch.Text = "";
                tbSearch.ForeColor = Color.Black;
            }
        }

        //Add contacts to contact list.
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if(tbSearch.Text.Equals("") || tbSearch.ForeColor == SystemColors.ScrollBar || tbSearch.Text.Equals(Properties.Settings.Default.Email))
            {
                //Do nothing.
            }
            else
            {
                try
                {
                    string searchText = tbSearch.Text;
                    searchText = searchText.Replace('.', '_');
                    for (int i = 0; i < searchList.Count; i++)
                    {
                        if (tbSearch.Text == searchList.ElementAt(i))
                        {
                            response = await client.GetAsync("DemoApp/MessageInfo/Accounts/" + searchText + "/Contacts/pairedCount");
                            int pairedCount = response.ResultAs<int>();
                            if (pairedCount == 0)
                            {
                                response = await client.GetAsync("DemoApp/PairedAccount");
                                int pairedAcc = response.ResultAs<int>() + 1;
                                await client.SetAsync("DemoApp/PairedAccount", pairedAcc);

                                await client.SetAsync("DemoApp/MessageInfo/Accounts/" + searchText + "/Contacts/pairedInfo/" + userEmail + "/pairedId", pairedAcc);
                                await client.SetAsync("DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts/pairedInfo/" + searchText + "/pairedId", pairedAcc);
                                await client.SetAsync("DemoApp/Messages/" +pairedAcc.ToString()+"/messages/complete/count", 0);
                                await client.SetAsync("DemoApp/Messages/" +pairedAcc.ToString()+"/msgCount", 0);
                                
                                
                                await client.SetAsync("DemoApp/MessageInfo/Accounts/" + searchText + "/Contacts/pairedId/" + (pairedCount + 1).ToString(), Properties.Settings.Default.Email);
                                await client.SetAsync("DemoApp/MessageInfo/Accounts/" + searchText + "/Contacts/pairedCount", (pairedCount + 1));

                                response = await client.GetAsync("DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts/pairedCount");
                                pairedCount = response.ResultAs<int>();
                                await client.SetAsync("DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts/pairedId/" + (pairedCount + 1).ToString(), tbSearch.Text);
                                await client.SetAsync("DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts/pairedCount", (pairedCount + 1));

                                tbSearch.Text = "";
                            }
                            for (int ii = 0; ii < pairedCount; ii++)
                            {
                                int count = ii + 1;
                                response = await client.GetAsync("DemoApp/MessageInfo/Accounts/" + searchText + "/Contacts/pairedId/" + count.ToString());
                                if (response.ResultAs<string>() == Properties.Settings.Default.Email)
                                {
                                    MessageBox.Show("Accounts already connected.");
                                    break;
                                }
                                else if (count == pairedCount)
                                {
                                    response = await client.GetAsync("DemoApp/PairedAccount");
                                    int pairedAcc = response.ResultAs<int>() + 1;
                                    await client.SetAsync("DemoApp/PairedAccount", pairedAcc);

                                    await client.SetAsync("DemoApp/MessageInfo/Accounts/" + searchText + "/Contacts/pairedInfo/" + userEmail + "/pairedId", pairedAcc);
                                    await client.SetAsync("DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts/pairedInfo/" + searchText + "/pairedId", pairedAcc);
                                    await client.SetAsync("DemoApp/Messages/" + pairedAcc.ToString() + "/messages/complete/count", 0);
                                    await client.SetAsync("DemoApp/Messages/" + pairedAcc.ToString() + "/msgCount", 0);

                                    await client.SetAsync("DemoApp/MessageInfo/Accounts/" + searchText + "/Contacts/pairedId/" + (pairedCount + 1).ToString(), Properties.Settings.Default.Email);
                                    await client.SetAsync("DemoApp/MessageInfo/Accounts/" + searchText + "/Contacts/pairedCount", (pairedCount + 1));

                                    response = await client.GetAsync("DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts/pairedCount");
                                    pairedCount = response.ResultAs<int>();
                                    await client.SetAsync("DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts/pairedId/" + (pairedCount + 1).ToString(), tbSearch.Text);
                                    await client.SetAsync("DemoApp/MessageInfo/Accounts/" + userEmail + "/Contacts/pairedCount", (pairedCount + 1));
                                    tbSearch.Text = "";
                                }
                            }
                            break;
                        }
                        else if ((i + 1) == searchList.Count)
                        {
                            MessageBox.Show("Account does not exsit.");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("An Error has accured.");
                }

            }
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(""))
            {
                tbSearch.ForeColor = SystemColors.ScrollBar;
                tbSearch.Text = "Search";
            }
        }

        public async void loadSearchBar()
        {
            searchResponse = await clientSearch.GetAsync("DemoApp/Search/UserCount");
            userCount = searchResponse.ResultAs<int>();

            for (int i = 0; i < userCount; i++)
            {
                searchResponse = await clientSearch.GetAsync("DemoApp/Search/Users/" + (i+1).ToString());
                searchList.Add(searchResponse.ResultAs<string>());
                
                tbSearch.AutoCompleteCustomSource.Add(searchList.ElementAt(i));
            }
            
        }

        
    }

}
