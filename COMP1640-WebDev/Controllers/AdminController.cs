using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_WebDev.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUserRepository _userRepository;
        public AdminController(IFacultyRepository facultyRepository, IUserRepository userRepository)
        {
            _facultyRepository = facultyRepository;
            _userRepository = userRepository;
        }

        //1. Index Methods
        public IActionResult Index()
        {
            return View();
        }


        //2. Account Management Methods
        public IActionResult AccountsManagement()
        {
            return View();
        }


        //3. Faculty Management Methods
        [HttpGet]
        public async Task<IActionResult> FacultiesManagement()
        {
            var faculties = await _facultyRepository.GetFaculties();
            return View(faculties);
        }

        [HttpGet]
        public IActionResult CreateFaculty()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFaculty(Faculty newFaculty)
        {
            if (ModelState.IsValid)
            {
                await _facultyRepository.CreateFaculty(newFaculty);
                TempData["AlertMessage"] = "Faculty created successfully!!!";
                return RedirectToAction("FacultiesManagement");
            }

            return View(newFaculty);
        }

        [HttpGet]
        public async Task<IActionResult> EditFaculty(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _facultyRepository.GetFaculty(id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFaculty(string id, Faculty updateFaculty)
        {
            if (ModelState.IsValid)
            {
                await _facultyRepository.UpdateFaculty(id,updateFaculty);
                TempData["AlertMessage"] = "Faculty updated successfully!!!";
                return RedirectToAction("FacultiesManagement");
            }
            return View(updateFaculty);
        }



        [HttpGet]
        public async Task<IActionResult> DeleteFaculty(string id)
        {
            var removedFaculty = await _facultyRepository.RemoveFaculty(id);

            if (removedFaculty == null)
            {
                TempData["AlertMessage"] = "Error: Unable to delete faculty. Faculty not found or some other error occurred.";
            }
            else
            {
                TempData["AlertMessage"] = "Success: Faculty deleted successfully!";
            }

            return RedirectToAction("FacultiesManagement");
        }

        //3. Semesters Management Methods
        public IActionResult SemestersManagement()
        {
            return View();
        }
    }
}
