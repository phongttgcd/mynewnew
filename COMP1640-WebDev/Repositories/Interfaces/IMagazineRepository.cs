using COMP1640_WebDev.Data;
using COMP1640_WebDev.Models;
using COMP1640_WebDev.ViewModels;

namespace COMP1640_WebDev.Repositories.Interfaces
{
    public interface IMagazineRepository
    {
		MagazineViewModel GetMagazineViewModel();
		MagazineViewModel GetMagazineViewModelByID(string idMagazine);
		Task<IEnumerable<Magazine>> GetMagazines();
        Task<Magazine> GetMagazineByID(string id);
        Task<Magazine> CreateMagazine(Magazine magazine, IFormFile? formFile);
        Task<Magazine> UpdateMagazine(Magazine magazine, IFormFile? formFile);
        Task<Magazine> RemoveMagazine(string id);


    }
}
