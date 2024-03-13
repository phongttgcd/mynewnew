using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        //1. Create new faculty
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

        //2. Get faculty list
        public async Task<IEnumerable<Faculty>> GetFaculties()
        {
            return await _dbContext.Faculties.ToListAsync();
        }


        //3. Get faculty by id
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
        
        //4. Delete faculty
        public async Task<Faculty> RemoveFaculty(string idFaculty)
        {
            var facultyToRemove = await _dbContext.Faculties.FindAsync(idFaculty);
            if (facultyToRemove == null)
            {
                return null; 
            }

            _dbContext.Faculties.Remove(facultyToRemove);
            await _dbContext.SaveChangesAsync();

            return facultyToRemove;
        }

        //5. Update faculty
        public async Task<Faculty> UpdateFaculty(string idFaculty, Faculty faculty)
        {

            var facultyInDb = await _dbContext.Faculties
                             .SingleOrDefaultAsync(e => e.Id == idFaculty);

            if (facultyInDb == null)
            {
                return null;
            }

            facultyInDb.FacultyName = faculty.Id;
            facultyInDb.FacultyName = faculty.FacultyName;
            await _dbContext.SaveChangesAsync();

            return faculty;
        }
    }
}
