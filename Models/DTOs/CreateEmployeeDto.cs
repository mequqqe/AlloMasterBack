namespace AlloMasterBackend.Models.DTOs;

public class CreateEmployeeDto
{
    public int BranchId { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
}
