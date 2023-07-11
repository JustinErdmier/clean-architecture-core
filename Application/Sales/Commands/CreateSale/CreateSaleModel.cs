namespace CleanArchitecture.Application.Sales.Commands.CreateSale;

public sealed class CreateSaleModel
{
    public int CustomerId { get; init; }

    public int EmployeeId { get; init; }

    public int ProductId { get; init; }

    public int Quantity { get; init; }
}
