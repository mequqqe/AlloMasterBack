namespace AlloMasterBackend.Models;

public class ProductDirectory 
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductPrice { get; set; }
    public string ProductImage { get; set; }
    public string Guarantee { get; set; }
    public int Code{ get; set;}
    public int OptBalance { get; set; }
    public int PurchasePrice { get; set; }
    public int RetailPrice { get; set; }
}