using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            WebApp.Start<Startup>(url: baseAddress);

            //// Create HttpCient and make a request to api/values 
            HttpClient client = new HttpClient();
            //var response = client.GetAsync(baseAddress + "api/v1/Territorio").Result;
            var response = client.GetType();
            Console.WriteLine(response+"\n <-------------------- SERVER RODANDO NA PORTA 9000------------------------->");            
            Console.ReadLine();
        }
    }
}
