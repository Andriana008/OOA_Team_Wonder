using System.Diagnostics;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.EmailService;
using System.Threading.Tasks;
using System;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // Test gRPC connection
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress("https://ooa-emailservice.azurewebsites.net");
            var client = new EmailManager.EmailManagerClient(channel);
            var request = new SendEmailRequest
            {
                Email = "automemoservice@gmail.com",
                Subject = "Title",
                Message = "Test email"
            };
            await client.SendEmailAsync(request);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
