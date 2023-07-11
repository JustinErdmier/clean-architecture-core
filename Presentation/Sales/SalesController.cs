using CleanArchitecture.Application.Sales.Commands.CreateSale;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetail;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;
using CleanArchitecture.Presentation.Sales.Models;
using CleanArchitecture.Presentation.Sales.Services;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Sales;

[ Route("sales") ]
public sealed class SalesController : Controller
{
    private readonly ICreateSaleCommand _createCommand;

    private readonly ICreateSaleViewModelFactory _factory;

    private readonly IGetSaleDetailQuery _saleDetailQuery;

    private readonly IGetSalesListQuery _salesListQuery;

    public SalesController(IGetSalesListQuery          salesListQuery,
                           IGetSaleDetailQuery         saleDetailQuery,
                           ICreateSaleViewModelFactory factory,
                           ICreateSaleCommand          createCommand)
    {
        _salesListQuery  = salesListQuery;
        _saleDetailQuery = saleDetailQuery;
        _factory         = factory;
        _createCommand   = createCommand;
    }

    [ Route("") ]
    public ViewResult Index()
    {
        List<SalesListItemModel> sales = _salesListQuery.Execute();

        // ReSharper disable once Mvc.ViewNotResolved
        return View(sales);
    }

    [ Route("{id:int}") ]
    public ViewResult Detail(int id)
    {
        SaleDetailModel sale = _saleDetailQuery.Execute(id);

        // ReSharper disable once Mvc.ViewNotResolved
        return View(sale);
    }

    [ Route("create") ]
    public ViewResult Create()
    {
        CreateSaleViewModel viewModel = _factory.Create();

        // ReSharper disable once Mvc.ViewNotResolved
        return View(viewModel);
    }

    [ Route("create"), HttpPost ]
    public IActionResult Create(CreateSaleViewModel viewModel)
    {
        CreateSaleModel model = viewModel.Sale;

        _createCommand.Execute(model);

        return RedirectToAction("index", "sales");
    }
}
