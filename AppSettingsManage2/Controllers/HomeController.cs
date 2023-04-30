using AppSettingsManage2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppSettingsManage2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Basic way to get the App Settings.
            // Inject Iconfiguration and go for the get Value method.
            ViewBag.SendGridKey = _configuration.GetValue<string>("SendGridKey");

            // Get the value from one level deep from the section using GetValue

            //ViewBag.Name = _configuration.GetValue<string>("Home:Name");
            //ViewBag.Email = _configuration.GetValue<string>("Home:Email");
            //ViewBag.Phone = _configuration.GetValue<string>("Home:Phone");

            // Get the value from one level deep from the section using GetValue

            ViewBag.Name = _configuration.GetSection("Home").GetValue<string>("Name"); ;
            ViewBag.Email = _configuration.GetSection("Home").GetValue<string>("Email"); ;
            ViewBag.Phone = _configuration.GetSection("Home").GetValue<string>("Phone"); ;


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
