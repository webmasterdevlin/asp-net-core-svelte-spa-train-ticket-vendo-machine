using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TrainTicketMachine.Application.Common.Interfaces;
using TrainTicketMachine.Application.Dtos.Station;

namespace TrainTicketMachine.Application.Stations.Queries;

public class GetStationsQuery: IRequest<List<StationDto>> { }

public class GetStationsQueryHandler : IRequestHandler<GetStationsQuery, List<StationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetStationsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<StationDto>> Handle(GetStationsQuery request, CancellationToken cancellationToken)
    {
        var stations = await _context.Stations
                                            .ProjectTo<StationDto>(_mapper.ConfigurationProvider)
                                            .ToListAsync(cancellationToken);

        return stations;
    }
}