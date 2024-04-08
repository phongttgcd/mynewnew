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

        public async Task<User> GetUser(string idUser)
        {

            var user = await _userManager.FindByIdAsync(idUser);
            return user;
        }

        public IEnumerable<UsersViewModel> GetAllUsers()
        {
            var users = _userManager.Users.Select(c => new UsersViewModel()
            {
                Id = c.Id,
                Username = c.UserName,
                Email = c.Email,
                Faculty = c.Faculty.FacultyName,
                Role = string.Join(",", _userManager.GetRolesAsync(c).Result.ToArray())
            }).ToList();

            return users;
        }

        public async Task<User> RemoveUser(string idUser)
        {
            var user = await _userManager.FindByIdAsync(idUser);
            if (user == null)
            {
                return null; 
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return user; 
            }
            else
            {
                throw new Exception($"Failed to delete user: {result.Errors.FirstOrDefault()?.Description}");
            }
        }
    }
}
