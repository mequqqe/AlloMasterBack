namespace AlloMasterBackend.Models;

public class RepairStatus
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string Name { get; set; }
    public string ColorHash { get; set; }   
}