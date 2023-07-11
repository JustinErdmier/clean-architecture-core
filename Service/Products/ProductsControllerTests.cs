using CleanArchitecture.Application.Products.Queries.GetProductsList;

using Moq.AutoMock;

using NUnit.Framework;

namespace CleanArchitecture.Service.Products;

[ TestFixture ]
public sealed class ProductsControllerTests
{
    [ SetUp ]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _controller = _mocker.CreateInstance<ProductsController>();
    }

    private ProductsController _controller;

    private AutoMocker _mocker;

    [ Test ]
    public void TestGetProductsListShouldReturnListOfProducts()
    {
        var product = new ProductModel();

        _mocker.GetMock<IGetProductsListQuery>()
               .Setup(p => p.Execute())
               .Returns(new List<ProductModel> { product });

        IEnumerable<ProductModel> results = _controller.Get();

        Assert.That(results,
                    Contains.Item(product));
    }
}
