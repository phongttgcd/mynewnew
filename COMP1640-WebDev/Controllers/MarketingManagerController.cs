using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace COMP1640_WebDev.Controllers
{

    [Authorize(Roles = "Marketing Manager")]
    public class MarketingManagerController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public MarketingManagerController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        // 1. Magazines management
        public IActionResult MagazinesManagement()
        {
            return View();
        }

        public IActionResult CreateMagazine()
        {
            return View();
        }


        // 2.Download file
        public IActionResult DataManagement()
        {
            var uploadsPath = Path.Combine(_hostEnvironment.WebRootPath, "images");
            var fileModels = Directory.GetFiles(uploadsPath)
                                      .Select(file => Path.GetFileName(file)) // Use LINQ to select file names
                                      .ToList();

            return View(fileModels);
        }


        public IActionResult DownloadZip1()
        {
            // Define the path to the uploads directory
            var uploadsPath = Path.Combine(_hostEnvironment.WebRootPath, "images");

            // Temporary filename for the ZIP archive
            var tempZipFileName = "MarketingFiles.zip";
            var tempZipPath = Path.Combine(Path.GetTempPath(), tempZipFileName);

            // Ensure any existing instance of the file is deleted
            if (System.IO.File.Exists(tempZipPath))
            {
                System.IO.File.Delete(tempZipPath);
            }

            // Create a new ZIP archive
            using (var zipStream = new FileStream(tempZipPath, FileMode.CreateNew))
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                var files = Directory.GetFiles(uploadsPath);
                foreach (var filePath in files)
                {
                    var fileInfo = new FileInfo(filePath);
                    var entry = archive.CreateEntry(fileInfo.Name);
                    using (var entryStream = entry.Open())
                    using (var fileStream = System.IO.File.OpenRead(filePath))
                    {
                        fileStream.CopyTo(entryStream);
                    }
                }
            }

            // Send the ZIP file to the browser
            return PhysicalFile(tempZipPath, "application/zip", tempZipFileName);
        }

    

        public IActionResult DownloadSingleFile(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                // Handle invalid file name
                return BadRequest("Invalid file name.");
            }

            // Define the path to the uploads directory
            var uploadsPath = Path.Combine(_hostEnvironment.WebRootPath, "images");

            var filePath = Path.Combine(uploadsPath, file);
            if (!System.IO.File.Exists(filePath))
            {
                // Handle case where file doesn't exist
                return NotFound();
            }

            // Return the file
            return PhysicalFile(filePath, "application/octet-stream", file);
        }
    }
}
