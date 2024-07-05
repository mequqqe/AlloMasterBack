using AlloMasterBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AlloMasterBackend.Data;

public class AlloMasterDbContext : DbContext
{
    public AlloMasterDbContext(DbContextOptions<AlloMasterDbContext> options) : base(options)
    {
    }

    public DbSet<Branches> Branches { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Counterparty> Counterparty { get; set; }
    public DbSet<ProductDirectory> ProductDirectory { get; set; }
    public DbSet<RepairStatus> RepairStatus { get; set; }
    public DbSet<Sales> Sales { get; set; }
    public DbSet<ServiceDirectory> ServiceDirectory { get; set; }
    public DbSet<TypePayment> TypePayment { get; set; }
    public DbSet<Employees> Employees { get; set; }
}