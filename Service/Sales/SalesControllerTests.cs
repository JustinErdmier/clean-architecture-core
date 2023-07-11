using System.Net;

using CleanArchitecture.Application.Sales.Commands.CreateSale;
using CleanArchitecture.Application.Sales.Queries.GetSaleDetail;
using CleanArchitecture.Application.Sales.Queries.GetSalesList;

using Moq;
using Moq.AutoMock;

using NUnit.Framework;

namespace CleanArchitecture.Service.Sales;

[ TestFixture ]
public sealed class SalesControllerTests
{
    [ SetUp ]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _controller = _mocker.CreateInstance<SalesController>();
    }

    private SalesController _controller;

    private AutoMocker _mocker;

    [ Test ]
    public void TestGetShouldReturnListOfSales()
    {
        var sale = new SalesListItemModel();

        _mocker.GetMock<IGetSalesListQuery>()
               .Setup(p => p.Execute())
               .Returns(new List<SalesListItemModel> { sale });

        IEnumerable<SalesListItemModel> result = _controller.Get();

        Assert.That(result,
                    Contains.Item(sale));
    }

    [ Test ]
    public void TestGetShouldReturnSaleDetails()
    {
        var sale = new SaleDetailModel();

        _mocker.GetMock<IGetSaleDetailQuery>()
               .Setup(p => p.Execute(1))
               .Returns(sale);

        SaleDetailModel result = _controller.Get(1);

        Assert.That(result,
                    Is.EqualTo(sale));
    }

    [ Test ]
    public void TestCreateSaleShouldCreateSale()
    {
        var sale = new CreateSaleModel();

        HttpResponseMessage result = _controller.Create(sale);

        _mocker.GetMock<ICreateSaleCommand>()
               .Verify(p => p.Execute(sale),
                       Times.Once);

        Assert.That(result.StatusCode,
                    Is.EqualTo(HttpStatusCode.Created));
    }
}
