using NUnit.Framework;

namespace CleanArchitecture.Domain.Products;

[ TestFixture ]
public sealed class ProductTests
{
    [ SetUp ]
    public void SetUp()
    {
        _product = new Product();
    }

    private Product _product;

    private const int Id = 1;

    private const string Name = "Test";

    [ Test ]
    public void TestSetAndGetId()
    {
        _product.Id = Id;

        Assert.That(_product.Id,
                    Is.EqualTo(Id));
    }

    [ Test ]
    public void TestSetAndGetName()
    {
        _product.Name = Name;

        Assert.That(_product.Name,
                    Is.EqualTo(Name));
    }
}
