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
    public string Role { get; set; }
    public Roles role { get; set; }
}