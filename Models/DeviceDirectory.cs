namespace AlloMasterBackend.Models;

public class DeviceDirectory 
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string Group { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}