using Microsoft.AspNetCore.Mvc;

namespace TrainTicketMachine.WebApi.Extensions;

public static class ServicesExtensions
{
    public static void AddApiVersioningExtension(this IServiceCollection services)
    {
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });
    }

    public static void AddVersionedApiExplorerExtension(this IServiceCollection services)
    {
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
        });
    }
}