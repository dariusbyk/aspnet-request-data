using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace RequestTasks.Controllers
{
    public class EchoController : Controller
    {
        [HttpGet]
        public async Task Get()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("GET request received");
        }

        [HttpPost]
        public async Task Post()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("POST request received");
        }

        public async Task Headers()
        {
            Dictionary<string, string[]> headers = new Dictionary<string, string[]>();

            foreach (var header in Request.Headers)
            {
                headers.Add(header.Key, header.Value.ToArray());
            }

            Response.ContentType = "application/json";
            await Response.WriteAsJsonAsync(headers);
        }

        public async Task Query()
        {
            Dictionary<string, string[]> parameters = new Dictionary<string, string[]>();

            foreach (var parameter in Request.Query)
            {
                parameters.Add(parameter.Key, parameter.Value.ToArray());
            }

            Response.ContentType = "application/json";
            await Response.WriteAsJsonAsync(parameters);
        }

        public async Task Body()
        {
            using (StreamContent content = new StreamContent(Request.Body))
            {
                string body = await content.ReadAsStringAsync();

                Response.ContentType = "text/plain";
                await Response.WriteAsync(body);
            }
        }
    }
}
