using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Service.Employees;

[ ApiController, Route("api/[controller]") ]
public sealed class EmployeesController : ControllerBase
{
    private readonly IGetEmployeesListQuery _query;

    public EmployeesController(IGetEmployeesListQuery query) => _query = query;

    [ HttpGet ]
    public IEnumerable<EmployeeModel> Get() => _query.Execute();
}
