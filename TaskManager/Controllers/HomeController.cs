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
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
