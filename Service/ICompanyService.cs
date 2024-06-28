using AlloMasterBackend.Models;
using System.Threading.Tasks;

namespace AlloMasterBackend.Service
{
    public interface ICompanyService
    {
        Task<Company> RegisterAsync(Company company);
        Task<string> LoginAsync(string email, string password);
    }
}   