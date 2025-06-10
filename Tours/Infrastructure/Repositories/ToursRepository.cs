using backend.Bikes.Domain.Model.Aggregates;
using backend.Bikes.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.Tours.Domain.Repositories;

namespace backend.Tours.Infrastructure.Repositories;

public class ToursRepository(SafecycleDBContext context) : BaseRepository<Domain.Model.Entities.Tours>(context), IToursRepository
{
    public Task AddAsync(Domain.Model.Entities.Tours entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.Model.Entities.Tours entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(Domain.Model.Entities.Tours entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Model.Entities.Tours>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Model.Entities.Tours>> GetAllToursAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Model.Entities.Tours> GetToursByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}