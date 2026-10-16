using System.Diagnostics;
using DotNetHelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetHelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Hostname"] = Environment.MachineName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("api/health")]
        public IActionResult HealthCheck()
        {
            var machineName = Environment.MachineName;
            if (string.Equals(machineName, "sw1-tianxiang5", StringComparison.OrdinalIgnoreCase))
            {
                ViewData["Status"] = "Unhealthy";
                HttpContext.Response.StatusCode = 500;
            }
            else
            {
                ViewData["Status"] = "Healthy";
                HttpContext.Response.StatusCode = 200;
            }

            ViewData["Hostname"] = machineName;
            return View("HealthCheck");
        }
    }
}
