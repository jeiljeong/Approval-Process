using Microsoft.EntityFrameworkCore;
using ApprovalProcess.Models;

public class OracleDbContext : DbContext
{
    public OracleDbContext(DbContextOptions<OracleDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApprovalRequest> ApprovalRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure your model and Oracle specifics here, if needed
    }
}
