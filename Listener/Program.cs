using System;
using System.Net;
using System.Threading.Tasks;

namespace Listener
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpListener listener = new HttpListener();

            listener.Prefixes.Add("http://localhost:8888/");
            listener.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
               var context = await listener.GetContextAsync();

               await RequestHandler.HandleRequest(context);
            }
        }
    }
}