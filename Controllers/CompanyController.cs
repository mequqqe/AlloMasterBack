using AlloMasterBackend.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AlloMasterBackend.Models;

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
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
