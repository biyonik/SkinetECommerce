using System.Text.Json;
using Microsoft.Extensions.Logging;
using Exception = System.Exception;

namespace SkinetECommerce.DataAccess.Concrete.Utils;

public class SkinetContextSeeder : ISeeder<SkinetDbContext>
{
    public async Task SeedAsync(SkinetDbContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var brandsData = await File.ReadAllTextAsync("../../SeedData/brands.json");
            
            if (!context.ProductBrands.Any())
            {
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                foreach (var brand in brands)
                {
                    context.ProductBrands.Add(brand);
                }

                await context.SaveChangesAsync();
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = await File.ReadAllTextAsync("../../SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                foreach (var type in types)
                {
                    context.ProductTypes.Add(type);
                }

                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync("../../SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }

                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<SkinetContextSeeder>();
            logger.LogError(ex.Message);
        }
    }
}