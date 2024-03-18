using System.Net;
using System.Threading.Tasks;

namespace Listener
{
    class RequestHandler
    {
        public static async Task HandleRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            switch (request.RawUrl)
            {
                case "/MyName/":
                    await Routes.GetMyName(response);
                    break;

                case "/Information/":
                case "/Success/":
                case "/Redirection/":
                case "/ClientError/":
                case "/ServerError/":
                    await Routes.SendStatusCode(response, request.RawUrl.TrimStart('/').TrimEnd('/'));
                    break;

                case "/MyNameByHeader/":
                    await Routes.GetMyNameByHeader(response);
                    break;

                default:
                    response.StatusCode = 404;
                    break;
            }
        }
    }
}