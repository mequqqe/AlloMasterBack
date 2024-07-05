using AlloMasterBackend.Data;
using AlloMasterBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AlloMasterBackend.Repository;

public class BranchRepository : IBranchRepository
{
    private readonly AlloMasterDbContext _context;

    public BranchRepository(AlloMasterDbContext context)
    {
        _context = context;
    }

    public async Task<Branches> AddBranchAsync(Branches branch)
    {
        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();
        return branch;
    }
    
    public async Task<IEnumerable<Branches>> GetBranchesByCompanyIdAsync(int companyId)
    {
        return await _context.Branches.Where(b => b.CompanyId == companyId).ToListAsync();
    }
}