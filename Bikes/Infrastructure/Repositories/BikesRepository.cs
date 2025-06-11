using backend.Bike_Management.Domain.Repositories;
using backend.Bikes.Domain.Model.Aggregates;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend.Bike_Management.Infrastructure.Repositories;

public class BikesRepository(SafecycleDBContext context) : BaseRepository<BikesManagement>(context), IBikesRepository

{
    public Task<IEnumerable<BikesManagement>> GetAllBikesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BikesManagement>> GetAllAvailableBikesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BikesManagement> GetBikeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}