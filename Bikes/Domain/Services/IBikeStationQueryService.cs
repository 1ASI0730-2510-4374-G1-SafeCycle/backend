using backend.Bike_Management.Domain.Model.Queries;
using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Model.Queries;

namespace backend.Bikes.Domain.Services;

public interface IBikeStationQueryService
{
    Task<BikeStations?> Handle(GetBikeStationByIdQuery query);

    Task<IEnumerable<BikeStations>> Handle(GetAllBikeStationsQuery query);
    
    Task<IEnumerable<BikeStations>> Handle(GetAvailableBikeStationsQuery query);
}