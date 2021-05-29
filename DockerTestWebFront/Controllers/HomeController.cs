using DockerTestWebFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DockerTestWebFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.hellome = "Hi there.. happy coding.";
                //code block from microsoft docs
                using (var client = new System.Net.Http.HttpClient())
                {
                    // Call *mywebapi*, and display its response in the page
                    var request = new System.Net.Http.HttpRequestMessage();
                    request.RequestUri = new Uri("http://192.168.8.109:44381/weatherforecast"); // ASP.NET 3 (VS 2019 only)
                    //request.RequestUri = new Uri("http://mywebapi/api/values/1"); // ASP.NET 2.x
                    var response = await client.SendAsync(request);
                    ViewBag.hellome += " and " + await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
            }
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
    }
}
