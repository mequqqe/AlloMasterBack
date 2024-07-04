using AlloMasterBackend.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AlloMasterBackend.Models;
using System.Security.Claims;

namespace AlloMasterBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Company company)
        {
            try
            {
                var registeredCompany = await _companyService.RegisterAsync(company);
                return Ok(registeredCompany);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var token = await _companyService.LoginAsync(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        [HttpGet("my-company")]
        public async Task<IActionResult> GetCompanyInfo()
        {
            var companyIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? User.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
            if (companyIdClaim == null)
            {
                return Unauthorized(new { Message = "nameid claim not found" });
            }

            if (!int.TryParse(companyIdClaim, out var companyId))
            {
                return Unauthorized(new { Message = "Invalid nameid value" });
            }

            var company = await _companyService.GetCompanyByIdAsync(companyId);
            if (company == null)
            {
                return NotFound(new { Message = "Company not found." });
            }

            var companyInfo = new
            {
                company.Id,
                company.Name,
                company.Mail,
                company.PhoneNumber,
                company.CompanyName
            };

            return Ok(companyInfo);
        }
    }
}

    

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

