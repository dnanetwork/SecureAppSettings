using AppSettingsManage2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        private readonly HomeModel _homeModel;
        //private readonly IOptions<HomeModel> _options;


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, HomeModel homeModel)
        {
            _logger = logger;
            _configuration = configuration;
            //homeModel = new HomeModel();
            //configuration.GetSection("Home").Bind(homeModel);
            //_options = options;
            _homeModel = homeModel;
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

            //ViewBag.Name = _configuration.GetSection("Home").GetValue<string>("Name"); ;
            //ViewBag.Email = _configuration.GetSection("Home").GetValue<string>("Email"); ;
            //ViewBag.Phone = _configuration.GetSection("Home").GetValue<string>("Phone"); ;

            // Get the value from Home Model and using Bind method.

            //ViewBag.Name = homeModel.Name;
            //ViewBag.Email = homeModel.Email;
            //ViewBag.Phone = homeModel.Phone;

            // Get the value from Home Model and using IOption.

            //ViewBag.Name = _options.Value.Name;
            //ViewBag.Email = _options.Value.Email;
            //ViewBag.Phone = _options.Value.Phone;

            // Get the value from Home Model and Extension Method

            ViewBag.Name = _homeModel.Name;
            ViewBag.Email = _homeModel.Email;
            ViewBag.Phone = _homeModel.Phone;

            // This is to get the Nested data out by using Get Section.
            //ViewBag.NestedData = _configuration.GetSection("Nested").
            //                                    GetSection("Level1").
            //                                    GetSection("Level2").
            //                                    GetValue<string>("Level3"); ;

            ViewBag.NestedData = _configuration.GetSection("Nested").
                                               GetSection("Level1").
                                               GetSection("Level2").
                                               GetSection("Level3").Value;

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
