using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Model.Commands;

namespace backend.Bike_Management.Domain.Services;

public interface IBikeStationCommandService
{
    Task<BikeStations?> Handle(CreateBikeStationCommand command);
}