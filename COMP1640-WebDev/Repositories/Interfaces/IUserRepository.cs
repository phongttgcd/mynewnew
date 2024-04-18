using COMP1640_WebDev.Models;
using COMP1640_WebDev.ViewModels;

namespace COMP1640_WebDev.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UsersViewModel> GetAllUsers();
        Task<User> GetUser(string idUser);
        Task<User> RemoveUser(string idUser);
        Task<User> EditUser(string idUser, User user);
        IEnumerable<UsersViewModel> SearchUsers(string attribute, string value);
        Task<int[]> GetUserCounts();
    }
}
