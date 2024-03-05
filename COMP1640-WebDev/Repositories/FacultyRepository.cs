using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace COMP1640_WebDev.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FacultyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Faculty> CreateFaculty(Faculty faculty)
        {
            Faculty facultyToCreate = new()
            {
                FacultyName = faculty.FacultyName
            };

            var result = await _dbContext.Faculties.AddAsync(facultyToCreate);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Faculty>> GetFaculties()
        {
            return await _dbContext.Faculties.ToListAsync();
        }

        public async Task<Faculty?> GetFaculty(string idFaculty)
        {
            var facultyInDB = _dbContext.Faculties
                .Include(i => i.AcademicYears)
                .Include(u => u.Users)
                .SingleOrDefault(i => i.Id == idFaculty);

            if (facultyInDB == null)
            {
                return null;
            }
            
            return facultyInDB;
        }

        public Task<Faculty> RemoveFaculty(string idFaculty)
        {
            throw new NotImplementedException();
        }

        public async Task<Faculty> UpdateFaculty(string idFaculty, Faculty faculty)
        {

            var facultyInDb = await _dbContext.Faculties
                             .SingleOrDefaultAsync(e => e.Id == idFaculty);

            if (facultyInDb == null)
            {
                return null;
            }

            facultyInDb.FacultyName = faculty.FacultyName;
            await _dbContext.SaveChangesAsync();

            return faculty;
        }
    }
}
