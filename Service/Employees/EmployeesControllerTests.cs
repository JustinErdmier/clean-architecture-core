using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

using Moq.AutoMock;

using NUnit.Framework;

namespace CleanArchitecture.Service.Employees;

[ TestFixture ]
public sealed class EmployeesControllerTests
{
    [ SetUp ]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _controller = _mocker.CreateInstance<EmployeesController>();
    }

    private EmployeesController _controller;

    private AutoMocker _mocker;

    [ Test ]
    public void TestGetEmployeesListShouldReturnListOfEmployees()
    {
        var employee = new EmployeeModel();

        _mocker.GetMock<IGetEmployeesListQuery>()
               .Setup(p => p.Execute())
               .Returns(new List<EmployeeModel> { employee });

        IEnumerable<EmployeeModel> results = _controller.Get();

        Assert.That(results,
                    Contains.Item(employee));
    }
}
