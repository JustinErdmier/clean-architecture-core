using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Customers;

using Moq.AutoMock;
using Moq.EntityFrameworkCore;

using NUnit.Framework;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerList;

[ TestFixture ]
public sealed class GetCustomersListQueryTests
{
    [ SetUp ]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _customer = new Customer
        {
            Id   = Id,
            Name = Name
        };

        _mocker.GetMock<IDatabaseService>()
               .Setup(p => p.Customers)
               .ReturnsDbSet(new List<Customer> { _customer });

        _query = _mocker.CreateInstance<GetCustomersListQuery>();
    }

    private GetCustomersListQuery _query;

    private AutoMocker _mocker;

    private Customer _customer;

    private const int Id = 1;

    private const string Name = "Customer 1";

    [ Test ]
    public void TestExecuteShouldReturnListOfCustomers()
    {
        List<CustomerModel> results = _query.Execute();

        CustomerModel result = results.Single();

        Assert.That(result.Id,   Is.EqualTo(Id));
        Assert.That(result.Name, Is.EqualTo(Name));
    }
}
