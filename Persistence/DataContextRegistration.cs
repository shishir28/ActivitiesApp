using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;
public static class DataContextRegistration
{

    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
                   options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void MigrateDB(this IServiceProvider svcProvider)
    {
        var services = svcProvider.CreateScope().ServiceProvider;
        var dbContext = services.GetRequiredService<DataContext>();
        dbContext.Database.Migrate();
        DataContextSeed.SeedAsync(dbContext).ConfigureAwait(false);
    }
}
