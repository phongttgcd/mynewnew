using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;
using COMP1640_WebDev.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

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

        public async Task<int[]> GetUserCounts()
        {
            int[] userCounts = new int[2]; 

            var studentsCount = await _userManager.GetUsersInRoleAsync("Student");
            userCounts[0] = studentsCount.Count;

            var marketingManagersCount = await _userManager.GetUsersInRoleAsync("Marketing Manager");
            userCounts[1] = marketingManagersCount.Count;

            return userCounts;
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

        public async Task<User> EditUser(string idUser, User user)
        {
            var userInDb = await _userManager.FindByIdAsync(idUser);

            if (userInDb == null)
            {
                return null;
            }

            userInDb.Id = user.Id;
            userInDb.UserName = user.UserName;
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public IEnumerable<UsersViewModel> SearchUsers(string attribute, string value)
        {
            var users = GetAllUsers(); 
            if (!string.IsNullOrEmpty(attribute) && !string.IsNullOrEmpty(value))
            {
                switch (attribute)
                {
                    case "Username":
                        users = users.Where(u => u.Username != null && u.Username.Contains(value));
                        break;
                    case "Email":
                        users = users.Where(u => u.Email != null && u.Email.Contains(value));
                        break;
                    case "Faculty":
                        users = users.Where(u => u.Faculty != null && u.Faculty.Contains(value));
                        break;
                    case "Role":
                        users = users.Where(u => u.Role != null && u.Role.Contains(value));
                        break;
                    default:
                        break;
                }
            }
            return users;
        }

       
    }
}
