using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Interfaces;

public interface IDatabaseService
{
    DbSet<Customer> Customers { get; }

    DbSet<Employee> Employees { get; }

    DbSet<Product> Products { get; }

    DbSet<Sale> Sales { get; }

    void Save();
}
