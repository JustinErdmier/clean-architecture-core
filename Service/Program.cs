using System.Reflection;
using System.Runtime.Loader;

namespace CleanArchitecture.Service;

internal sealed class Program
{
    private static void Main(string[] args)
    {
        string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,
                                            "CleanArchitecture*.dll");

        IEnumerable<Assembly> assemblies = files
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(p => p.DocumentFilter<LowercaseDocumentFilter>());

        builder.Services.AddAdvancedDependencyInjection();

        builder.Services.Scan(p => p.FromAssemblies(assemblies)
                                    .AddClasses()
                                    .AsMatchingInterface());

        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseAdvancedDependencyInjection();

        app.Run();
    }
}
