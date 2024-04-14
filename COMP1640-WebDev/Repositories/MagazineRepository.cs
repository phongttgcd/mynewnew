using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return await _dbContext.Magazines.ToListAsync();
        }

        public async Task<Magazine> GetMagazine(string id)
        {
            return await _dbContext.Magazines
                .AsNoTracking() // Good practice if you're only reading the entity
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Magazine> CreateMagazine(Magazine magazine)
        {
            Magazine magazineToCreate = new()
            {
                Id = magazine.Id,
                Title = magazine.Title,
                Description = magazine.Description,
                FacultyId = magazine.FacultyId,
                CoverImage = magazine.CoverImage,

            };
            var result = await _dbContext.Magazines.AddAsync(magazineToCreate);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

            public async Task<Magazine> UpdateMagazine(string id, Magazine updatedMagazine)
        {
            var magazine = await _dbContext.Magazines.FindAsync(id);
            if (magazine == null)
            {
                throw new KeyNotFoundException($"Magazine with ID {id} not found.");
            }

            magazine.Title = updatedMagazine.Title;
            magazine.Description = updatedMagazine.Description;
            magazine.CoverImage = updatedMagazine.CoverImage;
     
            await _dbContext.SaveChangesAsync();
            return magazine;
        }

        public async Task<Magazine> RemoveMagazine(string id)
        {
            var magazine = await _dbContext.Magazines.FindAsync(id);
            if (magazine == null)
            {
                throw new KeyNotFoundException($"Magazine with ID {id} not found.");
            }

            _dbContext.Magazines.Remove(magazine);
            await _dbContext.SaveChangesAsync();
            return magazine;
        }
    }
}
