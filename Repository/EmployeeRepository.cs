using AlloMasterBackend.Data;
using AlloMasterBackend.Models;

namespace AlloMasterBackend.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AlloMasterDbContext _context;

    public EmployeeRepository(AlloMasterDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Employees employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }
}