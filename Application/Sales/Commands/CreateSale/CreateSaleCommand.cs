using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Sales.Commands.CreateSale.Factory;
using CleanArchitecture.Common.Dates;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Sales;

namespace CleanArchitecture.Application.Sales.Commands.CreateSale;

public sealed class CreateSaleCommand
    : ICreateSaleCommand
{
    private readonly IDatabaseService _database;

    private readonly IDateService _dateService;

    private readonly ISaleFactory _factory;

    private readonly IInventoryService _inventory;

    public CreateSaleCommand(IDateService      dateService,
                             IDatabaseService  database,
                             ISaleFactory      factory,
                             IInventoryService inventory)
    {
        _dateService = dateService;
        _database    = database;
        _factory     = factory;
        _inventory   = inventory;
    }

    public void Execute(CreateSaleModel model)
    {
        DateTime date = _dateService.GetDate();

        Customer customer = _database.Customers
                                     .Single(p => p.Id == model.CustomerId);

        Employee employee = _database.Employees
                                     .Single(p => p.Id == model.EmployeeId);

        Product product = _database.Products
                                   .Single(p => p.Id == model.ProductId);

        int quantity = model.Quantity;

        Sale sale = _factory.Create(date,
                                    customer,
                                    employee,
                                    product,
                                    quantity);

        _database.Sales.Add(sale);

        _database.Save();

        _inventory.NotifySaleOccurred(product.Id, quantity);
    }
}
