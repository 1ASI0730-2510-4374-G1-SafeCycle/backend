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

    public async Task<IEnumerable<Bike>> Handle(GetAllBikesQuery query)
    {
        return await bikesRepository.GetAllBikesAsync();
    }

    public async Task<IEnumerable<Bike>> Handle(GetAvailableBikesQuery query)
    {
        var allBikes = await bikesRepository.GetAllBikesAsync();
        return allBikes.Where(bike => bike.available == true);
    }
}