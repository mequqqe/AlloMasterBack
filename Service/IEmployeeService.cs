using AlloMasterBackend.Models;
using AlloMasterBackend.Models.DTOs;

namespace AlloMasterBackend.Service;

public interface IEmployeeService
{
    Task<Employees> AddEmployeeAsync(CreateEmployeeDto createEmployeeDto, int companyId);
}