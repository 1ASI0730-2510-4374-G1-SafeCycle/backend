using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace backend.Bikes.Infrastructure.Repositories;

public class BikeStationsRepository(SafecycleDBContext context) : BaseRepository<BikeStations>(context), IBikeStationRepository
{
    public Task<IEnumerable<BikeStations>> GetAllStationsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BikeStations>> GetAllAvailableStationsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BikeStations> GetBikeStationByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}