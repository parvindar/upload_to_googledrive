﻿using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp3
{


    public partial class Form1 : Form
    {

        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "Drive API .NET Quickstart";
        public Form1()
        {
            InitializeComponent();
        }

        //=================================
  

        private void Request_ResponseReceived(Google.Apis.Drive.v3.Data.File obj)
        {
            //Console.WriteLine(obj);
            if (obj != null)
            {
                MessageBox.Show("File was uploaded sucessfully--" + obj.Name + " "+obj.Id);
            }
        }




        private void Authorize()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,
                               DriveService.Scope.DriveFile,};
            var clientId = cred.clientid;      // From https://console.developers.google.com  
            var clientSecret = cred.clientsecret;          // From https://console.developers.google.com  
                                                                         // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%  
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, scopes,
            Environment.UserName, CancellationToken.None, new FileDataStore("token")).Result;
            //Once consent is recieved, your token will be stored locally on the AppData directory, so that next time you wont be prompted for consent.   

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "VirtualFileManager",

            });
            service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
            //Long Operations like file uploads might timeout. 100 is just precautionary value, can be set to any reasonable value depending on what you use your service for  

            // team drive root https://drive.google.com/drive/folders/0AAE83zjNwK-GUk9PVA   

            var respocne = uploadFile(service, lable_file_name.Text, "");
            // Third parameter is empty it means it would upload to root directory, if you want to upload under a folder, pass folder's id here.
            MessageBox.Show("Process completed--- Response--" + respocne);
        }


        private static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        public Google.Apis.Drive.v3.Data.File uploadFile(DriveService _service, string _uploadFile, string _parent, string _descrp = "Uploaded with .NET!")
        {
            if (System.IO.File.Exists(_uploadFile))
            {
                Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
                body.Name = System.IO.Path.GetFileName(_uploadFile);
                body.Description = _descrp;
                body.MimeType = GetMimeType(_uploadFile);
                // body.Parents = new List<string> { _parent };// UN comment if you want to upload to a folder(ID of parent folder need to be send as paramter in above method)
                byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                
                System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                try
                {
                    FilesResource.CreateMediaUpload request = _service.Files.Create(body, stream, GetMimeType(_uploadFile));
                    request.SupportsTeamDrives = true;
                    // You can bind event handler with progress changed event and response recieved(completed event)
                    request.ResponseReceived += Request_ResponseReceived;
                    request.Upload();
                    Console.WriteLine("request body ",request.ResponseBody);
                    return request.ResponseBody;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error Occured");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("The file does not exist.", "404");
                return null;
            }
        }

    


        //==============================












        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_select_file_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    
                    string text = System.IO.File.ReadAllText(file);
                    lable_file_name.Text = file;
                    size = text.Length;
                }
                catch (System.IO.IOException)
                {
                }
            }

            
        }

        private void lable_file_name_Click(object sender, EventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {

            if(lable_file_name.Text.Length == 0)
            {
                MessageBox.Show("Select a file first!");
                return;
            }

            Authorize();


        }


    }
 


}
