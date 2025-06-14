using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
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
