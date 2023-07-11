using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

using Microsoft.AspNetCore.Mvc;

using Moq.AutoMock;

using NUnit.Framework;

namespace CleanArchitecture.Presentation.Employees;

[ TestFixture ]
public sealed class EmployeesControllerTests
{
    [ SetUp ]
    public void SetUp()
    {
        _model = new EmployeeModel();

        _mocker = new AutoMocker();

        _mocker.GetMock<IGetEmployeesListQuery>()
               .Setup(p => p.Execute())
               .Returns(new List<EmployeeModel> { _model });

        _controller = _mocker.CreateInstance<EmployeesController>();
    }

    private EmployeesController _controller;

    private AutoMocker _mocker;

    private EmployeeModel _model;

    [ Test ]
    public void TestGetIndexShouldReturnListOfEmployees()
    {
        ViewResult viewResult = _controller.Index();

        var result = (List<EmployeeModel>) viewResult.Model;

        Assert.IsNotNull(result);
        Assert.That(result.Single(), Is.EqualTo(_model));
    }
}
