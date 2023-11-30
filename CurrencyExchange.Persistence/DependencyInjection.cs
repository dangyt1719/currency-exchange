using CurrencyExchange.Domain.Repositories;
using CurrencyExchange.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CurrencyExchangeDbContext> (options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<ICurrencyRepository, CurrencyRepository>();

        return services;
    }
}
