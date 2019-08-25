using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BitLabs.Messaging.Types;
using Newtonsoft.Json;

namespace BitLabs.Messaging.Services
{
    public class SmsService :MessagingService
    {

        private readonly string _apiUrl = "http://api.bitlabs.com.ng/sms/1/text/single";
        internal SmsService(Credential credential)
            :base(credential)
        {
            ServiceType = ServiceType.Sms;
            
        }
        /// <summary>
        /// Sends an sms message
        /// </summary>
        /// <param name="message">An instance of SmsMessage representing the message to be sent</param>
        /// <returns>A string that can be parsed to json which provides server state of the sent message</returns>

        public override string Send(IMessageType message)
        {
            var smsMessage = (SmsMessage)message;
            //SendAsync(message)
            //    .RunSynchronously();

            String response = "";
            Task.Run(() =>
            {
                response = SendAsync(message).Result;
            }
            ).Wait();

            return response;
        }


        /// <summary>
        /// Asynchronously sends an sms message
        /// </summary>
        /// <param name="message">An instance of SmsMessage representing the message to be sent</param>
        /// <returns>A string that can be parsed to json which provides server state of the sent message</returns>
        public override async Task<string> SendAsync(IMessageType message)
        {
            var smsMessage = (SmsMessage)message;


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Credential.CredentialHash}");
                string content = JsonConvert.SerializeObject(new JsonSms
                {
                    to = _ParseReceipients( smsMessage.Receipient),
                    text = smsMessage.Message,
                    from = smsMessage.Sender
                });

                var response = await httpClient.PostAsync(_apiUrl, new StringContent(content, Encoding.UTF8, "application/json"));

                return
                    await response.Content.ReadAsStringAsync();
            }

        }

        private string[] _ParseReceipients(string receipients)
        {
            if (string.IsNullOrEmpty(receipients))
                return new string[] { "" };

            return
                receipients.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }

    internal class JsonSms
    {
        public string[] to { get; set; }
        public string text { get; set; }
        public string from { get; set; }
    }
}
