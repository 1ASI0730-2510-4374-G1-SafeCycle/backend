using backend.Bikes.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Bike_Management.Domain.Repositories;

public interface IBikeStationRepository : IBaseRepository<BikeStations>
{
    Task<IEnumerable<BikeStations>> GetAllStationsAsync();
    
    Task<IEnumerable<BikeStations>> GetAllAvailableStationsAsync();
    
    Task<BikeStations> GetBikeStationByIdAsync(int id);
}