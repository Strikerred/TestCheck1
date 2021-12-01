using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestCheck1
{
    class AgeByName
    {
        const string API = "https://api.agify.io?name=Fausto";
        public static void GetDataWithoutAuthentication()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");

                var result = client.DownloadString(API);
                Console.WriteLine(Environment.NewLine + result);
                Console.WriteLine("");
            }
        }
    }
}
