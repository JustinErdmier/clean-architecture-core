using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Products.Queries.GetProductsList;

public sealed class GetProductsListQuery
    : IGetProductsListQuery
{
    private readonly IDatabaseService _database;

    public GetProductsListQuery(IDatabaseService database) => _database = database;

    public List<ProductModel> Execute()
    {
        IQueryable<ProductModel> products = _database.Products
                                                     .Select(p => new ProductModel
                                                     {
                                                         Id        = p.Id,
                                                         Name      = p.Name,
                                                         UnitPrice = p.Price
                                                     });

        return products.ToList();
    }
}
