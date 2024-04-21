﻿using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;


namespace COMP1640_WebDev.Repositories
{
    public class MagazineRepository : IMagazineRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MagazineRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Magazine>> GetMagazines()
        {
            return await _dbContext.Magazines!.ToListAsync();
        }

        public async Task<Magazine> RemoveMagazine(string id)
        {
            var magazine = await _dbContext.Magazines!.FindAsync(id);
            if (magazine == null)
            {
                throw new KeyNotFoundException($"Magazine with ID {id} not found.");
            }

            _dbContext.Magazines.Remove(magazine);
            await _dbContext.SaveChangesAsync();
            return magazine;
        }

		public MagazineViewModel GetMagazineViewModel()
		{
            var viewModel = new MagazineViewModel()
            {
                Falulties = _dbContext.Faculties.ToList(),
                AcademicYears = _dbContext.AcademicYears.ToList(),
            };
            return viewModel;
		}

		public MagazineViewModel GetMagazineViewModelByID(string idMagazine)
		{
			throw new NotImplementedException();
		}


        public async Task<Magazine> CreateMagazine(Magazine magazine, IFormFile? formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile!.CopyToAsync(memoryStream);

                magazine.CoverImage = memoryStream.ToArray(); 
           

                var result = await _dbContext.Magazines!.AddAsync(magazine);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
        }

        public async Task<Magazine> UpdateMagazine(Magazine magazine, IFormFile? formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile!.CopyToAsync(memoryStream);

                magazine.CoverImage = memoryStream.ToArray();


                var result =  _dbContext.Magazines!.Update(magazine);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
        }

			public async Task<Magazine?> GetMagazineByID(string id)
        {
            var magazineInDB = _dbContext.Magazines
               .Include(u => u.Faculty)
            .Include(u => u.AcademicYear)
            .SingleOrDefault(i => i.Id == id);

            if (magazineInDB == null)
            {
                return null;
            }

            return magazineInDB;
        }

        public IEnumerable<MagazineTableView> GetAllMagazines()
        {
            var magazines = _dbContext.Magazines!.Select(c => new MagazineTableView()
            {
                Id = c.Id,
                Title = c.Title,
                Faculty = c.Faculty!.FacultyName,
                AcademicYear = c.AcademicYear!.StartDate.ToString()
            }).ToList();

            return magazines;
        }

        public IEnumerable<MagazineTableView> SearchMagazines(string attribute, string value)
        {
            var magazines = GetAllMagazines();
            if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(value))
            {
                switch (attribute)
                {
                    case "Title":
                        magazines = magazines.Where(u => u.Title != null && u.Title.Contains(value));
                        break;
                    case "Faculty":
                        magazines = magazines.Where(u => u.Faculty != null && u.Faculty.Contains(value));
                        break;
                    default:
                        break;
                }
            }
            return magazines;
        }
    }
}
