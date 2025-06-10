using backend.Renting.Domain.Model.Aggregates;
using backend.Renting.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend.Renting.Infrastructure;

public class RentRepository : BaseRepository<Rent>, IRentRepository
{
    protected RentRepository(SafecycleDBContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Rent>> FindByUserIdAsync(int id)
    {
        return await Context.Set<Rent>().Where(x => x.UserId == id).ToListAsync();
    }
}