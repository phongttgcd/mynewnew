using COMP1640_WebDev.Models;

namespace COMP1640_WebDev.Repositories.Interfaces
{
    public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> GetFaculties();
        Task<Faculty> GetFaculty(string idFaculty);
        Task<Faculty> CreateFaculty(Faculty faculty);
        Task<Faculty> RemoveFaculty(string idFaculty);
        Task<Faculty> UpdateFaculty(string idFaculty, Faculty faculty);
    }
}
