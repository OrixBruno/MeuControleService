using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dispatcher;

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
            Console.WriteLine(response+"\n <---------- SERVER RODANDO NA PORTA "+ baseAddress + "------------>");            
            Console.ReadLine();
        }

    }
    //public class CustomAssembliesResolver : DefaultAssembliesResolver
    //{
    //    public override ICollection<Assembly> GetAssemblies()
    //    {
    //        ICollection<Assembly> baseAssemblies = base.GetAssemblies();

    //        List<Assembly> assemblies = new List<Assembly>(baseAssemblies);

    //        var controllersAssembly = Assembly.LoadFrom(@"C:\libs\controllers\ControllersLibrary.dll");

    //        baseAssemblies.Add(controllersAssembly);

    //        return assemblies;
    //    }
    //}
}
