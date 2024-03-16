using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Queries;
using CQRS_MediatorR_Library.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGroceryRepository, InMemoryGroceryRepository>();
builder.Services.AddScoped<IGroceryRepository, GroceryRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetGroceryListQuery).Assembly));
builder.Services.AddScoped<IShoppingBagRepository, ShoppingBagRepository>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("CQRS_MediatoR_CRUD"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
