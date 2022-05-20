using TrainTicketMachine.Domain.Entities;

namespace TrainTicketMachine.Data.Contexts;

public static class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        if (!context.Stations.Any())
        {
            await context.Stations.AddAsync(
                new Station()
                {
                    Id = "3982rgjalgdhab",
                    Name = "test"
                }
                );

            await context.SaveChangesAsync();
        }
    }
}