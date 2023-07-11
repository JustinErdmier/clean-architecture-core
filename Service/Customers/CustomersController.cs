using CleanArchitecture.Application.Customers.Queries.GetCustomerList;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Service.Customers;

[ ApiController, Route("api/[controller]") ]
public sealed class CustomersController : ControllerBase
{
    private readonly IGetCustomersListQuery _query;

    public CustomersController(IGetCustomersListQuery query) => _query = query;

    [ HttpGet ]
    public IEnumerable<CustomerModel> Get() => _query.Execute();
}
