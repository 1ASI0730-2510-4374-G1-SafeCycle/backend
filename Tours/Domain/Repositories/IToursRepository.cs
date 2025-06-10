using backend.Tours.Domain.Model.Aggregates;
using backend.Shared.Domain.Repositories;

namespace backend.Tours.Domain.Repositories;

public interface IToursRepository: IBaseRepository<Model.Aggregates.Tours>
{
    
    Task<IEnumerable<Model.Aggregates.Tours>> GetAllToursAsync();
    
    Task<Model.Aggregates.Tours> GetToursByIdAsync(int id);
}