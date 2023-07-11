namespace CleanArchitecture.Application.Products.Queries.GetProductsList;

public sealed class ProductModel
{
    public int Id { get; init; }

    public string Name { get; init; }

    public decimal UnitPrice { get; init; }
}
