using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
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


        public async Task<Magazine> CreateMagazine(MagazineViewModel magazineViewModel)
        {
            using (var memoryStream = new MemoryStream())
            {
                await magazineViewModel.FormFile!.CopyToAsync(memoryStream);

                var newMagazine = new Magazine
                {
                    CoverImage = memoryStream.ToArray(),
                    Title = magazineViewModel.Magazine.Title,
                    Description = magazineViewModel.Magazine.Description,
                    FacultyId = magazineViewModel.Magazine.FacultyId,
                    AcademicYearId = magazineViewModel.Magazine.AcademicYearId

                };

                var result = await _dbContext.Magazines!.AddAsync(newMagazine);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }
        }

        public Task<Magazine> UpdateMagazine(MagazineViewModel magazineViewModel)
		{
			throw new NotImplementedException();
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
    }
}
