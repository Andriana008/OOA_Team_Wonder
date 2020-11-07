using System.Diagnostics;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.EmailService;
using System.Threading.Tasks;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            // Test gRPC connection
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new EmailManager.EmailManagerClient(channel);
            var request = new SendEmailRequest
            {
                Email = "test_email",
                Subject = "Title",
                Message = "Test email"
            };
            var response = await client.SendEmailAsync(request);


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
