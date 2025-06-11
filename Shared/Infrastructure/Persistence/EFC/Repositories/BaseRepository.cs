using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace backend.Shared.Infrastructure.Persistence.EFC.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
{
    
    protected readonly SafecycleDBContext context;

    public BaseRepository(SafecycleDBContext context)
    {
        this.context = context;
    }
    
    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}