using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace COMP1640_WebDev.Controllers
{
    public class MarketingCoordinatorController : Controller
    {
        private readonly IMagazineRepository _magazineRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MarketingCoordinatorController(IMagazineRepository magazineRepository, IWebHostEnvironment hostEnvironment)
        {
            _magazineRepository = magazineRepository;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description")] Magazine magazine, IFormFile coverImage)
        {
            if (ModelState.IsValid)
            {
                if (coverImage != null && coverImage.Length > 0)
                {
                    var fileName = Path.GetFileName(coverImage.FileName);
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await coverImage.CopyToAsync(fileStream);
                    }
                    magazine.CoverImage = Path.Combine("images", fileName); // Only path is saved
                }

                await _magazineRepository.CreateMagazine(magazine);
                return RedirectToAction(nameof(Index));
            }
            return View(magazine);
        }

        // Assume an Index action exists to list magazines
    }

}
