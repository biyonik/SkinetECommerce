using Microsoft.Extensions.Logging;

namespace SkinetECommerce.DataAccess.Concrete.Utils;

public interface ISeeder<in TContext> where TContext: DbContext, new()
{
    Task SeedAsync(TContext context, ILoggerFactory loggerFactory);
}