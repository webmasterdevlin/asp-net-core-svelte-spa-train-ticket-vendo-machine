using AutoMapper;
using MediatR;
using TrainTicketMachine.Application.Common.Interfaces;
using TrainTicketMachine.Application.Dtos.Station;
using TrainTicketMachine.Domain.Entities;

namespace TrainTicketMachine.Application.Stations.Commands;

public class CreateStationCommand: IRequest<StationDto>
{
    public string Name { get; set; }
}

public class CreateStationCommandHandler : IRequestHandler<CreateStationCommand, StationDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public CreateStationCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<StationDto> Handle(CreateStationCommand request, CancellationToken cancellationToken)
    {
        var entity = new Station
        {
            Name = request.Name
        };
        await _context.Stations.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

       return _mapper.Map<StationDto>(entity);
    }
}