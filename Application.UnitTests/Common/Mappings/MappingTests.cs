using System;
using AutoMapper;
using TrainTicketMachine.Application.Common.Mappings;
using TrainTicketMachine.Application.Dtos.Station;
using TrainTicketMachine.Domain.Entities;
using Xunit;

namespace Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = _configuration.CreateMapper();
    }

    /// <summary>
    /// Should have valid mapper configurations.
    /// </summary>
    [Fact]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }
        
    [Theory]
    [InlineData(typeof(Station), typeof(StationDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = Activator.CreateInstance(source);

        _mapper.Map(instance, source, destination);
    }
}