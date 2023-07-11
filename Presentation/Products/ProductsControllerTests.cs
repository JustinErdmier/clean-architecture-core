using CleanArchitecture.Application.Products.Queries.GetProductsList;

using Microsoft.AspNetCore.Mvc;

using Moq.AutoMock;

using NUnit.Framework;

namespace CleanArchitecture.Presentation.Products;

[ TestFixture ]
public sealed class ProductsControllerTests
{
    [ SetUp ]
    public void SetUp()
    {
        _model = new ProductModel();

        _mocker = new AutoMocker();

        _mocker.GetMock<IGetProductsListQuery>()
               .Setup(p => p.Execute())
               .Returns(new List<ProductModel> { _model });

        _controller = _mocker.CreateInstance<ProductsController>();
    }

    private ProductsController _controller;

    private AutoMocker _mocker;

    private ProductModel _model;

    [ Test ]
    public void TestGetIndexShouldReturnListOfProducts()
    {
        ViewResult viewResult = _controller.Index();

        var result = (List<ProductModel>) viewResult.Model;

        Assert.IsNotNull(result);
        Assert.That(result.Single(), Is.EqualTo(_model));
    }
}
