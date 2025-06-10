using backend.Renting.Application.Internal.CommandServices;
using backend.Renting.Application.Internal.QueryServices;
using backend.Renting.Domain.Repositories;
using backend.Renting.Domain.Services;
using backend.Renting.Infrastructure;
using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.User_Management.Application.Internal.CommandServices;
using backend.User_Management.Application.Internal.QueryServices;
using backend.User_Management.Domain.Repositories;
using backend.User_Management.Domain.Services;
using backend.User_Management.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Adding Swagger as a Service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Controllers for manage our classes
builder.Services.AddControllers();

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

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();

builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<IRentQueryService, RentQueryService>();
builder.Services.AddScoped<IRentCommandService, RentCommandService>();

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
