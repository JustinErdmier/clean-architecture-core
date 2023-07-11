using CleanArchitecture.Application.Products.Queries.GetProductsList;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Products;

public sealed class ProductsController : Controller
{
    private readonly IGetProductsListQuery _query;

    public ProductsController(IGetProductsListQuery query) => _query = query;

    public ViewResult Index()
    {
        List<ProductModel> products = _query.Execute();

        // ReSharper disable once Mvc.ViewNotResolved
        return View(products);
    }
}
