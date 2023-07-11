using System.Reflection;
using System.Runtime.Loader;

using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;

namespace CleanArchitecture.Presentation;

internal sealed class Program
{
    private static void Main(string[] args)
    {
        string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,
                                            "CleanArchitecture*.dll");

        IEnumerable<Assembly> assemblies = files
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.Configure<RazorViewEngineOptions>(p => p.ViewLocationExpanders.Add(new CustomViewLocationExpander()));

        builder.Services.Scan(p => p.FromAssemblies(assemblies)
                                    .AddClasses()
                                    .AsMatchingInterface());

        WebApplication app = builder.Build();

        if (! app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");

            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),
                                                                 "Content")),
            RequestPath = "/content"
        });

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(name: "default",
                               pattern: "{controller=Home}/{action=Index}/{id?}");

        app.UseAdvancedDependencyInjection();

        app.Run();
    }
}
