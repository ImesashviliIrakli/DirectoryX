using Api.Extensions;
using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register Serilog
//builder.Host.UseSerilog((context, loggerConfig) =>
//    loggerConfig.ReadFrom.Configuration(context.Configuration));

// Register Class Libraries
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Swagger configuration here
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
    app.SeedData();
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.UseAuthorization();

app.MapControllers();

app.UseCustomLanguageHandler();

app.Run();
