using backend.Shared.Domain.Repositories;
using backend.Tours.Domain.Model.Entities;

namespace backend.Tours.Domain.Repositories;

public interface IToursRepository: IBaseRepository<Tour>
{
    
    Task<IEnumerable<Tour>> GetAllToursAsync();
    
    Task<Tour?> GetToursByIdAsync(int id);
}