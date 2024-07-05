using System.Security.Claims;
using AlloMasterBackend.Models.DTOs;
using AlloMasterBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlloMasterBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchesController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddBranch([FromBody] CreateBranchDto createBranchDto)
    {
        if (createBranchDto == null)
        {
            return BadRequest("Invalid branch data.");
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

        var branch = await _branchService.AddBranchAsync(createBranchDto, companyId);
        return Ok(branch);
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetMyBranches()
    {
        var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? User.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
        if (companyIdClaim == null)
        {
            return Forbid("nameid not found in token.");
        }

        if (!int.TryParse(companyIdClaim, out var companyId))
        {
            return Unauthorized(new { Message = "Invalid nameid value" });
        }

        var branches = await _branchService.GetBranchesByCompanyIdAsync(companyId);
        if (branches == null || !branches.Any())
        {
            return NotFound("No branches found for this company.");
        }

        return Ok(branches);
    }
}