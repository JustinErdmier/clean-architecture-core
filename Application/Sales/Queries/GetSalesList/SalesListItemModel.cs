namespace CleanArchitecture.Application.Sales.Queries.GetSalesList;

public class SalesListItemModel
{
    public int Id { get; init; }

    public DateTime Date { get; init; }

    public string CustomerName { get; init; }

    public string EmployeeName { get; init; }

    public string ProductName { get; init; }

    public decimal UnitPrice { get; init; }

    public int Quantity { get; init; }

    public decimal TotalPrice { get; init; }
}
