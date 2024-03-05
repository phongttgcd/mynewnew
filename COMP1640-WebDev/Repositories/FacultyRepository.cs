using COMP1640_WebDev.Models;
using COMP1640_WebDev.Repositories.Interfaces;

namespace COMP1640_WebDev.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        public Task<Faculty> CreateFaculty(Faculty faculty)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Faculty>> GetFaculties()
        {
            throw new NotImplementedException();
        }

        public Task<Faculty> GetFaculty(string idFaculty)
        {
            throw new NotImplementedException();
        }

        public Task<Faculty> RemoveFaculty(string idFaculty)
        {
            throw new NotImplementedException();
        }

        public Task<Faculty> UpdateFaculty(string idFaculty, Faculty faculty)
        {
            throw new NotImplementedException();
        }
    }
}
