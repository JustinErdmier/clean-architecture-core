using CleanArchitecture.Application.Customers.Queries.GetCustomerList;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Customers;

public sealed class CustomersController : Controller
{
    private readonly IGetCustomersListQuery _query;

    public CustomersController(IGetCustomersListQuery query) => _query = query;

    public ViewResult Index()
    {
        List<CustomerModel> customers = _query.Execute();

        // ReSharper disable once Mvc.ViewNotResolved
        return View(customers);
    }
}
