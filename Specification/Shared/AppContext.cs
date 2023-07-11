using System.Reflection;
using System.Runtime.Loader;

using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Common.Dates;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Moq;
using Moq.AutoMock;

namespace CleanArchitecture.Specification.Shared;

public sealed class AppContext
{
    public readonly IServiceProvider Container;

    public readonly IDatabaseService DatabaseService;

    public readonly IDateService DateService;

    public readonly IInventoryService InventoryService;

    public readonly AutoMocker Mocker;

    public AppContext()
    {
        Mocker = new AutoMocker();

        DbContextOptions<MockDatabaseService> options = new DbContextOptionsBuilder<MockDatabaseService>()
                                                        .UseInMemoryDatabase(databaseName: "CleanArchitectureInMemory")
                                                        .Options;

        DatabaseService = new MockDatabaseService(options);

        InventoryService = Mocker.GetMock<IInventoryService>().Object;

        Mock<IDateService> mockDateService = Mocker.GetMock<IDateService>();

        mockDateService
            .Setup(p => p.GetDate())
            .Returns(DateTime.Parse("2001-02-03"));

        DateService = mockDateService.Object;

        string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,
                                            "CleanArchitecture*.dll");

        IEnumerable<Assembly> assemblies = files
            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

        ServiceProvider provider = new ServiceCollection()
                                   .Scan(p => p.FromAssemblies(assemblies)
                                               .AddClasses()
                                               .AsMatchingInterface())
                                   .AddSingleton(_ => DatabaseService)
                                   .AddSingleton(_ => InventoryService)
                                   .AddSingleton(_ => DateService)
                                   .BuildServiceProvider();

        Container = provider;
    }
}
