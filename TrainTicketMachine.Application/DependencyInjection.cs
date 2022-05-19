using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrainTicketMachine.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        /* Station data don't change often. This is a candidate for Redis */
        
        // PerformanceBehavior
        // ValidationBehavior
        // UnhandledExceptionBehavior
        return services;
    }
}