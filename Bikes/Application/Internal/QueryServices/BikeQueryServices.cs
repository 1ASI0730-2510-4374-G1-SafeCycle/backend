using backend.Bike_Management.Domain.Model.Queries;
using backend.Bike_Management.Domain.Repositories;
using backend.Bike_Management.Domain.Services;

namespace backend.Bikes.Application.Internal.QueryServices;

public class BikeQueryServices(IBikesRepository bikesRepository): IBikesQueryService
{
    public async Task<Domain.Model.Aggregates.Bikes?> Handle(GetBikeByIdQuery query)
    {
        return await bikesRepository.GetBikeByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Bikes>> Handle(GetAllBikesQuery query)
    {
        return await bikesRepository.GetAllBikesAsync();
    }

    public async Task<IEnumerable<Domain.Model.Aggregates.Bikes>> Handle(GetAvailableBikesQuery query)
    {
        var allBikes = await bikesRepository.GetAllBikesAsync();
        return allBikes.Where(bike => bike.available == true);
    }
}