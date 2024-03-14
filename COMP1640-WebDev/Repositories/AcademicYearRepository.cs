using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;

namespace COMP1640_WebDev.Repositories
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AcademicYearRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
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

        public async Task<IEnumerable<AcademicYear>> GetAcademicYears()
        {
            return await _dbContext.AcademicYears.ToListAsync();
        }

        public AcademicYearViewModel GetAcademicYearViewModel()
        {
            var viewModel = new AcademicYearViewModel()
            {
                Falculties = _dbContext.Faculties.ToList()
            };
            return viewModel;
        }

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
