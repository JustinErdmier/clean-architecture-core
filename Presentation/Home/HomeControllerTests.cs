using Microsoft.AspNetCore.Mvc;

using Moq.AutoMock;

using NUnit.Framework;

namespace CleanArchitecture.Presentation.Home;

[ TestFixture ]
public sealed class HomeControllerTests
{
    [ SetUp ]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _controller = _mocker.CreateInstance<HomeController>();
    }

    private HomeController _controller;

    private AutoMocker _mocker;

    [ Test ]
    public void TestGetIndexShouldReturnView()
    {
        ViewResult result = _controller.Index();

        Assert.That(result, Is.TypeOf<ViewResult>());
    }
}
