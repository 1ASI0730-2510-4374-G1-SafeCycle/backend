using backend.Renting.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Renting.Domain.Repositories;

public interface IRentRepository : IBaseRepository<Rent>
{
    Task<Rent?> GetByIdAsync(int id);
    
}