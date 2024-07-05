using AlloMasterBackend.Models;

namespace AlloMasterBackend.Repository;

public interface IBranchRepository
{
    Task<Branches> AddBranchAsync(Branches branch);
    Task<IEnumerable<Branches>> GetBranchesByCompanyIdAsync(int companyId);
}
