using System.Security.Claims;
using AlloMasterBackend.Models.DTOs;
using AlloMasterBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlloMasterBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
    {
        if (createEmployeeDto == null)
        {
            return BadRequest("Invalid employee data.");
        }
        
        var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? User.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
        if (companyIdClaim == null)
        {
            return Forbid("nameid not found in token.");
        }

        if (!int.TryParse(companyIdClaim, out var companyId))
        {
            return Unauthorized(new { Message = "Invalid nameid value" });
        }

        var employee = await _employeeService.AddEmployeeAsync(createEmployeeDto, companyId);
        return Ok(employee);
    }
}

