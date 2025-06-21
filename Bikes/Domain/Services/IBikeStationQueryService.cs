using backend.Bikes.Domain.Model.Queries;
using backend.Bikes.Domain.Model.Aggregates;

namespace backend.Bikes.Domain.Services;

public interface IBikeStationQueryService
{
    Task<BikeStations?> Handle(GetBikeStationByIdQuery query);

    Task<IEnumerable<BikeStations>> Handle(GetAllBikeStationsQuery query);
    
}