using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Nous stockons la chaîne de string ici
string? context = builder.Configuration.GetConnectionString("Connection");

// Nous créons ici un service
builder.Services.AddDbContext<ContextDatabase>(opt => opt.UseSqlServer(context));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();

//    //Add this line
//    app.MapScalarApiReference(options =>
//    {
//        options
//        .WithTheme(ScalarTheme.BluePlanet);
//    });
//}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "/openapi/{documentName}.json";
    });
    app.MapScalarApiReference();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
