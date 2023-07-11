using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

using NUnit.Framework;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale.Factory;

[ TestFixture ]
public sealed class SaleFactoryTests
{
    [ SetUp ]
    public void SetUp()
    {
        _customer = new Customer();

        _employee = new Employee();

        _product = new Product
        {
            Price = Price
        };

        _factory = new SaleFactory();
    }

    private SaleFactory _factory;

    private Customer _customer;

    private Employee _employee;

    private Product _product;

    private static readonly DateTime DateTime = new (2001, 2, 3);

    private const int Quantity = 123;

    private const decimal Price = 1.00m;

    [ Test ]
    public void TestCreateShouldCreateSale()
    {
        Sale result = _factory.Create(DateTime, _customer, _employee, _product, Quantity);

        Assert.That(result.Date,      Is.EqualTo(DateTime));
        Assert.That(result.Customer,  Is.EqualTo(_customer));
        Assert.That(result.Employee,  Is.EqualTo(_employee));
        Assert.That(result.Product,   Is.EqualTo(_product));
        Assert.That(result.UnitPrice, Is.EqualTo(Price));
        Assert.That(result.Quantity,  Is.EqualTo(Quantity));
    }
}
