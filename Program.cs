var builder = WebApplication.CreateBuilder(args);

//Adding Swagger as a Service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Controllers for manage our classes
builder.Services.AddControllers();

var app = builder.Build();


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
