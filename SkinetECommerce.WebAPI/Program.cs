using Autofac;
using Autofac.Extensions.DependencyInjection;
using SkinetECommerce.Business.DependencyResolvers.Autofac;
using SkinetECommerce.DataAccess.Concrete.EntityFramework.Contexts;


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

app.Run();