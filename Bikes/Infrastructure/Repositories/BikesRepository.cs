using backend.Bike_Management.Domain.Repositories;
using backend.Bikes.Domain.Model.Aggregates;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend.Bike_Management.Infrastructure.Repositories;

public class BikesRepository(SafecycleDBContext context) : BaseRepository<Bikes.Domain.Model.Aggregates.Bikes>(context), IBikesRepository

{
    public Task<IEnumerable<Bikes.Domain.Model.Aggregates.Bikes>> GetAllBikesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Bikes.Domain.Model.Aggregates.Bikes>> GetAllAvailableBikesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Bikes.Domain.Model.Aggregates.Bikes> GetBikeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}