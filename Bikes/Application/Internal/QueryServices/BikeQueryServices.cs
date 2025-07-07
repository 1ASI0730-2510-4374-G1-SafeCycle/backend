using backend.Bikes.Domain.Model.Queries;
using backend.Bikes.Domain.Services;
using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Repositories;

namespace backend.Bikes.Application.Internal.QueryServices;

public class BikeQueryServices(IBikesRepository bikesRepository): IBikesQueryService
{
    public async Task<Bike?> Handle(GetBikeByIdQuery query)
    {
        return await bikesRepository.GetBikeByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Bike>> Handle(GetAvailableBikesByStationIdQuery byStationIdQuery)
    {
        var allBikes = await bikesRepository.GetAllBikesByStationIdAsync(byStationIdQuery.stationId);
        return allBikes.Where(bike => bike.available == true);
    }
}