using TopUp.API.Middlewares;
using TopUp.Application.Configuration;
using TopUp.Infrastructure.Persistence.Configurations;
using ToUp.API.Extention;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// cqrs handler dependency injection
builder.Services.AddApplication();
//db connections and interface dependency injection
builder.Services.AddInfrastructure(builder.Configuration);


builder.RegisterCors();
//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors("CorsPolicy");

// Add global exception handling middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
