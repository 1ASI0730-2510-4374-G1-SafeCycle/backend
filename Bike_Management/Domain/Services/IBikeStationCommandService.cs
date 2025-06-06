using backend.Bike_Management.Domain.Model.Aggregates;
using backend.Bike_Management.Domain.Model.Commands;

namespace backend.Bike_Management.Domain.Services;

public interface IBikeStationCommandService
{
    Task<BikeStations?> Handle(CreateBikeStationCommand command);
}