using backend.Bikes.Domain.Services;
using backend.Bikes.Domain.Services;
using backend.Bikes.Infrastructure.Repositories;
using backend.Bikes.Domain.Services;
using backend.Bikes.Infrastructure.Repositories;
using backend.Bikes.Application.Internal.CommandServices;
using backend.Bikes.Application.Internal.QueryServices;
using backend.Bikes.Domain.Repositories;
using backend.Shared.Domain.Repositories;
using backend.Renting.Application.Internal.CommandServices;
using backend.Renting.Application.Internal.QueryServices;
using backend.Renting.Domain.Repositories;
using backend.Renting.Domain.Services;
using backend.Renting.Infrastructure;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.IAM.Application.Internal.CommandServices;
using backend.IAM.Application.Internal.QueryServices;
using backend.IAM.Domain.Repositories;
using backend.IAM.Domain.Services;
using backend.IAM.Infrastructure;
using backend.Payments.Application.Internal.CommandServices;
using backend.Payments.Application.Internal.QueryServices;
using backend.Payments.Domain.Repositories;
using backend.Payments.Domain.Services;
using backend.Payments.Infrastructure.Repositories;
using backend.Tours.Application.Internal.CommandServices;
using backend.Tours.Application.Internal.QueryServices;
using backend.Tours.Domain.Repositories;
using backend.Tours.Domain.Services;
using backend.Tours.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

//Adding Swagger as a Service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "SafeCycle.API",
            Version = "v1",
            Description = "ACME.SafeCycle.API",
            TermsOfService = new Uri("https://safecycle.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "SafeCycle",
                Email = "SafeCycle@gmail.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            []
        }
    });
    options.EnableAnnotations();
});

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
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Shared
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<TimestampAudit>();
//BikeStations
builder.Services.AddScoped<IBikeStationRepository, BikeStationsRepository>();
builder.Services.AddScoped<IBikeStationCommandService, BikeStationCommandService>();
builder.Services.AddScoped<IBikeStationQueryService, BikeStationQueryServices>();
//Bikes
builder.Services.AddScoped<IBikesRepository, BikesRepository>();
builder.Services.AddScoped<IBikesCommandService, BikeCommandService>();
builder.Services.AddScoped<IBikesQueryService, BikeQueryServices>();
//Payment
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
builder.Services.AddScoped<IPaymentQueryService, PaymentQueryServices>(); 
//PaymentInformation
builder.Services.AddScoped<IPaymentInformationRepository, PaymentInformationRepository>();
builder.Services.AddScoped<IPaymentInformationCommandService, PaymentInformationCommandService>();
builder.Services.AddScoped<IPaymentInformationQueryService, PaymentInformationQueryServices>();
//Renting
builder.Services.AddScoped<IRentRepository, RentRepository>();
builder.Services.AddScoped<IRentCommandService, RentCommandService>();
builder.Services.AddScoped<IRentQueryService, RentQueryService>();
//IAM
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
//Tours
builder.Services.AddScoped<IToursRepository, ToursRepository>();
builder.Services.AddScoped<IToursCommandService, ToursCommandService>();
builder.Services.AddScoped<IToursQueryService, ToursQueryServices>(); 
//TourBooking
builder.Services.AddScoped<ITourBookingRepository, TourBookingRepository>();
builder.Services.AddScoped<ITourBookingCommandService, TourBookingCommandService>();
builder.Services.AddScoped<ITourBookingQueryService, TourBookingQueryServices>();
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

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//Mapping Controllers EndPoints
app.MapControllers();

app.Run();
