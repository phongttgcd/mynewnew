using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace COMP1640_WebDev.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(IFacultyRepository facultyRepository, IUserRepository userRepository, IAcademicYearRepository academicYearRepository, IContributionRepository contributionRepository) : Controller
    {
        private readonly IFacultyRepository _facultyRepository = facultyRepository;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAcademicYearRepository _academicYearRepository = academicYearRepository;
        private readonly IContributionRepository _contributionRepository = contributionRepository;

		public async Task<IActionResult> IndexAsync()
        {
            var facultiesData = new int[] { 30, 20, 10 };
            int[] usersData = await _userRepository.GetUserCounts();
            var semestersData = new int[] { 20, 15, 25 };

            ViewBag.FacultiesData = facultiesData;
            ViewBag.UsersData = usersData;
            ViewBag.SemestersData = semestersData;

            return View();
        }

        [HttpGet]
        public IActionResult AccountsManagement()
        {
            var users = _userRepository.GetAllUsers();
            return View(users);
        }


        [HttpGet]
        public IActionResult Search(string attribute, string value)
        {
            var users = _userRepository.SearchUsers(attribute, value); 

            return View("AccountsManagement", users); 
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(string id, User updatedUser)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.EditUser(id,updatedUser);
                TempData["AlertMessage"] = "Username updated successfully!!!";
                return RedirectToAction("AccountsManagement");
            }
            return View(updatedUser);
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

        [HttpGet]
        public async Task<IActionResult> SemestersManagement()
        {
            var semesters = await _academicYearRepository.GetAcademicYears();
            return View(semesters);
        }

        [HttpGet]
        public IActionResult CreateSemester()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSemester(AcademicYear newAcademicYear)
        {
            if(ModelState.IsValid)
            {
                await _academicYearRepository.CreateAcademicYear(newAcademicYear) ;
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
        public async Task<IActionResult> EditSemesterAsync(string id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var academicYear = await _academicYearRepository.GetAcademicYear(id);
			if (academicYear == null)
			{
				return NotFound();
			}

			return View(academicYear);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSemester(string id, AcademicYear updatedAcademicYear)
        {
            if (ModelState.IsValid)
            {
                await _academicYearRepository.UpdateAcademicYear(id,updatedAcademicYear);
                TempData["AlertMessage"] = "Semester updated successfully!!!";
                return RedirectToAction("SemestersManagement");
            }
            return View(updatedAcademicYear);
        }
	}
}
