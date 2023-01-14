using SkinetECommerce.DataAccess.Concrete.EntityFramework.Contexts;

namespace SkinetECommerce.WebAPI.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection LoadServices(this IServiceCollection services,
        IConfigurationBuilder configurationBuilder)
    {
        MainServices(services);
        return services;
    }

    private static void MainServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<SkinetDbContext>();
    }
}