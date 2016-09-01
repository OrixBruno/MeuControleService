using Microsoft.Owin.Hosting;
using System;

namespace Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("\n <---------- SERVER RODANDO NA PORTA "+ baseAddress + "------------>");            
            Console.ReadLine();
        }

    }
}
