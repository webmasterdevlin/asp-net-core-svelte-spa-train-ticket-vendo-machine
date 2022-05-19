using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainTicketMachine.Application.Common.Interfaces;
using TrainTicketMachine.Data.Contexts;

namespace TrainTicketMachine.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options => options
            .UseSqlite(config.GetConnectionString("DefaultConnection"),  b => b.MigrationsAssembly("TrainTicketMachine.WebApi")));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        return services;
    }
}