using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Home;

public sealed class HomeController : Controller
{
    public ViewResult Index() =>
        // ReSharper disable once Mvc.ViewNotResolved
        View();
}
