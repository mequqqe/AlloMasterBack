namespace AlloMasterBackend.Models;


public class Employees
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public Branches Branch { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public Roles Role { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}