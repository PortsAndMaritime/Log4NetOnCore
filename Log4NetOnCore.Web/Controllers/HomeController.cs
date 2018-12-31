using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Log4NetOnCore.Web.Models;
using Microsoft.Extensions.Logging;

namespace Log4NetOnCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        public HomeController(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            _logger = loggerFactory.CreateLogger("Global exception logger");
        }
        public IActionResult Index()
        {
           _logger.LogInformation("Hey Hey");
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
