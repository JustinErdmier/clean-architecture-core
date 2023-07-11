using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale.Factory;

public sealed class SaleFactory : ISaleFactory
{
    public Sale Create(DateTime date, Customer customer, Employee employee, Product product, int quantity)
    {
        var sale = new Sale
        {
            Date     = date,
            Customer = customer,
            Employee = employee,
            Product  = product
        };

        sale.UnitPrice = sale.Product.Price;

        sale.Quantity = quantity;

        // Note: Total price is calculated in domain logic

        return sale;
    }
}
