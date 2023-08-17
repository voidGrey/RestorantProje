using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient.Memcached;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;

namespace RestorantMVC.Controllers
{
    public class smsdeneme : Controller
    {
        public IActionResult Index()
        {


            var client = new RestClient("https://api.vatansms.net/api/v1/1toN");

            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Content-Type", "application/json");

            var body = @"{""api_id"": ""API_ID"",""api_key"": ""API_KEY"",""sender"": ""VATANSMS"",""message_type"": ""normal"",""message"":""Bu bir test mesajıdır."",""message_content_type"":""bilgi"",""phones"": [""5xxxxxxxxx"",""5xxxxxxxxx""]}"; // Ticari smsler için ""message_content_type"":""ticari"",

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);
            return View();
        }
    }
}
