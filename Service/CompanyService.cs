using AlloMasterBackend.Models;
using AlloMasterBackend.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;

namespace AlloMasterBackend.Service
{
public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IConfiguration _configuration;

        public CompanyService(ICompanyRepository companyRepository, IConfiguration configuration)
        {
            _companyRepository = companyRepository;
            _configuration = configuration;
        }

        public async Task<Company> RegisterAsync(Company company)
        {
            var existingCompany = await _companyRepository.GetByEmailAsync(company.Mail);
            if (existingCompany != null)
            {
                throw new Exception("Company already exists.");
            }

            // Hash the password
            company.Password = BCrypt.Net.BCrypt.HashPassword(company.Password);

            await _companyRepository.AddAsync(company);
            return company;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var company = await _companyRepository.GetByEmailAsync(email);
            if (company == null || !BCrypt.Net.BCrypt.Verify(password, company.Password))
            {
                throw new Exception("Invalid credentials.");
            }

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, company.Id.ToString()),
                    new Claim(ClaimTypes.Email, company.Mail),
                    new Claim("CompanyName", company.CompanyName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}