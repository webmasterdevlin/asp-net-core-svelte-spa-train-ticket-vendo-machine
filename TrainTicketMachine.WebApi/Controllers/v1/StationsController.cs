using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using TrainTicketMachine.Application.Dtos.Station;
using TrainTicketMachine.Application.Stations.Queries;

namespace TrainTicketMachine.WebApi.Controllers.v1;

public class StationsController: ApiController
{
    [HttpGet]
    public async Task<ActionResult<List<StationDto>>> GetStations()
    {
        return await Mediator.Send(new GetStationsQuery());
    }
}