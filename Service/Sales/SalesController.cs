using System.Net;

using CleanArchitecture.Application.Sales.Commands.CreateSale;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetail;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Service.Sales;

[ ApiController, Route("api/[controller]") ]
public sealed class SalesController : ControllerBase
{
    private readonly ICreateSaleCommand _createCommand;

    private readonly IGetSaleDetailQuery _detailQuery;

    private readonly IGetSalesListQuery _listQuery;

    public SalesController(IGetSalesListQuery  listQuery,
                           IGetSaleDetailQuery detailQuery,
                           ICreateSaleCommand  createCommand)
    {
        _listQuery     = listQuery;
        _detailQuery   = detailQuery;
        _createCommand = createCommand;
    }

    [ HttpGet ]
    public IEnumerable<SalesListItemModel> Get() => _listQuery.Execute();

    [ HttpGet("{id}") ]
    public SaleDetailModel Get(int id) => _detailQuery.Execute(id);

    [ HttpPost ]
    public HttpResponseMessage Create(CreateSaleModel sale)
    {
        _createCommand.Execute(sale);

        return new HttpResponseMessage(HttpStatusCode.Created);
    }
}
