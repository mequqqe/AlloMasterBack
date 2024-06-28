using AlloMasterBackend.Models;

namespace AlloMasterBackend.Service;

public class LoginResponse
{
    public string Token { get; set; }
    public Company Company { get; set; }
}