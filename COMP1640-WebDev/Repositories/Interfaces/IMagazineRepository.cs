using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;

namespace COMP1640_WebDev.Repositories.Interfaces
{
    public interface IMagazineRepository
    {
        Task<IEnumerable<Magazine>> GetMagazines();
        Task<Magazine> GetMagazine(int id);
        Task<Magazine> CreateMagazine(Magazine magazine);
        Task<Magazine> RemoveMagazine(int id);
        Task<Magazine> UpdateMagazine(int id, Magazine magazine);


    }
}
