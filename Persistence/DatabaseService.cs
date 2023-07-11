using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;
using CleanArchitecture.Persistence.Customers;
using CleanArchitecture.Persistence.Employees;
using CleanArchitecture.Persistence.Products;
using CleanArchitecture.Persistence.Sales;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Persistence;

public sealed class DatabaseService : DbContext, IDatabaseService
{
    private readonly IConfiguration _configuration;

    public DatabaseService(IConfiguration configuration)
    {
        _configuration = configuration;

        Database.EnsureCreated();
    }

    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Employee> Employees => Set<Employee>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Sale> Sales => Set<Sale>();

    public void Save() => SaveChanges();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _configuration.GetConnectionString("CleanArchitectureCore");

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new CustomerConfiguration().Configure(builder.Entity<Customer>());
        new EmployeeConfiguration().Configure(builder.Entity<Employee>());
        new ProductConfiguration().Configure(builder.Entity<Product>());
        new SaleConfiguration().Configure(builder.Entity<Sale>());
    }
}
