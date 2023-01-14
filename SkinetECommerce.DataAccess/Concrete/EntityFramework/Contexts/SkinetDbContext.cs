namespace SkinetECommerce.DataAccess.Concrete.EntityFramework.Contexts;

public class SkinetDbContext: DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{envName}.json", optional: false)
            .Build();
        optionsBuilder.UseNpgsql(configurationRoot.GetConnectionString("DefaultConnection"));
    }
}