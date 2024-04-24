using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace COMP1640_WebDev.Repositories
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AcademicYearRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AcademicYear> GetAcademicYear(string idAcademicYear)
        {
            var academicYearInDB = await _dbContext.AcademicYears!
                  .Include(u => u.Magazines)
               .SingleOrDefaultAsync(i => i.Id == idAcademicYear);

            if (academicYearInDB == null)
            {
                throw new InvalidOperationException($"Semester with ID {idAcademicYear} not found.");
            }

            return academicYearInDB;
        }

        public async Task<IEnumerable<AcademicYear>> GetAcademicYears()
        {
            return await _dbContext.AcademicYears!.ToListAsync();
        }

        public async Task<AcademicYear> CreateAcademicYear(AcademicYear academicYear)
		{
			AcademicYear semesterToCreate = new()
			{
				Id = academicYear.Id,
				StartDate = academicYear.StartDate,
                ClosureDate = academicYear.ClosureDate,
                FinalDate = academicYear.FinalDate
              
			};

			var result = await _dbContext.AcademicYears!.AddAsync(semesterToCreate);
			await _dbContext.SaveChangesAsync();

			return result.Entity;
		}

		public async Task<AcademicYear> UpdateAcademicYear(string idAcademicYear, AcademicYear academicYear)
		{
            var academicYearInDb = await _dbContext.AcademicYears!.SingleOrDefaultAsync(e => e.Id == idAcademicYear);

            if (academicYearInDb == null)
            {
                throw new InvalidOperationException($"Semester with ID {idAcademicYear} not found.");
            }

            academicYearInDb.Id = academicYear.Id;
            academicYearInDb.StartDate = academicYear.StartDate;
            academicYearInDb.ClosureDate = academicYear.ClosureDate;
            academicYearInDb.FinalDate = academicYear.FinalDate;

            await _dbContext.SaveChangesAsync();

            return academicYear;
        }


        public async Task<AcademicYear> RemoveAcademicYear(string idAcademicYear)
        {
            var academicYearToRemove = await _dbContext.AcademicYears!.FindAsync(idAcademicYear);

            if (academicYearToRemove == null)
            {
                throw new ArgumentNullException(nameof(academicYearToRemove), "Semester to remove cannot be null.");
            }

            _dbContext.AcademicYears.Remove(academicYearToRemove);
            await _dbContext.SaveChangesAsync();

            return academicYearToRemove;
        }

        public async Task<bool> IsAcademicYearIdExists(string idAcademicYear)
        {
            var existingAcademicYear = await _dbContext.AcademicYears!.FirstOrDefaultAsync(f => f.Id == idAcademicYear);
            return existingAcademicYear != null;
        }
    }
}
