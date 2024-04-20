using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using COMP1640_WebDev.Models;
using System.Diagnostics;

namespace COMP1640_WebDev.Controllers
{
    public class HomeController(IWebHostEnvironment hostEnvironment) : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment = hostEnvironment;

		public IActionResult Index()
        {
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
