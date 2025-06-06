using backend.Bike_Management.Domain.Model.Aggregates;
using backend.Bike_Management.Domain.Model.Queries;

namespace backend.Bike_Management.Domain.Services;

public interface IBikeStationQueryService
{
    Task<BikeStations?> Handle(GetBikeStationByIdQuery query);

    Task<IEnumerable<BikeStations>> Handle(GetAllBikeStationsQuery query);
    
    Task<IEnumerable<BikeStations>> Handle(GetAvailableBikeStationsQuery query);
}