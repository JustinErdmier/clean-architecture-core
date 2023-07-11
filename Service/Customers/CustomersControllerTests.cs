using CleanArchitecture.Application.Customers.Queries.GetCustomerList;

using Moq.AutoMock;

using NUnit.Framework;

namespace CleanArchitecture.Service.Customers;

[ TestFixture ]
public sealed class CustomersControllerTests
{
    [ SetUp ]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _controller = _mocker.CreateInstance<CustomersController>();
    }

    private CustomersController _controller;

    private AutoMocker _mocker;

    [ Test ]
    public void TestGetCustomersListShouldReturnListOfCustomers()
    {
        var customer = new CustomerModel();

        _mocker.GetMock<IGetCustomersListQuery>()
               .Setup(p => p.Execute())
               .Returns(new List<CustomerModel> { customer });

        IEnumerable<CustomerModel> results = _controller.Get();

        Assert.That(results,
                    Contains.Item(customer));
    }
}
