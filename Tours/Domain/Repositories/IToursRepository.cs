using backend.Shared.Domain.Repositories;

namespace backend.Tours.Domain.Repositories;

public interface IToursRepository: IBaseRepository<Model.Entities.Tours>
{
    
    Task<IEnumerable<Model.Entities.Tours>> GetAllToursAsync();
    
    Task<Model.Entities.Tours> GetToursByIdAsync(int id);
}