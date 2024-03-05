using COMP1640_WebDev.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_WebDev.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccountsManagement()
        {
            return View();
        }

        public IActionResult FacultiesManagement()
        {
            return View();
        }

        public IActionResult SemestersManagement() {
            return View();
        }
    }
}
