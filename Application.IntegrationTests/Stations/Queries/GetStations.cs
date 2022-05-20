using System.Threading.Tasks;
using FluentAssertions;
using TrainTicketMachine.Application.Stations.Queries;
using Xunit;

namespace Application.IntegrationTests.Stations.Queries;


using static DatabaseFixture;
[Collection("DatabaseCollection")]
public class GetStations
{
    public GetStations()
    {
        ResetState().GetAwaiter().GetResult();
    }

    [Fact]
    public async Task ShouldReturnTourLists()
    {
        var query = new GetStationsQuery();
        var result = await SendAsync(query);

        result.Should().NotBeEmpty();
    }
}