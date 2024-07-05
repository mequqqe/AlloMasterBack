using AlloMasterBackend.Models;

namespace AlloMasterBackend.Repository;

public interface IEmployeeRepository
{
    Task AddAsync(Employees employee);
}