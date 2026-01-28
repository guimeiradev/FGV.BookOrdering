using FGV.BookOrdering.Service.Interfaces;
using FGV.BookOrdering.Service.Services;
using FGV.BookOrdering.Service.Sorting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FGV.BookOrdering.Configuration;

public static class DependencyInjection
{
    public static ServiceProvider Configure()
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var rules = configuration
            .GetSection("Sorting:Rules")
            .Get<List<SortRule>>();

        services.AddSingleton(rules);

        services.AddTransient<IBooksOrdererService, BooksOrdererService>();

        return services.BuildServiceProvider();
    }
}