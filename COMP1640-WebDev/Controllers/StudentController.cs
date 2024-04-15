using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_WebDev.Controllers
{

/*    [Authorize(Roles = "Student")]
*/    public class StudentController : Controller
    {
      
        private readonly IWebHostEnvironment _hostEnvironment;

        public StudentController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(List<IFormFile> files)
        {
            var uploadPath = Path.Combine(_hostEnvironment.WebRootPath, "images");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(uploadPath, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
            }

            ViewBag.Message = "Files uploaded successfully.";
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}
