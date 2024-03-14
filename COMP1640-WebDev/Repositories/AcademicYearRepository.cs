using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace COMP1640_WebDev.Repositories
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AcademicYearRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // 1. Function to create academic year
        public async Task<AcademicYear> CreateAcademicYear(AcademicYearViewModel viewModel)
        {
            AcademicYear academicYearToCreate = new()
            {
                FinalDate = viewModel.AcademicYear.FinalDate,
                ClosureDate = viewModel.AcademicYear.ClosureDate,
                StartDate = viewModel.AcademicYear.StartDate,
                FacultyId = viewModel.AcademicYear.FacultyId
            };

            var result = await _dbContext.AcademicYears.AddAsync(academicYearToCreate);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        // 2. Function to get academic year by id
        public async Task<AcademicYear>? GetAcademicYear(string idAcademicYear)
        {
            var academicYearInDB = _dbContext.AcademicYears
                .Include(i => i.Faculty)
                .SingleOrDefault(i => i.Id == idAcademicYear);

            if (academicYearInDB == null)
            {
                return null;
            }

            return academicYearInDB;
        }

        // 3. Function to get a list of academic year
        public async Task<IEnumerable<AcademicYear>> GetAcademicYears()
        {
            return await _dbContext.AcademicYears.ToListAsync();
        }

        // 4. Function to return academic year view model
        public AcademicYearViewModel GetAcademicYearViewModel()
        {
            var viewModel = new AcademicYearViewModel()
            {
                Falculties = _dbContext.Faculties.ToList()
            };
            return viewModel;
        }


        // 5. Function to remove academic year by id.
        public async Task<AcademicYear> RemoveAcademicYear(string idAcademicYear)
        {
            var academicYearToRemove = await _dbContext.AcademicYears.FindAsync(idAcademicYear);

            if (academicYearToRemove == null)
            {
                throw new ArgumentNullException(nameof(academicYearToRemove), "Semester to remove cannot be null.");
            }

            _dbContext.AcademicYears.Remove(academicYearToRemove);
            await _dbContext.SaveChangesAsync();

            return academicYearToRemove;
        }


        // 6. Function to update academic year
        public async Task<AcademicYear> UpdateAcademicYear(AcademicYearViewModel academicYearViewModel)
        {
            var academicYearInDb = await _dbContext.AcademicYears
                             .SingleOrDefaultAsync(e => e.Id == academicYearViewModel.AcademicYear.Id);

            if (academicYearInDb == null)
            {
                return null;
            }


            academicYearInDb.FacultyId = academicYearViewModel.AcademicYear.FacultyId;
            academicYearInDb.StartDate = academicYearViewModel.AcademicYear.StartDate;
            academicYearInDb.ClosureDate = academicYearViewModel.AcademicYear.ClosureDate;
            academicYearInDb.FinalDate = academicYearViewModel.AcademicYear.FinalDate;

            await _dbContext.SaveChangesAsync();

            return academicYearInDb;
        }


        // 7. Function to get academic year view model by id
        public AcademicYearViewModel GetAcademicYearViewModelByID(string idAcademicYear)
        {
            var academicYearInDb = _dbContext.AcademicYears.SingleOrDefault(t => t.Id == idAcademicYear);
            if (academicYearInDb is null)
            {
                throw new ArgumentNullException(nameof(academicYearInDb), "Semester to update cannot be null.");
            }

            var viewModel = new AcademicYearViewModel
            {
                AcademicYear = academicYearInDb,
                Falculties = _dbContext.Faculties.ToList()
            };
            return viewModel;
        }


    }
}
