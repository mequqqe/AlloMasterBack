namespace AlloMasterBackend.Models;

public class Branches
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string BranchName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

}