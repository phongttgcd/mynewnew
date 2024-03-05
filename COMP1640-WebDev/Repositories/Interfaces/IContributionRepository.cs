using COMP1640_WebDev.Models;

namespace COMP1640_WebDev.Repositories.Interfaces
{
    public interface IContributionRepository
    {
        Task<IEnumerable<Contribution>> GetContributions();
        Task<Contribution> GetContribution(string idContribution);
        Task<Contribution> CreateContribution(Contribution contribution);
        Task<Contribution> RemoveContribution(string idContribution);
        Task<Contribution> UpdateContribution(string idContribution, Contribution contribution);
    }
}
