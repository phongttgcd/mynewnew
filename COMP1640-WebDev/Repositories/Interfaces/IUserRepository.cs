using COMP1640_WebDev.Models;

namespace COMP1640_WebDev.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string idUser);
        Task<User> CreateUser(User user);
        Task<User> RemoveUser(string idUser);
        Task<User> UpdateUser(string idUser, User user);
    }
}
