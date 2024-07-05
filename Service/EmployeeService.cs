using AlloMasterBackend.Models;
using AlloMasterBackend.Models.DTOs;
using AlloMasterBackend.Repository;

namespace AlloMasterBackend.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Employees> AddEmployeeAsync(CreateEmployeeDto createEmployeeDto, int companyId)
    {
        var employee = new Employees
        {
            BranchId = createEmployeeDto.BranchId,
            Name = createEmployeeDto.Name,
            Mail = createEmployeeDto.Mail,
            PhoneNumber = createEmployeeDto.PhoneNumber,
            Password = createEmployeeDto.Password,
            RoleId = createEmployeeDto.RoleId, // Assuming you have RoleId in CreateEmployeeDto
            CompanyId = companyId
        };

        await _employeeRepository.AddAsync(employee);
        return employee;
    }
}