namespace AlloMasterBackend.Models;

public class Sales {
    public int Id { get; set; }

    public int BranchId { get; set; }
    public Branches Branches { get; set; }
    public Counterparty Counterparty { get; set; }
    public int ProductId { get; set; }
    public ProductDirectory Product  { get; set; }
    public int ServiceId { get; set; }  
    public ServiceDirectory Service { get; set; }
    public int Code { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public int TypePaymentId { get; set; }
    public TypePayment TypePayment { get; set; }

}