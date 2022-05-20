using Microsoft.EntityFrameworkCore;
using TrainTicketMachine.Data.Contexts;
using TrainTicketMachine.WebApi;

 public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var context = services.GetRequiredService<ApplicationDbContext>();
                        
                        if (context.Database.IsSqlServer()) 
                            await context.Database.MigrateAsync();

                        await ApplicationDbContextSeed.SeedSampleDataAsync(context);
                    }

                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while migrating or seeding the database");

                        throw;
                    }
                }

                await host.RunAsync();

                return 0;
            }

            catch (Exception ex)
            {
                return 1;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }