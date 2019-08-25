using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MessagingSdk
{
    public class SMS
    {

        private readonly string _endPoint = " https://8mr2e.api.infobip.com";
        private readonly string _apiKey = "";
        private readonly string _smsEndpoint = "/sms/1/text/single";
        private readonly string _usernamePassword;
        public SMS(string apiKey)
        {
            _apiKey = apiKey;
        }

        public SMS(string username, string password)
        {
            _usernamePassword = $"{username}:{password}";
        }

        public bool SendSms(string message, string receipient)
        {

            try
            {

                var client = new RestClient()
                //{
                //    Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_apiKey, "App")
                //}
                .AddDefaultHeader("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes(_usernamePassword))}")                   
                //.AddDefaultHeader("Authorization", $"App {_apiKey}")
                .AddDefaultHeader("Content-Type", "application/json");

                var request = new RestRequest("http://api.bitlabs.com.ng/sms/1/text/single", Method.POST);

                request.RequestFormat = DataFormat.Json;
                request.AddBody(new { to = receipient.Split(','), text = message });


                var response = client.Execute(request);
                
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(response.Content);
                    return true;
                }
                else
                {
                    Console.WriteLine(response.Content);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }



        //public async Task<bool> SendSms1(string message, string receipient)
        //{

        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {

        //            httpClient.BaseAddress = new Uri(_endPoint);
        //            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("App", _apiKey);

        //            var content = new StringContent(Json.Encode(new SmsMessage(message, receipient)));
        //            var result = await httpClient.PostAsync(_smsEndpoint, content);

        //            if (result.IsSuccessStatusCode)
        //            {
        //                Console.WriteLine(result.Content.ReadAsStringAsync());
        //                return true;
        //            }
        //            else
        //            {
        //                Console.WriteLine(result.Content.ReadAsStringAsync());
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //    }

        //    return false;
        //}
    }

}


public class SmsMessage
    {
        private readonly string _message;
        private readonly string _receipient;

        public SmsMessage(string text, string to)
        {
            this._message = text;
            this._receipient = to;
        }

        public string Text { get { return _message; } }
        public string To { get { return _receipient; } }

        
    }

