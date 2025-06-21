using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Model.Commands;

namespace backend.Bikes.Domain.Services;

public interface IBikeStationCommandService
{
    Task<BikeStations?> Handle(CreateBikeStationCommand command);
    
    Task<BikeStations?> Handle(UpdateBikeStationCommand command);
}