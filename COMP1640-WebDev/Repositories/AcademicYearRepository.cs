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
        public async Task<AcademicYear> CreateAcademicYear(AcademicYear academicYear)
        {
            AcademicYear academicYearToCreate = new()
            {
                Faculty = academicYear.Faculty,
                FinalDate = academicYear.FinalDate,
                ClosureDate = academicYear.ClosureDate,
                StartDate = academicYear.StartDate,
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

        public Task<AcademicYear> RemoveAcademicYear(string idAcademicYear)
        {
            throw new NotImplementedException();
        }

        public async Task<AcademicYear> UpdateAcademicYear(string idAcademicYear, AcademicYear academicYear)
        {
            var academicYearInDb = await _dbContext.AcademicYears
                             .SingleOrDefaultAsync(e => e.Id == idAcademicYear);

            if (academicYearInDb == null)
            {
                return null;
            }

            academicYearInDb.StartDate = academicYear.StartDate;
            academicYearInDb.ClosureDate = academicYear.ClosureDate;
            academicYearInDb.FinalDate = academicYear.FinalDate;
            await _dbContext.SaveChangesAsync();

            return academicYearInDb;
        }
    }
}
