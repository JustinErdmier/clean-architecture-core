using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Employees;

public sealed class EmployeesController : Controller
{
    private readonly IGetEmployeesListQuery _query;

    public EmployeesController(IGetEmployeesListQuery query) => _query = query;

    public ViewResult Index()
    {
        List<EmployeeModel> employees = _query.Execute();

        // ReSharper disable once Mvc.ViewNotResolved
        return View(employees);
    }
}
