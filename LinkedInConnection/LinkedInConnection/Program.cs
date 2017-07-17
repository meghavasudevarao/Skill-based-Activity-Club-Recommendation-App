using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace LinkedInConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string url = "https://api.fullcontact.com/v2/person.json?email=megha.vasudevrao@gmail.com&apiKey=5e895318448321d4";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000;


            WebResponse response = (HttpWebResponse)request.GetResponse();
                  
            Console.WriteLine(response);
            Console.ReadLine();
        }
    }
}
