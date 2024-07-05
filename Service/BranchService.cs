using AlloMasterBackend.Models;
using AlloMasterBackend.Models.DTOs;
using AlloMasterBackend.Repository;

namespace AlloMasterBackend.Service;

// BranchService.cs
public class BranchService : IBranchService
{
    private readonly IBranchRepository _branchRepository;

    public BranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<Branches> AddBranchAsync(CreateBranchDto createBranchDto, int companyId)
    {
        var branch = new Branches
        {
            CompanyId = companyId,
            BranchName = createBranchDto.BranchName,
            Address = createBranchDto.Address,
            PhoneNumber = createBranchDto.PhoneNumber
        };

        return await _branchRepository.AddBranchAsync(branch);
    }
    
    public async Task<IEnumerable<Branches>> GetBranchesByCompanyIdAsync(int companyId)
    {
        return await _branchRepository.GetBranchesByCompanyIdAsync(companyId);
    }
}
