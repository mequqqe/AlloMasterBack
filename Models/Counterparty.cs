namespace AlloMasterBackend.Models;

public class Counterparty
{
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public bool Organization { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Comment { get; set; }
    public string Description { get; set; }
    public string BankDetails { get; set; }
}