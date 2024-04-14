using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;

namespace COMP1640_WebDev.Repositories.Interfaces
{
    public interface IMagazineRepository
    {
        Task<IEnumerable<Magazine>> GetMagazines();
        Task<Magazine> GetMagazine(string id);
        Task<Magazine> CreateMagazine(Magazine magazine);
        Task<Magazine> RemoveMagazine(string id);
        Task<Magazine> UpdateMagazine(string id, Magazine magazine);


    }
}
