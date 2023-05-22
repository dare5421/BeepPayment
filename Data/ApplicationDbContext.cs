
using BeepPayment.ConsumeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeepPayment.ConsumeAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
    public DbSet<TransactionStatus> TransactionStatuses { get; set; }
}