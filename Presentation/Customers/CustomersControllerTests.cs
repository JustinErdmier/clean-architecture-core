using CleanArchitecture.Application.Customers.Queries.GetCustomerList;

using Microsoft.AspNetCore.Mvc;

using Moq.AutoMock;

using NUnit.Framework;

namespace CleanArchitecture.Presentation.Customers;

[ TestFixture ]
public sealed class CustomersControllerTests
{
    [ SetUp ]
    public void SetUp()
    {
        _model = new CustomerModel();

        _mocker = new AutoMocker();

        _mocker.GetMock<IGetCustomersListQuery>()
               .Setup(p => p.Execute())
               .Returns(new List<CustomerModel> { _model });

        _controller = _mocker.CreateInstance<CustomersController>();
    }

    private CustomersController _controller;

    private AutoMocker _mocker;

    private CustomerModel _model;

    [ Test ]
    public void TestGetIndexShouldReturnListOfCustomers()
    {
        ViewResult viewResult = _controller.Index();

        var result = (List<CustomerModel>) viewResult.Model;

        Assert.IsNotNull(result);
        Assert.That(result.Single(), Is.EqualTo(_model));
    }
}
