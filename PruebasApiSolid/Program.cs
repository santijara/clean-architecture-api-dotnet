using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasApiSolid.Application.Common;
using PruebasApiSolid.Application.Interfaces;
using PruebasApiSolid.Application.Services;
using PruebasApiSolid.Application.Validators;
using PruebasApiSolid.Domain.Entities;
using PruebasApiSolid.Extensions;
using PruebasApiSolid.Infrastructure;
using PruebasApiSolid.Infrastructure.Persistance;
using PruebasApiSolid.Middleware;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();
builder.Services.AddApiBehavior();

builder.Services.AddDbContext<AppDataBaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<MiddlewareExceptions>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
