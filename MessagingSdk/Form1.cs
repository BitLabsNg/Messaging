using BitLabs.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessagingSdk
{
    public partial class Form1 : Form
    {
        private string key, username, password;
        public Form1()
        {
            InitializeComponent();

            key = ConfigurationManager.AppSettings["ApiKey"];
            username = ConfigurationManager.AppSettings["username"];
            password = ConfigurationManager.AppSettings["password"];

        }

        private void BtnSend_ClickAsync(object sender, EventArgs e)
        {


            if (!String.IsNullOrEmpty(txtReceipient.Text) && !String.IsNullOrEmpty(txtMessage.Text))
            {
             

                if (String.IsNullOrEmpty(key))
                {
                    MessageBox.Show("ApiKey is empty", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {

                    var msg = 
                    new Messaging().GetServiceInstance(BitLabs.Messaging.Services.ServiceType.Sms,
                        new BitLabs.Messaging.Types.Credential(username, password));


                    var result =
                    msg.Send(new BitLabs.Messaging.Types.SmsMessage(txtReceipient.Text, txtMessage.Text));
                        

                    // var client = new SMS(username, password);
                    //var client = new SMS(key);
                    if(string.IsNullOrEmpty(result) == false)
                    // if (client.SendSms(txtMessage.Text, txtReceipient.Text))
                    {

                        MessageBox.Show("Sent", "SMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Send Failed, check console for more info", "SMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch(Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
