using backend.Bikes.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Bike_Management.Domain.Repositories;

public interface IBikesRepository : IBaseRepository<BikesManagement>
{
    Task<IEnumerable<BikesManagement>> GetAllBikesAsync();
    
    Task<IEnumerable<BikesManagement>> GetAllAvailableBikesAsync();
    
    Task<BikesManagement> GetBikeByIdAsync(int id);
}