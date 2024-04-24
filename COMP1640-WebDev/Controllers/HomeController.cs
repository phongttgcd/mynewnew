using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using COMP1640_WebDev.Models;
using System.Diagnostics;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.Repositories;
using COMP1640_WebDev.ViewModels;

namespace COMP1640_WebDev.Controllers
{
    public class HomeController(IWebHostEnvironment hostEnvironment, IMagazineRepository magazineRepository) : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment = hostEnvironment;
        private readonly IMagazineRepository _magazineRepository = magazineRepository;

        public IActionResult Index()
        {
            List<MagazineTableView> magazines;
            magazines = _magazineRepository.GetAllMagazinesForGuest();

            return View(magazines);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var magazineInDb = await _magazineRepository.GetMagazineByID(id);

            string imageBase64Data = Convert.ToBase64String(magazineInDb.CoverImage!);
            string image = string.Format("data:image/jpg;base64, {0}", imageBase64Data);
            ViewBag.Image = image;

            return View(magazineInDb);
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
