using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SkinetECommerce.Business.DependencyResolvers.Autofac;
using SkinetECommerce.DataAccess.Concrete.EntityFramework.Contexts;
using SkinetECommerce.DataAccess.Concrete.Utils;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SkinetDbContext>();
builder.Services.AddAutofac((ContainerBuilder containerBuilder) =>
{
    containerBuilder.RegisterModule(new AutofacDependencyResolverModule());
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

async Task DoCreateDatabaseFromMigration()
{
    await using var scope = app.Services.CreateAsyncScope();
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<SkinetDbContext>();
        await context.Database.MigrateAsync();
        await new SkinetContextSeeder().SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occured during migration");
    }
}

await DoCreateDatabaseFromMigration();

app.Run();