namespace AlloMasterBackend.Models;

public class TypePayment {
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}