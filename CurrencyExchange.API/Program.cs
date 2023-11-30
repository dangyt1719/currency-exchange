using CurrencyExchange.Application.Commands.CreateAccount;
using CurrencyExchange.Application.Commands.CreateCurrency;
using CurrencyExchange.Application.Common;
using CurrencyExchange.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configs = builder.Configuration;

var domainAssembly = typeof(CreateCurrencyCommand).GetTypeInfo().Assembly;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(configs);

builder.Services.AddMediatR(cfg=>
{
    cfg.RegisterServicesFromAssembly(domainAssembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(domainAssembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
