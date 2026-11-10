using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace BillingSoftware.Database;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BillingDbContext>
{
    public BillingDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BillingDbContext>();
        optionsBuilder.UseSqlite("Data Source=billing.db");
        return new BillingDbContext(optionsBuilder.Options);
    }
}
