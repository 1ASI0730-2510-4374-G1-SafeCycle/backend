using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace backend.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(SafecycleDBContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}