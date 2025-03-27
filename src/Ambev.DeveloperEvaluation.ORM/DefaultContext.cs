using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<StoreBranch> StoreBranche { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<Order> Order { get; set; }


    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }
}
//public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
//{
//    public DefaultContext CreateDbContext(string[] args)
//    {
//        IConfigurationRoot configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json")
//            .Build();

//        var builder = new DbContextOptionsBuilder<DefaultContext>();
//        var connectionString = configuration.GetConnectionString("DefaultConnection");


//        builder.UseSqlServer(connectionString);

//        return new DefaultContext(builder.Options);
//    }
//}