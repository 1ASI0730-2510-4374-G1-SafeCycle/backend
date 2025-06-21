using backend.Bikes.Domain.Model.Queries;
using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Repositories;
using backend.Bikes.Domain.Services;

namespace backend.Bikes.Application.Internal.QueryServices;

public class BikeStationQueryServices(IBikeStationRepository bikeStationRepository): IBikeStationQueryService
{
    public async Task<BikeStations?> Handle(GetBikeStationByIdQuery query)
    {
        return await bikeStationRepository.FindByIdAsync(query.id);
    }

    public async Task<IEnumerable<BikeStations>> Handle(GetAllBikeStationsQuery query)
    {
        return await bikeStationRepository.ListAsync();
    }
}