using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace COMP1640_WebDev.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationDbContext dbContext,UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public Task<User> GetUser(string idUser)
        {
          /*  var userInDB = _dbContext.UserList
              .Include(i => i.Faculty)
              .Include(u => u.Contributions)
              .Include(y => y.Notifications)
              .SingleOrDefault(i => i.Id == idUser);

            if (userInDB == null)
            {
                return null;
            }

            return userInDB;*/
            throw new NotImplementedException();

        }

        public IEnumerable<UsersViewModel> GetAllUsers()
        {
            var users = _userManager.Users.Select(c => new UsersViewModel()
            {
                Username = c.UserName,
                Email = c.Email,
                Faculty = c.Faculty.FacultyName,
                Role = string.Join(",", _userManager.GetRolesAsync(c).Result.ToArray())
            }).ToList();

            return users;
        }

        public Task<User> RemoveUser(string idUser)
        {
            throw new NotImplementedException();
        }
    }
}
