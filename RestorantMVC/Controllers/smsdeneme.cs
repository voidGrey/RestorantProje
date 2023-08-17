using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient.Memcached;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;
using System.Threading;

namespace RestorantMVC.Controllers
{
    public class smsdeneme : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {


            var client = new RestClient("https://api.vatansms.net/api/v1/1toN");

            
            //client.Timeout = -1;

            var request = new RestRequest("Post");

            request.AddHeader("Content-Type", "application/json");

            var body = @"{""api_id"": ""ce5c5a02561250bdb542b977"",""api_key"": ""9d38a81ae65177ae242e6d0b"",""sender"": ""VATANSMS"",""message_type"": ""turkce"",""message"":""Bu bir test mesajıdır."",""message_content_type"":""bilgi"",""phones"": [""5302442785"",""5310860642""]}"; // Ticari smsler için ""message_content_type"":""ticari"",

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = await client.GetAsync(request);



            //var response = client.Execute(request);

            return View();
        }
    }
}
