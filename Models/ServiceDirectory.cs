namespace AlloMasterBackend.Models;

public class ServiceDirectory
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string ServiceName { get; set; }
    public int Code { get; set; }
    public int Guarantee { get; set; }
    public int Price { get; set; }
}