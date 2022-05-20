using Microsoft.AspNetCore.Mvc.ApiExplorer;
using TrainTicketMachine.Application;
using TrainTicketMachine.Data;
using TrainTicketMachine.WebApi.Extensions;

namespace TrainTicketMachine.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication(Configuration);
        services.AddInfrastructure(Configuration);

        services.AddControllers();
        services.AddApiVersioningExtension();
        services.AddVersionedApiExplorerExtension();
        services.AddCors();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        
        app.UseCors(b =>
        {
            b.AllowAnyOrigin();
            b.AllowAnyHeader();
            b.AllowAnyMethod();
        });

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}