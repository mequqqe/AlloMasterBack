using AlloMasterBackend.Models;
using AlloMasterBackend.Models.DTOs;

namespace AlloMasterBackend.Service;

public interface IBranchService
{
    Task<Branches> AddBranchAsync(CreateBranchDto createBranchDto, int companyId);
    Task<IEnumerable<Branches>> GetBranchesByCompanyIdAsync(int companyId);
}
