namespace AlloMasterBackend.Models;

public class Repair {
    public int Id { get; set; }

    public int BranchId { get; set; }
    public Branches Branches { get; set; }
    public DateTime Date { get; set; }
    public int CounterpartyId { get; set; }
    public Counterparty Counterparty { get; set; }
    public string Phone { get; set; }
    public int DeviceId { get; set; }   
    public DeviceDirectory Device { get; set; }
    public int Code { get; set; }
    public string Completeness { get; set; }
    public string ReasonForContract { get; set; }
    public int EmployeeId { get; set; }
    public Employees Employee { get; set; }
    public int Price { get; set; }
    public string Comment { get; set; }


}