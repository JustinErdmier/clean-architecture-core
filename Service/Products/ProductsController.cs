using CleanArchitecture.Application.Products.Queries.GetProductsList;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Service.Products;

[ ApiController, Route("api/[controller]") ]
public sealed class ProductsController : ControllerBase
{
    private readonly IGetProductsListQuery _query;

    public ProductsController(IGetProductsListQuery query) => _query = query;

    [ HttpGet ]
    public IEnumerable<ProductModel> Get() => _query.Execute();
}
