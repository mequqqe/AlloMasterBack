using Microsoft.EntityFrameworkCore;
using AlloMasterBackend.Data;
using AlloMasterBackend.Models;
using System.Threading.Tasks;

namespace AlloMasterBackend.Repository
{

    public class CompanyRepository : ICompanyRepository

    {
        private readonly AlloMasterDbContext _context;

        public CompanyRepository(AlloMasterDbContext context)
        {
            _context = context;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Company.FindAsync(id);
        }

        public async Task<Company> GetByEmailAsync(string email)
        {
            return await _context.Company.SingleOrDefaultAsync(c => c.Mail == email);
        }

        public async Task AddAsync(Company company)
        {
            await _context.Company.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _context.Company.FindAsync(id);
        }
    }
}