using Microsoft.EntityFrameworkCore;
using TrainTicketMachine.Domain.Entities;

namespace TrainTicketMachine.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Station> Stations { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}