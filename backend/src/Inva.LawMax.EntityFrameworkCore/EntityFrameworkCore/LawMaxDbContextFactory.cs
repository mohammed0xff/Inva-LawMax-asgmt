using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Inva.LawMax.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class LawMaxDbContextFactory : IDesignTimeDbContextFactory<LawMaxDbContext>
{
    public LawMaxDbContext CreateDbContext(string[] args)
    {
        LawMaxEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<LawMaxDbContext>()
        //builder.UseInMemoryDatabase("InMemoryDb");
        .UseSqlServer(configuration.GetConnectionString("Default"));

        return new LawMaxDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Inva.LawMax.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
