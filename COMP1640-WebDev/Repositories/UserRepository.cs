using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace COMP1640_WebDev.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateUser(User user)
        {
            User userToCreate = new()
            {
                UserName = user.UserName,
                Email= user.Email,
                PhoneNumber= user.PhoneNumber,
                CreatedTime = DateTime.Now,
            };

            var result = await _dbContext.Users.AddAsync(userToCreate);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<User> GetUser(string idUser)
        {
            var userInDB = _dbContext.Users
              .Include(i => i.Faculty)
              .Include(u => u.Contributions)
              .Include(y => y.Notifications)
              .SingleOrDefault(i => i.Id == idUser);

            if (userInDB == null)
            {
                return null;
            }

            return userInDB;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public Task<User> RemoveUser(string idUser)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUser(string idUser, User user)
        {
            var userInDb = await _dbContext.Users
                 .SingleOrDefaultAsync(e => e.Id == idUser);

            if (userInDb == null)
            {
                return null;
            }

            userInDb.UserName = user.UserName;
            userInDb.Email = user.Email;
            userInDb.PhoneNumber = user.PhoneNumber;
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
