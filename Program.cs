using backend.Bikes.Application.Internal.CommandServices;
using backend.Bikes.Application.Internal.QueryServices;
using backend.Bikes.Domain.Repositories;
using backend.Bikes.Domain.Services;
using backend.Bikes.Infrastructure.Repositories;
using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adding Swagger as a Service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Controllers for manage our classes
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connection))
{
  throw new Exception("Database connection string not set");
}
   
//Add our DbContext connection to Dependency Injector
builder.Services.AddDbContext<SafecycleDBContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//BikeStations
builder.Services.AddScoped<IBikeStationRepository, BikeStationsRepository>();
builder.Services.AddScoped<IBikeStationCommandService, BikeStationCommandService>();
builder.Services.AddScoped<IBikeStationQueryService, BikeStationQueryServices>();

var app = builder.Build();

//Add scope for our DbContext
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider.GetRequiredService<SafecycleDBContext>();
  services.Database.EnsureCreated();
}

// Add Swagger for use on Development

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Mapping Controllers EndPoints
app.MapControllers();

app.Run();
