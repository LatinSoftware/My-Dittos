using System.Reflection;
using Ditto.Common.Domain;
using Microsoft.EntityFrameworkCore;
namespace Ditto.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
    }

}
