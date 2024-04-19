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

        //1. Function to create new faculty
        public async Task<Faculty> CreateFaculty(Faculty faculty)
        {
            Faculty facultyToCreate = new()
            {
                Id = faculty.Id,
                FacultyName = faculty.FacultyName
            };

            var result = await _dbContext.Faculties.AddAsync(facultyToCreate);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        //2. Function to get faculty list
        public async Task<IEnumerable<Faculty>> GetFaculties()
        {
            return await _dbContext.Faculties.ToListAsync();
        }


        //3. Function to get faculty by id
        public async Task<Faculty?> GetFaculty(string idFaculty)
        {
            var facultyInDB = _dbContext.Faculties
                .Include(u => u.Magazines)
             .Include(u => u.Users)
             .SingleOrDefault(i => i.Id == idFaculty);

            if (facultyInDB == null)
            {
                return null;
            }

            return facultyInDB;
        }

        //4. Function to delete faculty by id 
        public async Task<Faculty> RemoveFaculty(string idFaculty)
        {
            var facultyToRemove = await _dbContext.Faculties.FindAsync(idFaculty);

            if (facultyToRemove == null)
            {
                throw new ArgumentNullException(nameof(facultyToRemove), "Faculty to remove cannot be null.");
            }

            _dbContext.Faculties.Remove(facultyToRemove);
            await _dbContext.SaveChangesAsync();

            return facultyToRemove;
        }

        //5. Function to update faculty by id
        public async Task<Faculty> UpdateFaculty(string idFaculty, Faculty faculty)
        {

            var facultyInDb = await _dbContext.Faculties.SingleOrDefaultAsync(e => e.Id == idFaculty);

            if (facultyInDb == null)
            {
                return null;
            }

            facultyInDb.Id = faculty.Id;
            facultyInDb.FacultyName = faculty.FacultyName;
            await _dbContext.SaveChangesAsync();

            return faculty;
        }

    }
}
