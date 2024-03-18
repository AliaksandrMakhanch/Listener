using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Listener
{
    class Routes
    {
        public static async Task GetMyName(HttpListenerResponse response)
        {
            byte[] buffer = Encoding.UTF8.GetBytes("Alex");
            response.ContentType = "text/plain";
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task SendStatusCode(HttpListenerResponse response, string statusCodeCategory)
        {
            int statusCode;
            switch (statusCodeCategory)
            {
                case "Information":
                    statusCode = 100;
                    break;
                case "Success":
                    statusCode = 200;
                    break;
                case "Redirection":
                    statusCode = 300;
                    break;
                case "ClientError":
                    statusCode = 400;
                    break;
                case "ServerError":
                    statusCode = 500;
                    break;
                default:
                    statusCode = 404;
                    break;
            }
            response.StatusCode = statusCode;

            byte[] buffer = Encoding.UTF8.GetBytes($"Status Code: {statusCode}");
            response.ContentType = "text/plain";
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
        }

        public static async Task GetMyNameByHeader(HttpListenerResponse response)
        {
            response.Headers.Add("X-MyName", "Alex");
            byte[] buffer = Encoding.UTF8.GetBytes("Header added");
            response.OutputStream.Write(buffer, 0, buffer.Length);
            await response.OutputStream.FlushAsync();
        }
    }
}
