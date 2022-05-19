using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrainTicketMachine.Application.Common.Interfaces;
using TrainTicketMachine.Domain.Entities;

namespace TrainTicketMachine.Data.Contexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Station> Stations => Set<Station>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }
    
}