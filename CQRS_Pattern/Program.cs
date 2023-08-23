using CQRS_Pattern.Data;
using CQRS_Pattern.Middleware;
using CQRS_Pattern.Queries;
using CQRS_Pattern.Repositories;
using MediatR;
using Microsoft.AspNetCore.HttpsPolicy;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddMediatR(typeof(GetCustomerListQuery).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseGlobalExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
