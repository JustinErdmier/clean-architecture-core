using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

public sealed class GetEmployeesListQuery
    : IGetEmployeesListQuery
{
    private readonly IDatabaseService _database;

    public GetEmployeesListQuery(IDatabaseService database) => _database = database;

    public List<EmployeeModel> Execute()
    {
        IQueryable<EmployeeModel> employees = _database.Employees
                                                       .Select(p => new EmployeeModel
                                                       {
                                                           Id   = p.Id,
                                                           Name = p.Name
                                                       });

        return employees.ToList();
    }
}
