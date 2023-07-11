using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Products;

public sealed class Product : IEntity
{
    public string Name { get; set; }

    public decimal Price { get; init; }

    public int Id { get; set; }
}
