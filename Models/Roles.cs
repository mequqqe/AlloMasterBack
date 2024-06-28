namespace AlloMasterBackend.Models;

public class Roles
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string RoleName { get; set; }
    public string Permissions { get; set; }

}