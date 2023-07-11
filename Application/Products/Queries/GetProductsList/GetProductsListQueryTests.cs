using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Products;

using Moq.AutoMock;
using Moq.EntityFrameworkCore;

using NUnit.Framework;

namespace CleanArchitecture.Application.Products.Queries.GetProductsList;

[ TestFixture ]
public sealed class GetProductsListQueryTests
{
    [ SetUp ]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _product = new Product
        {
            Id   = Id,
            Name = Name
        };

        _mocker.GetMock<IDatabaseService>()
               .Setup(p => p.Products)
               .ReturnsDbSet(new List<Product> { _product });

        _query = _mocker.CreateInstance<GetProductsListQuery>();
    }

    private GetProductsListQuery _query;

    private AutoMocker _mocker;

    private Product _product;

    private const int Id = 1;

    private const string Name = "Product 1";

    [ Test ]
    public void TestExecuteShouldReturnListOfProducts()
    {
        List<ProductModel> results = _query.Execute();

        ProductModel result = results.Single();

        Assert.That(result.Id,   Is.EqualTo(Id));
        Assert.That(result.Name, Is.EqualTo(Name));
    }
}
