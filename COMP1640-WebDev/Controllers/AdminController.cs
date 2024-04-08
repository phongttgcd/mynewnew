﻿using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COMP1640_WebDev.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAcademicYearRepository _academicYearRepository;
        public AdminController(IFacultyRepository facultyRepository, IUserRepository userRepository, IAcademicYearRepository academicYearRepository)
        {
            _facultyRepository = facultyRepository;
            _userRepository = userRepository;
            _academicYearRepository = academicYearRepository;
        }

        //1. Index Methods
        public IActionResult Index()
        {
            return View();
        }


        //2. Account Management Methods
        [HttpGet]
        public IActionResult AccountsManagement()
        {
            var users = _userRepository.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var removedUser = await _userRepository.RemoveUser(id);

            if (removedUser == null)
            {
                TempData["AlertMessage"] = "Error: Unable to delete user. User not found or some other error occurred.";
            }
            else
            {
                TempData["AlertMessage"] = "Success: User deleted successfully!";
            }

            return RedirectToAction("AccountsManagement");
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
        [HttpGet]
        public async Task<IActionResult> SemestersManagement()
        {
            var semesters = await _academicYearRepository.GetAcademicYears();
            return View(semesters);
        }

        [HttpGet]
        public IActionResult CreateSemester()
        {
            var semesterViewModel = _academicYearRepository.GetAcademicYearViewModel();
            return View(semesterViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSemester(AcademicYearViewModel semesterViewModel)
        {
            if(ModelState.IsValid)
            {
                await _academicYearRepository.CreateAcademicYear(semesterViewModel) ;
                TempData["AlertMessage"] = "Semester created successfully!!!";
                return RedirectToAction("SemestersManagement");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSemester(string id)
        {
            var removedSemester = await _academicYearRepository.RemoveAcademicYear(id);

            if (removedSemester == null)
            {
                TempData["AlertMessage"] = "Error: Unable to delete semester. Semester not found or some other error occurred.";
            }
            else
            {
                TempData["AlertMessage"] = "Success: Semester deleted successfully!";
            }

            return RedirectToAction("SemestersManagement");
        }

        [HttpGet]
        public IActionResult EditSemester(string id)
        {
            var academicYear = _academicYearRepository.GetAcademicYearViewModelByID(id);
            if (academicYear == null)
            {
                return NotFound();
            }

            return View(academicYear);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSemester(AcademicYearViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _academicYearRepository.UpdateAcademicYear(viewModel);
                TempData["AlertMessage"] = "Semester updated successfully!!!";
                return RedirectToAction("SemestersManagement");
            }
            return View(viewModel);
        }

    }
}
