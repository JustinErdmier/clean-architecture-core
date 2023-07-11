using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Employees;

using Moq.AutoMock;
using Moq.EntityFrameworkCore;

using NUnit.Framework;

namespace CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

[ TestFixture ]
public sealed class GetEmployeesListQueryTests
{
    [ SetUp ]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _employee = new Employee
        {
            Id   = Id,
            Name = Name
        };

        _mocker.GetMock<IDatabaseService>()
               .Setup(p => p.Employees)
               .ReturnsDbSet(new List<Employee> { _employee });

        _query = _mocker.CreateInstance<GetEmployeesListQuery>();
    }

    private GetEmployeesListQuery _query;

    private AutoMocker _mocker;

    private Employee _employee;

    private const int Id = 1;

    private const string Name = "Employee 1";

    [ Test ]
    public void TestExecuteShouldReturnListOfEmployees()
    {
        List<EmployeeModel> results = _query.Execute();

        EmployeeModel result = results.Single();

        Assert.That(result.Id,   Is.EqualTo(Id));
        Assert.That(result.Name, Is.EqualTo(Name));
    }
}
