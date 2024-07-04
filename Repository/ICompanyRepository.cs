using AlloMasterBackend.Models;
using System.Threading.Tasks;

namespace AlloMasterBackend.Repository
{

    public interface ICompanyRepository

    {
        Task<Company> GetByIdAsync(int id);
        Task<Company> GetByEmailAsync(string email);
        Task AddAsync(Company company);
        Task<Company> GetCompanyByIdAsync(int id);
    }
}