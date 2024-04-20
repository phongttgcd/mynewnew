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
	public class StudentController(IMagazineRepository magazineRepository, IAcademicYearRepository academicYearRepository, UserManager<User> userManager, IContributionRepository contributionRepository, IUserRepository userRepository) : Controller
	{
		private readonly IContributionRepository _contributionRepository = contributionRepository;
		private readonly IAcademicYearRepository _academicYearRepository = academicYearRepository;
		private readonly IMagazineRepository _magazineRepository = magazineRepository;
        private readonly UserManager<User> _userManager = userManager;
		private readonly IUserRepository _userRepository = userRepository;

		[HttpGet]
		public async Task<IActionResult> IndexAsync()
		{
            var magazines = await _magazineRepository.GetMagazines();
            return View();
		}

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
