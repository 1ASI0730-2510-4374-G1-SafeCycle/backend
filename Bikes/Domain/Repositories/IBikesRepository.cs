using backend.Bikes.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Bike_Management.Domain.Repositories;

public interface IBikesRepository : IBaseRepository<Bikes.Domain.Model.Aggregates.Bikes>
{
    Task<IEnumerable<Bikes.Domain.Model.Aggregates.Bikes>> GetAllBikesAsync();
    
    Task<IEnumerable<Bikes.Domain.Model.Aggregates.Bikes>> GetAllAvailableBikesAsync();
    
    Task<Bikes.Domain.Model.Aggregates.Bikes> GetBikeByIdAsync(int id);
}