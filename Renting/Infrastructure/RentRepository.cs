using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Renting.Infrastructure;

public class RentRepository(SafecycleDBContext context) : BaseRepository<Rent>(context), IRentRepository
{
    public async Task<Rent?> GetByIdAsync(int id)
    {
        return await Context.Set<Rent>()
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}