using CQRS_MediatorR_Library.DbData;
using CQRS_MediatorR_Library.Models;
using CQRS_MediatorR_Library.Queries;
using CQRS_MediatorR_Library.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGroceryRepository<GroceryModel>, InMemoryGroceryRepository>();
builder.Services.AddScoped(typeof(IGroceryRepository<>), typeof(GroceryRepository<>));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetGroceryListQuery).Assembly));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("CQRS_MediatoR_CRUD"));
});

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
