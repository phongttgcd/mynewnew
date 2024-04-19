using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace COMP1640_WebDev.Controllers
{

	[Authorize(Roles = "Student")]

	public class StudentController : Controller
	{
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly IContributionRepository _contributionRepository;
		private readonly IUserRepository _userRepository;
		private readonly IAcademicYearRepository _academicYearRepository;
        private readonly UserManager<User> _userManager;
		private readonly IFacultyRepository _facultyRepository;

		public StudentController(IWebHostEnvironment hostEnvironment, IAcademicYearRepository academicYearRepository, UserManager<User> userManager,  IContributionRepository contributionRepository, IUserRepository userRepository, IFacultyRepository facultyRepository)
		{
			_hostEnvironment = hostEnvironment;
			_contributionRepository = contributionRepository;
			_academicYearRepository = academicYearRepository;
			_userRepository = userRepository;
            _facultyRepository = facultyRepository;
            _userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

        /*[HttpGet]
        public async Task<IActionResult> AddCommentAsync()
        {

        }*/

        // Method to handle the submission of a new comment
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateContribute data, List<IFormFile> files)
		{
			var userId = _userManager.GetUserId(User);

			Contribution contri = new();
			var user = await _userRepository.GetUser(userId);
			var academicYear = await _academicYearRepository.GetAcademicYear(data.AcademicYearId);

           
			using (var memoryStream = new MemoryStream())
			{
				await files[0].CopyToAsync(memoryStream);
				contri.AcademicYearId = data.AcademicYearId;
                contri.Title = data.Title;
                contri.Document = data.Document;
                contri.UserId = userId;
                contri.Image =  memoryStream.ToArray();
                contri.IsEnabled = true;
			};
			if (DateTime.Now > academicYear.ClosureDate)
			{
				contri.IsEnabled = false;

			}
			await _contributionRepository.CreateContribution(contri);

			return View();
        }
		[HttpGet]
		public async Task<IActionResult> EditComment(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var comment = await _contributionRepository.GetContribution(id);
			if (comment == null)
			{
				return NotFound();
			}

			return View(comment);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditComment(string id, Contribution updateContribution)
		{
			if (ModelState.IsValid)
			{
				await _contributionRepository.UpdateContribution(id, updateContribution);
				TempData["AlertMessage"] = "Updated successfully!!!";
				return RedirectToAction("Index");
			}
			return View(updateContribution);
		}

	}


}
